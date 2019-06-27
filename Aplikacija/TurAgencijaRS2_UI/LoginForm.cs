using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_UI.Admin;
using TurAgencijaRS2_UI.Vodic;
using TurAgencijaRS2_UI.Zaposlenik;

namespace TurAgencijaRS2_UI
{
    public partial class LoginForm : Form
    {
        APIService service = new APIService("Regije");// ne mora bit korisnik jer na svakom api kontroleru radi provjeru, jer svaki kontroler nasljedjuje basecontorller

        private readonly APIService korisniciService = new APIService("korisnici");

        private readonly APIService zaposleniciService = new APIService("zaposlenici");
        private readonly APIService gradovi = new APIService("gradovi");



        public LoginForm()
        {
            InitializeComponent();
        }

     

        private async void loginBtn_Click_1(object sender, EventArgs e)
        {
            try
            {

                APIService.Username = korisnickoImeInput.Text;

                APIService.Password = passwordInput.Text;


                var korisnici = await korisniciService.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);
                var korisnik = new TurAgencijaRS2_Model.Korisnici();

                foreach (var x in korisnici)
                {
                    if (korisnickoImeInput.Text == x.KorisnickoIme)
                    {
                        korisnik = x;
                    }
                }




                var zaposlenik = await zaposleniciService.GetById<TurAgencijaRS2_Model.Zaposlenici>(korisnik.KorisnikId);

                if (zaposlenik != null)

                {
                    await service.Get<dynamic>(null);

                    if (zaposlenik.IsVodic)
                    {
                        this.Hide();
                    
                        mainVodic mainVodic = new mainVodic(zaposlenik.KorisnikId);
                   
                        mainVodic.Closed += (s, args) => this.Close();
                        mainVodic.Show();

                    }
                    else
                    {
                        this.Hide();

                        mainZaposlenik mainVodic = new mainZaposlenik(zaposlenik.KorisnikId);

                        mainVodic.Closed += (s, args) => this.Close();
                        mainVodic.Show();

                    }



                }
                else
                {
                    this.Hide();

                    homeAdmin mainVodic = new homeAdmin();

                    mainVodic.Closed += (s, args) => this.Close();
                    mainVodic.Show();
                }
              


            }
            catch (Exception ex)
            {

                MessageBox.Show("pogresan username ili password", "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);


        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {

            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
