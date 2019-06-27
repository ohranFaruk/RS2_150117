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
    public partial class zaduzenjaOdgodiVodic : Form
    {
        private readonly APIService zaduzenjaService = new APIService("zaduzenja");
        private readonly APIService putovanjaService = new APIService("putovanja");

        private readonly APIService gradoviService = new APIService("gradovi");


        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        private int zaduzenjeId;
        public zaduzenjaOdgodiVodic(int _zaduzenjeId)
        {

            zaduzenjeId = _zaduzenjeId;
            InitializeComponent();
        }

        private async void zaduzenjaOdgodiVodic_Load(object sender, EventArgs e)
        {
            var zaduzenje = await zaduzenjaService.GetById<TurAgencijaRS2_Model.Zaduzenja>(zaduzenjeId);

            var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(zaduzenje.PutovanjeId);


            var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);

            putovanjeInput.Text = grad.Naziv;
            opisInput.Text = zaduzenje.Opis;
            datumPocetka.Text = putovanje.DatumPolaska.ToShortDateString();
            datumZavrsetka.Text = putovanje.DatumPovratka.ToShortDateString();

            if(zaduzenje.Odgodjeno)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private async void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var zaduzenje = await zaduzenjaService.GetById<TurAgencijaRS2_Model.Zaduzenja>(zaduzenjeId);

            if (zaduzenje.Odgodjeno==true)
            {
                zaduzenje.Odgodjeno = false;
                await zaduzenjaService.Update<TurAgencijaRS2_Model.Zaduzenja>(zaduzenjeId,zaduzenje);
                checkBox1.Checked = false;
                MessageBox.Show("Zaduzenje aktivirano");
                this.Close();
            }
            else
            {
                zaduzenje.Odgodjeno = true;
                checkBox1.Checked = true;
                await zaduzenjaService.Update<TurAgencijaRS2_Model.Zaduzenja>(zaduzenjeId, zaduzenje);
                MessageBox.Show("Zaduzenje odgođeno");
                this.Close();
            }
        }

        private void zaduzenjaOdgodiVodic_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);

        }

        private void zaduzenjaOdgodiVodic_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void zaduzenjaOdgodiVodic_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
