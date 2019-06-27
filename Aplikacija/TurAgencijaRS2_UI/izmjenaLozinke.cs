using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_Model.Requests;

namespace TurAgencijaRS2_UI
{
    public partial class izmjenaLozinke : Form
    {

        private readonly APIService korisniciService = new APIService("korisnici");

        private readonly APIService kontaktService = new APIService("kontaktPodaci");


        private int? korisnikId;


        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        bool? admin = false;

        public izmjenaLozinke(int? _korisnikId=null,bool? _admin=null)
        {
            korisnikId = _korisnikId;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            admin = _admin;

        }

        private async void snimi_Click(object sender, EventArgs e)
        {
          



            var valid = true;
            var korisnik = new TurAgencijaRS2_Model.Korisnici();
             korisnik = await korisniciService.GetById < TurAgencijaRS2_Model.Korisnici > (korisnikId);

            var request = new KorisniciInsertRequest();


            var kontaktPodaciSvi = await kontaktService.Get<List<TurAgencijaRS2_Model.KontaktPodaci>>(null);


            var kontaktPodatak = new TurAgencijaRS2_Model.KontaktPodaci();

            foreach (var x in kontaktPodaciSvi)
            {
                if (x.KorisnikId == korisnikId)
                    kontaktPodatak = x;
            }


            request.Adresa = korisnik.Adresa;
            request.DatumRodjenja = korisnik.DatumRodjenja;
            request.gradId = korisnik.gradId;
            request.Ime = korisnik.Ime;
            request.Jmbg = korisnik.Jmbg;
            request.KorisnickoIme = korisnik.KorisnickoIme;
            request.Spol = korisnik.Spol;
            request.Prezime = korisnik.Prezime;
            request.Email = kontaktPodatak.Email;
            request.Telefon = kontaktPodatak.Telefon;

            request.Password = lozinkaInput.Text;
            



            if(lozinkaInput.Text!=potvrdaInput.Text)
            {
                valid = false;
                MessageBox.Show("Lozinke se ne slazu ! ");

            }

            if (this.ValidateChildren()&&valid)
            {
              

            await korisniciService.Update < TurAgencijaRS2_Model.Korisnici > (korisnikId, request);

                MessageBox.Show("Lozinka uspjesno izmjenjena");
               if(admin!=null)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();

                    LoginForm login = new LoginForm();

                    login.Closed += (s, args) => this.Close();
                    login.Show();
                }

               



            }
          

        }

        private void lozinkaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lozinkaInput.Text))
            {
                errorProvider.SetError(lozinkaInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(lozinkaInput, null);
            }


            if (lozinkaInput.Text.Length < 3)
            {
                errorProvider.SetError(lozinkaInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }

        }

        private void potvrdaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(potvrdaInput.Text))
            {
                errorProvider.SetError(potvrdaInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(potvrdaInput, null);
            }


            if (potvrdaInput.Text.Length < 3)
            {
                errorProvider.SetError(potvrdaInput, Properties.Resources.Min_char);
                e.Cancel = true;
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

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {

            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
