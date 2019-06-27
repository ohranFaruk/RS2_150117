using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurAgencijaRS2_UI.Zaposlenik
{
    public partial class zaduzenjaZaposlenik : Form
    {

        private readonly APIService gradoviService = new APIService("gradovi");

        private readonly APIService putovanjaService = new APIService("putovanja");

        private readonly APIService ponudeService = new APIService("ponude");

        private readonly APIService zaposleniciService = new APIService("korisnici");


        private readonly APIService zaduzenjaService = new APIService("zaduzenja");

        private int? _Id;
        public zaduzenjaZaposlenik(int? Id=null)
        {
            _Id = Id;
            InitializeComponent();

            zaduzenjaGrid.AutoGenerateColumns = false;
        }
        #region logika
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainZaposlenik mainZaposlenik = new mainZaposlenik(_Id);

            mainZaposlenik.Closed += (s, args) => this.Close();
            mainZaposlenik.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            putovanjaZaposlenik putovanjaZaposlenik = new putovanjaZaposlenik(_Id);

            putovanjaZaposlenik.Closed += (s, args) => this.Close();
            putovanjaZaposlenik.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();

            ponudeZaposlenik ponudeZaposlenik = new ponudeZaposlenik(_Id);

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

        private async void zaduzenjaZaposlenik_Load(object sender, EventArgs e)
        {
            var zaduzenja = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);




            for (int i = 0; i < zaduzenja.Count; i++)
            {
                zaduzenjaGrid.Rows.Add();
                zaduzenjaGrid.Rows[i].Cells[0].Value = zaduzenja[i].ZaduzenjeId;

                var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(zaduzenja[i].PutovanjeId);
                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);
                var zaposlenik = await zaposleniciService.GetById<TurAgencijaRS2_Model.Korisnici>(zaduzenja[i].ZaposlenikId);


                zaduzenjaGrid.Rows[i].Cells[1].Value = grad.Naziv;


                zaduzenjaGrid.Rows[i].Cells[2].Value = zaposlenik.Ime+" "+zaposlenik.Prezime;


                zaduzenjaGrid.Rows[i].Cells[3].Value = zaduzenja[i].Odgodjeno;


                zaduzenjaGrid.Rows[i].Cells[4].Value = zaduzenja[i].Opis;

            
              

            }


        }

        private void dodajKorisnikaBtn_Click(object sender, EventArgs e)
        {
            zaduzenjaDetailZaposlenik zaduzenjaDetailZaposlenik = new zaduzenjaDetailZaposlenik(null,_Id);
            zaduzenjaDetailZaposlenik.Show();
        }

        private void zaduzenjaGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = zaduzenjaGrid.SelectedRows[0].Cells[0].Value;

            zaduzenjaDetailZaposlenik cijenaInput = new zaduzenjaDetailZaposlenik(int.Parse(id.ToString()));

            cijenaInput.Show();
           
        }

        private async void Osvježi_Click(object sender, EventArgs e)
        {
            zaduzenjaGrid.Rows.Clear();
            zaduzenjaGrid.Refresh();
            
            var zaduzenja = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);




            for (int i = 0; i < zaduzenja.Count; i++)
            {
                zaduzenjaGrid.Rows.Add();
                zaduzenjaGrid.Rows[i].Cells[0].Value = zaduzenja[i].ZaduzenjeId;

                var putovanje = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(zaduzenja[i].PutovanjeId);
                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanje.GradId);
                var zaposlenik = await zaposleniciService.GetById<TurAgencijaRS2_Model.Korisnici>(zaduzenja[i].ZaposlenikId);


                zaduzenjaGrid.Rows[i].Cells[1].Value = grad.Naziv;


                zaduzenjaGrid.Rows[i].Cells[2].Value = zaposlenik.Ime + " " + zaposlenik.Prezime;


                zaduzenjaGrid.Rows[i].Cells[3].Value = zaduzenja[i].Odgodjeno;


                zaduzenjaGrid.Rows[i].Cells[4].Value = zaduzenja[i].Opis;




            }

        }
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        private void zaduzenjaZaposlenik_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void zaduzenjaZaposlenik_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }

        }

        private void zaduzenjaZaposlenik_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
