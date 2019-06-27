using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurAgencijaRS2_UI.Admin
{
    public partial class recenzijeAdmin : Form
    {
        private readonly APIService recenzijeService = new APIService("recenzije");



        private readonly APIService putovanjaService = new APIService("putovanja");

        private readonly APIService rezervacijeService = new APIService("rezervacije");


        private readonly APIService gradoviService = new APIService("gradovi");


        private readonly APIService korisniciService = new APIService("korisnici");


        private readonly APIService zaduzenjaService = new APIService("zaduzenja");
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        public recenzijeAdmin()
        {
            InitializeComponent();
        }

        private async void recenzijeAdmin_Load(object sender, EventArgs e)
        {
            var recenzije = await recenzijeService.Get<List<TurAgencijaRS2_Model.Recenzije>>(null);

            var zaduzenjaSva = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);

            var zaduzenje = new TurAgencijaRS2_Model.Zaduzenja();

            for (int i = 0; i < recenzije.Count; i++)
            {
                recenzijeGrid.Rows.Add();
                recenzijeGrid.Rows[i].Cells[0].Value = recenzije[i].RecenzijaId;

                var rezervacija = await rezervacijeService.GetById<TurAgencijaRS2_Model.Rezervacije>(recenzije[i].RezervacijaId);

                var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(rezervacija.PutovanjeId);

                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);
                var korisnik = await korisniciService.GetById<TurAgencijaRS2_Model.Korisnici>(rezervacija.KorisnikId);


                foreach (var x in zaduzenjaSva)
                {
                    if(x.PutovanjeId==putovanje.PutovanjeId)
                    {
                         zaduzenje = x;
                    }
                }
                
                //  var zaduzenje = await zaduzenjaService.GetById<TurAgencijaRS2_Model.Zaduzenja>();
               var vodic = await korisniciService.GetById<TurAgencijaRS2_Model.Korisnici>(zaduzenje.ZaposlenikId);

              //  var vodic = await korisniciService.GetById<TurAgencijaRS2_Model.Korisnici>(putovanje.kori);

                this.recenzijeGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.recenzijeGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.recenzijeGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.recenzijeGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                 this.recenzijeGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                recenzijeGrid.Rows[i].Cells[1].Value = grad.Naziv;


                recenzijeGrid.Rows[i].Cells[2].Value = recenzije[i].Komentar;

                recenzijeGrid.Rows[i].Cells[3].Value = recenzije[i].Ocjena;

                if(vodic==null)
                {
                    recenzijeGrid.Rows[i].Cells[4].Value = "niko zadužen";
                }
                else 

                recenzijeGrid.Rows[i].Cells[4].Value = vodic.Ime+" "+vodic.Prezime;


                recenzijeGrid.Rows[i].Cells[5].Value = korisnik.Ime + " " + korisnik.Prezime;
              
            }

        }

        #region logika
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainAdmin ponudeZaposlenik = new mainAdmin();

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            homeAdmin ponudeZaposlenik = new homeAdmin();

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
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

        private void recenzijeAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void recenzijeAdmin_MouseMove(object sender, MouseEventArgs e)
        {

            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void recenzijeAdmin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

      
    }
}
