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
    public partial class zaduzenjaVodic : Form
    {
        private readonly APIService zaduzenjaService = new APIService("zaduzenja");

        private readonly APIService gradoviService = new APIService("gradovi");

        private readonly APIService putovanjaService = new APIService("putovanja");

        private int korisnikId;


        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);


        public zaduzenjaVodic(int _korisnikId)
        {
            korisnikId = _korisnikId;
            InitializeComponent();
            zaduzenjaGrid.AutoGenerateColumns = false;
        }

        private async void zaduzenjaVodic_Load(object sender, EventArgs e)
        {
            #region zaduzenja
            var zaduzenjaSva = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);

            var zaduzenja = new List<TurAgencijaRS2_Model.Zaduzenja>();
            var brojac = 0;
            for (int i = 0; i < zaduzenjaSva.Count; i++)
            {
                if (korisnikId == zaduzenjaSva[i].ZaposlenikId)
                {
                    zaduzenja.Insert(brojac, zaduzenjaSva[i]);
                    brojac++;
                }
            }
            #endregion






            for (int i = 0; i < zaduzenja.Count; i++)
            {
                zaduzenjaGrid.Rows.Add();
                zaduzenjaGrid.Rows[i].Cells[0].Value = zaduzenja[i].ZaduzenjeId;


                var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(zaduzenja[i].PutovanjeId);

                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);

                this.zaduzenjaGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.zaduzenjaGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.zaduzenjaGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.zaduzenjaGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                // this.zaduzenjaGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                zaduzenjaGrid.Rows[i].Cells[1].Value = grad.Naziv;


                zaduzenjaGrid.Rows[i].Cells[2].Value = zaduzenja[i].Opis;

                zaduzenjaGrid.Rows[i].Cells[3].Value = putovanje.DatumPolaska.ToShortDateString();

                zaduzenjaGrid.Rows[i].Cells[4].Value = putovanje.DatumPovratka.ToShortDateString();

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                zaduzenjaGrid.Columns.Add(chk);
                chk.HeaderText = "Odgođeno";
                chk.Name = "chk";
                zaduzenjaGrid.Rows[i].Cells[5].Value = zaduzenja[i].Odgodjeno;

                // zaduzenjaGrid.Rows[i].Cells[3].che = checked; 
             

               



            }
            if (zaduzenja.Count > 0)
            {
                for (int i = 0; i < zaduzenja.Count-1; i++)
                {
                    zaduzenjaGrid.Columns.RemoveAt(6);
                }
              
            }




            //zaduzenjaGrid.DataSource = zaduzenja;
        }

        private void zaduzenjaGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = zaduzenjaGrid.SelectedRows[0].Cells[0].Value;

            zaduzenjaOdgodiVodic ponudaDetailZaposlenik = new zaduzenjaOdgodiVodic(int.Parse(id.ToString()));
            ponudaDetailZaposlenik.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainVodic ponudeZaposlenik = new mainVodic(korisnikId);

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            recenzijeVodic ponudeZaposlenik = new recenzijeVodic(korisnikId);

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();
        }

        private void zaduzenjaVodic_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void zaduzenjaVodic_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void zaduzenjaVodic_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private async void prikaziKorisnikeBtn_Click(object sender, EventArgs e)
        {

            zaduzenjaGrid.Rows.Clear();
            zaduzenjaGrid.Refresh();

            #region zaduzenja
            var zaduzenjaSva = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);

            var zaduzenja = new List<TurAgencijaRS2_Model.Zaduzenja>();
            var brojac = 0;
            for (int i = 0; i < zaduzenjaSva.Count; i++)
            {
                if (korisnikId == zaduzenjaSva[i].ZaposlenikId)
                {
                    zaduzenja.Insert(brojac, zaduzenjaSva[i]);
                    brojac++;
                }
            }
            #endregion






            for (int i = 0; i < zaduzenja.Count; i++)
            {
                zaduzenjaGrid.Rows.Add();
                zaduzenjaGrid.Rows[i].Cells[0].Value = zaduzenja[i].ZaduzenjeId;


                var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(zaduzenja[i].PutovanjeId);

                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);

                this.zaduzenjaGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.zaduzenjaGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.zaduzenjaGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.zaduzenjaGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                // this.zaduzenjaGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                zaduzenjaGrid.Rows[i].Cells[1].Value = grad.Naziv;


                zaduzenjaGrid.Rows[i].Cells[2].Value = zaduzenja[i].Opis;

                zaduzenjaGrid.Rows[i].Cells[3].Value = putovanje.DatumPolaska.ToShortDateString();

                zaduzenjaGrid.Rows[i].Cells[4].Value = putovanje.DatumPovratka.ToShortDateString();

                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                zaduzenjaGrid.Columns.Add(chk);
                chk.HeaderText = "Odgođeno";
                chk.Name = "chk";
                zaduzenjaGrid.Rows[i].Cells[5].Value = zaduzenja[i].Odgodjeno;

                // zaduzenjaGrid.Rows[i].Cells[3].che = checked; 
              
                    zaduzenjaGrid.Columns.RemoveAt(6);


            }


        }
    }
}
