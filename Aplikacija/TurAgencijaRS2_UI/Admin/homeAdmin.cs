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
    public partial class homeAdmin : Form
    {
        #region konstruktor
        private readonly APIService korisniciService = new APIService("korisnici");


        private readonly APIService putovanjaService = new APIService("putovanja");


        private readonly APIService recenzijeService = new APIService("recenzije");


        private readonly APIService rezervacijeService = new APIService("rezervacije");

        private bool dragging = false;

        private Point start_Point = new Point(0, 0);



        public homeAdmin()
        {
            InitializeComponent();
        }

        private async void homeAdmin_Load(object sender, EventArgs e)
        {
            var putovanja=await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);
            putovanjaL.Text = putovanja.Count().ToString();

            var korisnici = await korisniciService.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);
            korisniciL.Text = korisnici.Count().ToString();

            var recenzije = await recenzijeService.Get<List<TurAgencijaRS2_Model.Recenzije>>(null);
            recenzijaL.Text = recenzije.Count().ToString();



            var rezervacije = await rezervacijeService.Get<List<TurAgencijaRS2_Model.Rezervacije>>(null);
            rezervacijeL.Text = rezervacije.Count().ToString();

        }
        #endregion


        #region logika


        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainAdmin ponudeZaposlenik = new mainAdmin();

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            recenzijeAdmin ponudeZaposlenik = new recenzijeAdmin();

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
        }
        #endregion

        private void homeAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void homeAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void homeAdmin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
