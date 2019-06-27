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
    public partial class ponudaDetailZaposlenik : Form
    {

        #region konstruktor
        private readonly APIService ponudeService = new APIService("ponude");

        private readonly APIService putovanjaService = new APIService("putovanja");


        private readonly APIService gradoviService = new APIService("gradovi");

        private readonly int? ponudaId;

        private readonly int? korisnikId;
        public ponudaDetailZaposlenik(int? _ponudaId=null,int? _korisnikId=null)
        {
            korisnikId = _korisnikId;
            ponudaId = _ponudaId;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        public async void LoadPutovanjaPoId()
        {
            var svaPutovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);

            var ponude = await ponudeService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);
            var brojacPonude = 0;

            var putovanja = new List<TurAgencijaRS2_Model.Putovanja>();

            for (int i = 0; i < svaPutovanja.Count; i++)
            {
                if (svaPutovanja[i].PonudaId == ponudaId)
                {
                    var res = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(svaPutovanja[i].PutovanjeId);
                    putovanja.Insert(brojacPonude, res);
                    brojacPonude++;


                }

            }


            for (int i = 0; i < putovanja.Count; i++)
            {
                putovanjaGrid1.Rows.Add();
                putovanjaGrid1.Rows[i].Cells[0].Value = putovanja[i].PutovanjeId;

                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanja[i].GradId);



                putovanjaGrid1.Rows[i].Cells[1].Value = grad.Naziv;


                putovanjaGrid1.Rows[i].Cells[2].Value = putovanja[i].Cijena;


                putovanjaGrid1.Rows[i].Cells[3].Value = putovanja[i].DatumPolaska.ToShortDateString();


                putovanjaGrid1.Rows[i].Cells[4].Value = putovanja[i].DatumPovratka.ToShortDateString();

                putovanjaGrid1.Rows[i].Cells[5].Value = putovanja[i].Opis;

                putovanjaGrid1.Rows[i].Cells[6].Value = putovanja[i].Popust;




            }

        }

        private async void ponudaDetailZaposlenik_Load(object sender, EventArgs e)
        {
            if (ponudaId.HasValue)
            {

                var ponuda = await ponudeService.GetById<TurAgencijaRS2_Model.Ponude>(ponudaId);

                nazivInput.Text = ponuda.NazivPonude;
                pocetak.Text = ponuda.DatumPocetka.ToShortDateString();
                zavrsetak.Text = ponuda.DatumZavrsetka.ToShortDateString();

                LoadPutovanjaPoId();
            }


        }


        #endregion


        private void dodajPutovanje_Click(object sender, EventArgs e)
        {
            cijenaInput cijenaInput = new cijenaInput();

            cijenaInput.Show();
        }

        private async void snimiPonude_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new PonudeUpsertRequest()
                {
                    NazivPonude = nazivInput.Text,
                    DatumPocetka = pocetak.Value,
                    DatumZavrsetka = zavrsetak.Value,
                    DatumIzmjene = DateTime.Now,
                    IsAktivna = true

                };

                if (ponudaId.HasValue)
                {
                    await ponudeService.Update<TurAgencijaRS2_Model.Ponude>(ponudaId, request);




                    MessageBox.Show("Ponuda uspjesno izmjenjena");
                }
                else
                {
                    await ponudeService.Insert<TurAgencijaRS2_Model.Ponude>(request);




                    MessageBox.Show("Ponuda uspjesno dodana");

                }
                this.Close();


            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
         
        }
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);
        private void nazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nazivInput.Text))
            {
                errorProvider.SetError(nazivInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(nazivInput, null);
            }

            if (nazivInput.Text.Length < 3)
            {
                errorProvider.SetError(nazivInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }
        }

        private void ponudaDetailZaposlenik_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void ponudaDetailZaposlenik_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }

        }

        private void ponudaDetailZaposlenik_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private async void Obrisi_Click(object sender, EventArgs e)


        {
            var svaPutovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);


            var counter = 0;
                foreach (var x in svaPutovanja)
                {
                if (ponudaId == x.PonudaId)
                { 
                    svaPutovanja.ElementAt(counter).PonudaId = null;

                    await putovanjaService.Update<TurAgencijaRS2_Model.Putovanja>(x.PutovanjeId, svaPutovanja.ElementAt(counter));
                }
                counter++;
                }
            
    

            await ponudeService.Delete<TurAgencijaRS2_Model.Ponude>(ponudaId);




            MessageBox.Show("Ponuda uspjesno obrisana");


            this.Close();

        }
    }
}
