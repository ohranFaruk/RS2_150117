using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Flurl;

using Flurl.Http;
using TurAgencijaRS2_Model.Requests;

using TurAgencijaRS2_Model;

namespace TurAgencijaRS2_UI.Admin
{
    public partial class mainAdmin : Form
    {

        #region Kontruktor
        private readonly APIService apiService = new APIService("korisnici");

        private readonly APIService zaposleniciService = new APIService("zaposlenici");
        private bool dragging = false;

        private Point offset;

        private Point start_Point=new Point(0,0);





        public mainAdmin()
        {

          
            InitializeComponent();
            korisniciGrid.AutoGenerateColumns = false;
        


            this.button1.FlatAppearance.MouseOverBackColor = this.button1.BackColor;
            this.button1.BackColorChanged += (s, e) => {
                this.button1.FlatAppearance.MouseOverBackColor = this.button1.BackColor;

            };




            this.button2.FlatAppearance.MouseOverBackColor = this.button2.BackColor;
            this.button2.BackColorChanged += (s, e) => {
                this.button2.FlatAppearance.MouseOverBackColor = this.button2.BackColor;

            };


            this.button3.FlatAppearance.MouseOverBackColor = this.button3.BackColor;
            this.button3.BackColorChanged += (s, e) => {
                this.button3.FlatAppearance.MouseOverBackColor = this.button3.BackColor;

            };





        }

        private async void mainAdmin_Load(object sender, EventArgs e)
        {
            korisniciGrid.Rows.Clear();
            korisniciGrid.Refresh();
            var search = new KorisniciSearchRequest()
            {
                ime = nameInput.Text

            };

            var result = await apiService.Get<List<TurAgencijaRS2_Model.Korisnici>>(search);
            var zaposlenici = await zaposleniciService.Get<List<TurAgencijaRS2_Model.Zaposlenici>>(null);
          

            for (int i = 0; i < result.Count; i++)
            {
                var zaposlenik = new TurAgencijaRS2_Model.Zaposlenici();
                korisniciGrid.Rows.Add();
                korisniciGrid.Rows[i].Cells[0].Value = result[i].KorisnikId;

                foreach (var x in zaposlenici)
                {
                    if (x.KorisnikId == result[i].KorisnikId)
                        zaposlenik = x;
                }

                korisniciGrid.Rows[i].Cells[1].Value = result[i].Ime;

                korisniciGrid.Rows[i].Cells[2].Value = result[i].Prezime;
                korisniciGrid.Rows[i].Cells[3].Value = result[i].KorisnickoIme;
                korisniciGrid.Rows[i].Cells[4].Value = result[i].Adresa;
                korisniciGrid.Rows[i].Cells[5].Value = result[i].Spol;

                if(zaposlenik.KorisnikId!=0)
                {
                    korisniciGrid.Rows[i].Cells[6].Value = "Da";

                    if(zaposlenik.IsVodic)
                    {
                        korisniciGrid.Rows[i].Cells[7].Value = "Da";

                    }
                    else
                    {
                        korisniciGrid.Rows[i].Cells[7].Value = "Ne";


                    }

                }
                else
                {
                    korisniciGrid.Rows[i].Cells[6].Value = "Ne";

                    korisniciGrid.Rows[i].Cells[7].Value = "Ne";

                }


                this.korisniciGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

           

        }


        #endregion

        private async void prikaziKorisnikeBtn_Click(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                ime = nameInput.Text

            };

            var result = await apiService.Get<List<TurAgencijaRS2_Model.Korisnici>>(search);

            //            korisniciGrid.DataSource = result;
            korisniciGrid.Rows.Clear();
            korisniciGrid.Refresh();

         
            var zaposlenici = await zaposleniciService.Get<List<TurAgencijaRS2_Model.Zaposlenici>>(null);


            for (int i = 0; i < result.Count; i++)
            {
                var zaposlenik = new TurAgencijaRS2_Model.Zaposlenici();
                korisniciGrid.Rows.Add();
                korisniciGrid.Rows[i].Cells[0].Value = result[i].KorisnikId;

                foreach (var x in zaposlenici)
                {
                    if (x.KorisnikId == result[i].KorisnikId)
                        zaposlenik = x;
                }

                korisniciGrid.Rows[i].Cells[1].Value = result[i].Ime;

                korisniciGrid.Rows[i].Cells[2].Value = result[i].Prezime;
                korisniciGrid.Rows[i].Cells[3].Value = result[i].KorisnickoIme;
                korisniciGrid.Rows[i].Cells[4].Value = result[i].Adresa;
                korisniciGrid.Rows[i].Cells[5].Value = result[i].Spol;

                if (zaposlenik.KorisnikId != 0)
                {
                    korisniciGrid.Rows[i].Cells[6].Value = "Da";

                    if (zaposlenik.IsVodic)
                    {
                        korisniciGrid.Rows[i].Cells[7].Value = "Da";

                    }
                    else
                    {
                        korisniciGrid.Rows[i].Cells[7].Value = "Ne";


                    }

                }
                else
                {
                    korisniciGrid.Rows[i].Cells[6].Value = "Ne";

                    korisniciGrid.Rows[i].Cells[7].Value = "Ne";

                }


                this.korisniciGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.korisniciGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }




        }

        private void dodajKorisnikaBtn_Click(object sender, EventArgs e)
        {
            userDetailAdmin userDetailAdmin = new userDetailAdmin();
            userDetailAdmin.Show();
           

        }

        private void korisniciGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = korisniciGrid.SelectedRows[0].Cells[0].Value;

            userEditAdmin userEditAdmin = new userEditAdmin(int.Parse(id.ToString()));

            userEditAdmin.Show();
        
        }




        #region scroll

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void mainAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void mainAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            if(dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void mainAdmin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }




        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            homeAdmin ponudeZaposlenik = new homeAdmin();

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

        private void button4_Click(object sender, EventArgs e)
        {
            Reports.ReportViewForm frm = new Reports.ReportViewForm();

            frm.Show();
        }
    }
}
