using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_Model.Requests;

namespace TurAgencijaRS2_UI.Zaposlenik
{
    public partial class zaduzenjaDetailZaposlenik : Form
    {


        private readonly APIService zaposleniciService = new APIService("zaposlenici");

        private readonly APIService putovanjaService = new APIService("putovanja");

        private readonly APIService korisniciService = new APIService("korisnici");

        private readonly APIService zaduzenjaService = new APIService("zaduzenja");

        private readonly APIService gradoviService = new APIService("gradovi");

        private int? zaduzenjeId;

        private int? korisnikId;
        public zaduzenjaDetailZaposlenik(int? Id=null,int? _korisnikId=null)
        {
            korisnikId = _korisnikId;
            zaduzenjeId = Id;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }


        async void  LoadZaposlenici()
        {
            


            var korisnici = await korisniciService.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);

            var korisniciPrikaz = new List<TurAgencijaRS2_Model.Korisnici>(korisnici.Count);

            var prikazBrojac = 0;

            for (int i = 0; i < korisnici.Count; i++)
            {
                var zaposlenik = await zaposleniciService.GetById<TurAgencijaRS2_Model.Zaposlenici>(korisnici[i].KorisnikId);

                if (zaposlenik!=null&&zaposlenik.IsVodic) {
                    korisniciPrikaz.Add(korisnici[i]);
                    korisniciPrikaz.ElementAt(prikazBrojac).imePrezime = korisnici.ElementAt(i).Ime + " " + korisnici.ElementAt(i).Prezime;
                    prikazBrojac++;
                }
            }




            korisniciPrikaz.Insert(0, new TurAgencijaRS2_Model.Korisnici());

            zaposlenikInput.DataSource = korisniciPrikaz;
            zaposlenikInput.DisplayMember = "imePrezime";
            zaposlenikInput.ValueMember = "KorisnikId";

        }


        async void LoadPutovanja()
        {



            var putovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);
            var gradovi = new List<TurAgencijaRS2_Model.Gradovi>();

            for (int i = 0; i < putovanja.Count; i++)
            {
                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanja[i].GradId);
                putovanja[i].grad = grad.Naziv;
             
            }



            putovanja.Insert(0, new TurAgencijaRS2_Model.Putovanja());


            PutovanjaInput.DataSource = putovanja;
            PutovanjaInput.DisplayMember = "grad";
            PutovanjaInput.ValueMember = "PutovanjeId";
        }


        private async void zaduzenjaDetailZaposlenik_Load(object sender, EventArgs e)
        {

            

            if(zaduzenjeId.HasValue)

            {
                var zaduzenje = await zaduzenjaService.GetById<TurAgencijaRS2_Model.Zaduzenja>(zaduzenjeId);

                opisInput.Text = zaduzenje.Opis;


                var putovanja = new List<TurAgencijaRS2_Model.Putovanja>() ;

                var zaduzenja = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);

                foreach (var x in zaduzenja)
                {
                    if(x.ZaduzenjeId== zaduzenjeId)
                    {
                        var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(x.PutovanjeId);
                        var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);
                        putovanje.grad = grad.Naziv;
                        putovanja.Insert(0, putovanje);
                    }
                }
             



             


                PutovanjaInput.DataSource = putovanja;
                PutovanjaInput.DisplayMember = "grad";
                PutovanjaInput.ValueMember = "PutovanjeId";

                

                var zaposlenik = await korisniciService.GetById<TurAgencijaRS2_Model.Korisnici>(zaduzenje.ZaposlenikId);

                zaposlenik.imePrezime = zaposlenik.Ime + " " + zaposlenik.Prezime;

           

                var zaposlenicis = new List<TurAgencijaRS2_Model.Korisnici>();

                zaposlenicis.Insert(0, zaposlenik);

                zaposlenikInput.DataSource = zaposlenicis;
                zaposlenikInput.DisplayMember = "imePrezime";
                zaposlenikInput.ValueMember = "KorisnikId";



                if (zaduzenje.Odgodjeno)
                {
                    odgođeno.Checked = true;
                }
            }
           else { 
                LoadZaposlenici();
                LoadPutovanja();
            }


        }

        private async void snimi_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            { 
            var request = new ZaduzenjaUpsertRequest
            {
                Opis = opisInput.Text


            };
            if(odgođeno.Checked)
            {
                request.Odgodjeno = true; 
            }
            else request.Odgodjeno = false;


                request.NaCekanju = true;


            var idObj = PutovanjaInput.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int putovanjeId))//ako je ispravno selektovano dobijemo id parametar
            {
                request.PutovanjeId = putovanjeId;
            }


            var idObj1 = zaposlenikInput.SelectedValue;

            if (int.TryParse(idObj1.ToString(), out int zaposlenikId))//ako je ispravno selektovano dobijemo id parametar
            {
                request.ZaposlenikId = zaposlenikId;
            }


            if (zaduzenjeId.HasValue)
            {
                await zaduzenjaService.Update<TurAgencijaRS2_Model.Zaduzenja>(zaduzenjeId,request);
                MessageBox.Show("Zaduzenje uspjesno izmjenjeno ! ");
            }
            else
            {
                await zaduzenjaService.Insert<TurAgencijaRS2_Model.Zaduzenja>(request);
                MessageBox.Show("Zaduzenje uspjesno dodano ! ");
            }
            
            this.Close();
                
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void PutovanjaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PutovanjaInput.Text))
            {
                errorProvider.SetError(PutovanjaInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(PutovanjaInput, null);
            }
        }

        private void zaposlenikInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(zaposlenikInput.Text))
            {
                errorProvider.SetError(zaposlenikInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(zaposlenikInput, null);
            }
        }

        private void opisInput_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(opisInput.Text))
            {
                errorProvider.SetError(opisInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(opisInput, null);
            }

            if (opisInput.Text.Length < 3)
            {
                errorProvider.SetError(opisInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }
        }
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);
        private void zaduzenjaDetailZaposlenik_MouseDown(object sender, MouseEventArgs e)
        {

            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void zaduzenjaDetailZaposlenik_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void zaduzenjaDetailZaposlenik_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
