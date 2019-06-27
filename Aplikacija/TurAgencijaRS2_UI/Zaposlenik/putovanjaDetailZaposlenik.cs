using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_Model.Requests;

namespace TurAgencijaRS2_UI.Zaposlenik
{
    public partial class cijenaInput : Form
    {

        private readonly APIService gradoviService = new APIService("gradovi");

        private readonly APIService putovanjaService = new APIService("putovanja");

        private readonly APIService ponudeService = new APIService("ponude");

        private readonly APIService zaduzenjaService = new APIService("zaduzenja");


        private readonly APIService rezervacijeService = new APIService("rezervacije");

        private readonly APIService recenzijeService = new APIService("recenzije");



        private readonly int? putovanjeId;

        private readonly int? korisnikId;

        public cijenaInput(int? PutovanjeId=null,int? _korisnikId=null)
        {
            putovanjeId = PutovanjeId;
            korisnikId = _korisnikId;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async Task LoadGradovi()
        {
            var result = await gradoviService.Get<List<TurAgencijaRS2_Model.Gradovi>>(null);

            result.Insert(0, new TurAgencijaRS2_Model.Gradovi());

            gradovInput.DataSource = result;
            gradovInput.DisplayMember = "Naziv";
            gradovInput.ValueMember = "GradId";

        }


        private async Task LoadPonude()
        {
            var result = await ponudeService.Get<List<TurAgencijaRS2_Model.Ponude>>(null);

            result.Insert(0, new TurAgencijaRS2_Model.Ponude());

            ponudeInput.DataSource = result;
            ponudeInput.DisplayMember = "NazivPonude";
            ponudeInput.ValueMember = "PonudaId";

        }


        private async void cijenaInput_Load(object sender, EventArgs e)
        {

            if (putovanjeId.HasValue)
            {

                var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(putovanjeId);


                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);


                var result = await gradoviService.Get<List<TurAgencijaRS2_Model.Gradovi>>(null);

                result.Insert(0, new TurAgencijaRS2_Model.Gradovi());

                result[0].Naziv = grad.Naziv;
                result[0].GradId = grad.GradId;

                gradovInput.DataSource = result;
                gradovInput.DisplayMember = "Naziv";
                gradovInput.ValueMember = "GradId";

                polazak.Text = putovanje.DatumPolaska.ToString();

                dolazak.Text = putovanje.DatumPovratka.ToString();

                cijena.Text = putovanje.Cijena.ToString();
                opisInput.Text = putovanje.Opis;

                popustInput.Text = putovanje.Popust.ToString();

            }
            else
            {
                await LoadGradovi();
              
            }
            await LoadPonude();
        }

        private async void snimi_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            { 
            var request = new RezervacijeUpsertRequests
            {
                Cijena = decimal.Parse(cijena.Text),



                               DatumKreiranja = DateTime.Now,
                DatumPolaska=polazak.Value,
                DatumPovratka=dolazak.Value,
                Opis=opisInput.Text,
                Aktivno=true,
                DatumIzmjene=DateTime.Now
            };
               
                if(popustInput.Text=="")
                {
                    request.Popust = 0;
                }
            var idObj = gradovInput.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int GradId))//ako je ispravno selektovano dobijemo id parametar
            {
                request.GradId = GradId;
            }

            

                var idObj1 = ponudeInput.SelectedValue;
                if(Convert.ToInt32(idObj1) != 0)
                { 



                if (int.TryParse(idObj1.ToString(), out int PonudaId))//ako je ispravno selektovano dobijemo id parametar
                {
                    request.PonudaId = PonudaId;
                }
                }


                if (putovanjeId.HasValue)
            {
                await putovanjaService.Update<TurAgencijaRS2_Model.Putovanja>(putovanjeId,request);
                MessageBox.Show("Putovanje uspjesno izmjenjeno ! ");
            }
            else
            {
                await putovanjaService.Insert<TurAgencijaRS2_Model.Putovanja>(request);
                MessageBox.Show("Putovanje uspjesno dodano ! ");
            }
            
            this.Close();

              
            }
        }

        #region logika
        private void button2_Click(object sender, EventArgs e)
        {
            GradoviAdd gradoviAdd = new GradoviAdd();
            gradoviAdd.Show();
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
        #endregion

        #region validacija

        private void gradovInput_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(gradovInput.Text))
            {
                errorProvider.SetError(gradovInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(gradovInput, null);
            }
        }

        private void cijena_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cijena.Text))
            {
                errorProvider.SetError(cijena, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cijena, null);
            }



            string regexPattern1 = @"[1-9]\d*(\.\d+)?$";
            if (!Regex.IsMatch(cijena.Text, regexPattern1))
            {
                errorProvider.SetError(cijena, "Dozvoljeni samo brojevi");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cijena, null);
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

        private void popustInput_Validating(object sender, CancelEventArgs e)
        {
           if(popustInput.Text=="")
            {
                errorProvider.SetError(popustInput, null);
               
            }
            else
            {
                string regexPattern1 = @"[0-9]\d*(\.\d+)?$";
                if (!Regex.IsMatch(popustInput.Text, regexPattern1))
                {
                    errorProvider.SetError(popustInput, "Dozvoljeni samo brojevi");
                    e.Cancel = true;
                }

            }
         


        }
        #endregion

        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        private void cijenaInput_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void cijenaInput_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void cijenaInput_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private  async void button1_Click(object sender, EventArgs e)
        {
            if(putovanjeId!=null)
            {
                var svaZaduzenja = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);
                var sveRezervacije = await rezervacijeService.Get<List<TurAgencijaRS2_Model.Rezervacije>>(null);
                var sveRecenzije = await recenzijeService.Get<List<TurAgencijaRS2_Model.Recenzije>>(null);
                foreach (var x in svaZaduzenja)
                {
                    if(x.PutovanjeId==putovanjeId)
                    {
                        await zaduzenjaService.Delete < TurAgencijaRS2_Model.Zaduzenja > (x.ZaduzenjeId);
                    }
                }

                foreach (var x in sveRezervacije)
                {
                    if(x.PutovanjeId==putovanjeId)
                    {
                        foreach (var y in sveRecenzije)
                        {
                            if (y.RezervacijaId == x.RezervacijaId)
                                await recenzijeService.Delete<TurAgencijaRS2_Model.Recenzije>(y.RecenzijaId);
                        }
                        await rezervacijeService.Delete<TurAgencijaRS2_Model.Rezervacije>(x.RezervacijaId);
                    }
                }
               
                await putovanjaService.Delete < TurAgencijaRS2_Model.Putovanja > (putovanjeId);
                MessageBox.Show("Putovanje uspejsno obrisano");
                this.Close();
            }
        }
    }
}
