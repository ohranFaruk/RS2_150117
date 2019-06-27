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
    public partial class ponudeZaposlenik : Form
    {

        private readonly APIService ponudeService = new APIService("ponude");

        #region konstruktor
        private int? _Id;
        public ponudeZaposlenik(int? Id=null)
        {
            _Id = Id;
            InitializeComponent();
            ponudeGrid.AutoGenerateColumns = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            putovanjaZaposlenik putovanjaZaposlenik = new putovanjaZaposlenik(_Id);

            putovanjaZaposlenik.Closed += (s, args) => this.Close();
            putovanjaZaposlenik.Show();
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

        private void dodajPonude_Click(object sender, EventArgs e)
        {
            ponudaDetailZaposlenik ponudaDetailZaposlenik = new ponudaDetailZaposlenik(null,_Id);
            ponudaDetailZaposlenik.Show();
         
        }

        private async void ponudeZaposlenik_Load(object sender, EventArgs e)
        {

            var ponude = await ponudeService.Get<List<TurAgencijaRS2_Model.Ponude>>(null);



            ponudeGrid.DataSource = ponude;
        }

        private void ponudeGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = ponudeGrid.SelectedRows[0].Cells[0].Value;

            ponudaDetailZaposlenik ponudaDetailZaposlenik = new ponudaDetailZaposlenik(int.Parse(id.ToString()));
            ponudaDetailZaposlenik.Show();
          
        }

        private async void button5_Click(object sender, EventArgs e)
        {


         
            ponudeGrid.Refresh();

            var ponude = await ponudeService.Get<List<TurAgencijaRS2_Model.Ponude>>(null);



            ponudeGrid.DataSource = ponude;
        }
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);
        private void ponudeZaposlenik_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void ponudeZaposlenik_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void ponudeZaposlenik_MouseUp(object sender, MouseEventArgs e)
        {

            dragging = false;
        }
    }
}
