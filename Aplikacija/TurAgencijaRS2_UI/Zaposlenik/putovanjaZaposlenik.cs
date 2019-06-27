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
    public partial class putovanjaZaposlenik : Form
    {
        #region konstruktor
        private readonly APIService gradoviService = new APIService("gradovi");

        private readonly APIService putovanjaService = new APIService("putovanja");

        private readonly APIService regijeService = new APIService("Regije");

        private int? _Id;
        public putovanjaZaposlenik(int? Id=null)
        {
            _Id = Id;
            InitializeComponent();
            putovanjaGrid.AutoGenerateColumns = false;
         
        }
        #endregion


        #region logika
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            mainZaposlenik mainZaposlenik = new mainZaposlenik(_Id);

            mainZaposlenik.Closed += (s, args) => this.Close();
            mainZaposlenik.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();

            ponudeZaposlenik ponudeZaposlenik = new ponudeZaposlenik(_Id);

            ponudeZaposlenik.Closed += (s, args) => this.Close();
            ponudeZaposlenik.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {


            this.Hide();

            zaduzenjaZaposlenik zaduzenjaZaposlenik = new zaduzenjaZaposlenik(_Id);

            zaduzenjaZaposlenik.Closed += (s, args) => this.Close();
            zaduzenjaZaposlenik.Show();


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

        private async void putovanjaZaposlenik_Load(object sender, EventArgs e)
        {
            var putovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);

            putovanjaGrid.Refresh();


            for (int i = 0; i < putovanja.Count; i++)
            {
                putovanjaGrid.Rows.Add();
                putovanjaGrid.Rows[i].Cells[0].Value = putovanja[i].PutovanjeId;

                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanja[i].GradId);



                putovanjaGrid.Rows[i].Cells[1].Value = grad.Naziv;


                putovanjaGrid.Rows[i].Cells[2].Value = putovanja[i].Cijena;


                putovanjaGrid.Rows[i].Cells[3].Value = putovanja[i].DatumPolaska.ToShortDateString();


                putovanjaGrid.Rows[i].Cells[4].Value = putovanja[i].DatumPovratka.ToShortDateString();

                putovanjaGrid.Rows[i].Cells[5].Value = putovanja[i].Opis;

                putovanjaGrid.Rows[i].Cells[6].Value = putovanja[i].Popust;


            

            }

         
        }

        private void dodajKorisnikaBtn_Click(object sender, EventArgs e)
        {

            cijenaInput cijenaInput = new cijenaInput(null,_Id);
            cijenaInput.Show();
          
        }

        private void putovanjaGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = putovanjaGrid.SelectedRows[0].Cells[0].Value;

            cijenaInput cijenaInput = new cijenaInput(int.Parse(id.ToString()));

            cijenaInput.Show();
          
        }

        private async void prikaziKorisnikeBtn_Click(object sender, EventArgs e)
        {

            putovanjaGrid.Rows.Clear();
            putovanjaGrid.Refresh();

            var putovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);

            putovanjaGrid.Refresh();


            for (int i = 0; i < putovanja.Count; i++)
            {
                putovanjaGrid.Rows.Add();
                putovanjaGrid.Rows[i].Cells[0].Value = putovanja[i].PutovanjeId;

                var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(putovanja[i].GradId);



                putovanjaGrid.Rows[i].Cells[1].Value = grad.Naziv;


                putovanjaGrid.Rows[i].Cells[2].Value = putovanja[i].Cijena;


                putovanjaGrid.Rows[i].Cells[3].Value = putovanja[i].DatumPolaska.ToShortDateString();


                putovanjaGrid.Rows[i].Cells[4].Value = putovanja[i].DatumPovratka.ToShortDateString();

                putovanjaGrid.Rows[i].Cells[5].Value = putovanja[i].Opis;

                putovanjaGrid.Rows[i].Cells[6].Value = putovanja[i].Popust;




            }
        }


        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        private void putovanjaZaposlenik_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);

        }

        private void putovanjaZaposlenik_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }

        }

        private void putovanjaZaposlenik_MouseUp(object sender, MouseEventArgs e)
        {

            dragging = false;
        }

      
      
    }
}
