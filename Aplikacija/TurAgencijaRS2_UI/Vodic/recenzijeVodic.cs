using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurAgencijaRS2_UI.Vodic
{
    public partial class recenzijeVodic : Form
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

        private int korisnikId;
        public recenzijeVodic(int k)
        {
            korisnikId = k;
            InitializeComponent();
        }

        private async void recenzijeVodic_Load(object sender, EventArgs e)
        {
            var recenzije = await recenzijeService.Get<List<TurAgencijaRS2_Model.Recenzije>>(null);

            var zaduzenjaSva = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);

            var zaduzenje = new TurAgencijaRS2_Model.Zaduzenja();

            for (int i = 0; i < recenzije.Count; i++)
            {


                foreach (var y in zaduzenjaSva)
                {
                    if(y.ZaposlenikId==korisnikId)
                    {
                        recenzijeGrid.Rows.Add();
                        recenzijeGrid.Rows[i].Cells[0].Value = recenzije[i].RecenzijaId;

                        var rezervacija = await rezervacijeService.GetById<TurAgencijaRS2_Model.Rezervacije>(recenzije[i].RezervacijaId);

                        var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(rezervacija.PutovanjeId);

                        var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);
                        var korisnik = await korisniciService.GetById<TurAgencijaRS2_Model.Korisnici>(rezervacija.KorisnikId);


                        foreach (var x in zaduzenjaSva)
                        {
                            if (x.PutovanjeId == putovanje.PutovanjeId)
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



                        recenzijeGrid.Rows[i].Cells[1].Value = grad.Naziv;


                        recenzijeGrid.Rows[i].Cells[2].Value = recenzije[i].Komentar;

                        recenzijeGrid.Rows[i].Cells[3].Value = recenzije[i].Ocjena;


                    }
                }


              
               

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void recenzijeVodic_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void recenzijeVodic_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void recenzijeVodic_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainVodic ponudeZaposlenik = new mainVodic(korisnikId);

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            zaduzenjaVodic ponudeZaposlenik = new zaduzenjaVodic(korisnikId);

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
        }
    }
}
