using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurAgencijaRS2_Model.Requests;

namespace TurAgencijaRS2_UI.Zaposlenik
{
   
    public partial class mainZaposlenik : Form
    {
        #region konstruktor
        private int? _Id;

        


        private readonly APIService korisniciService = new APIService("korisnici");

        private readonly APIService gradoviService = new APIService("gradovi");

        private readonly APIService kontaktService = new APIService("kontaktpodaci");


        public mainZaposlenik(int? Id=null)
        {
            _Id = Id;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

      
        private  async void mainZaposlenik_Load(object sender, EventArgs e)
        {
            var korisnik = await korisniciService.GetById<TurAgencijaRS2_Model.Korisnici>(_Id);

            imeInput.Text = korisnik.Ime;
            prezimeInput.Text = korisnik.Prezime;
         
            adresaInput.Text = korisnik.Adresa;
            dateTimePicker1.Value = korisnik.DatumRodjenja;


            if(korisnik.Spol=="M")
            {
                muskoInput.Checked = true;
            }
            else
            {
                zenskoInput.Checked = true;
            }


            var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(korisnik.gradId);


            var result = await gradoviService.Get<List<TurAgencijaRS2_Model.Gradovi>>(null);

            result.Insert(0, new TurAgencijaRS2_Model.Gradovi());

            result[0].Naziv = grad.Naziv;
            result[0].GradId = grad.GradId;

            gradovInput.DataSource = result;
            gradovInput.DisplayMember = "Naziv";
            gradovInput.ValueMember = "GradId";

            var kontaktPodaci = await kontaktService.Get<List<TurAgencijaRS2_Model.KontaktPodaci>>(null);

            var kontaktPodatak = new TurAgencijaRS2_Model.KontaktPodaci();

            for (int i = 0; i < kontaktPodaci.Count; i++)
            {
                if (kontaktPodaci[i].KorisnikId == korisnik.KorisnikId)
                    kontaktPodatak = kontaktPodaci[i];
            }


            emailInput.Text = kontaktPodatak.Email;
            telefonInput.Text = kontaktPodatak.Telefon;

            //var kontaktPodaci = await kontaktService.Get<List<TurAgencijaRS2_Model.KontaktPodaci>>(null);
            //var kontaktPodatak = new TurAgencijaRS2_Model.KontaktPodaci();
            //foreach (var x in kontaktPodaci)
            //{
            //    if (x.KorisnikId == korisnik.KorisnikId)
            //        kontaktPodatak = x;

            //}

            //emailInput.Text = kontaktPodatak.Email;
            //telefonInput.Text = kontaktPodatak.Telefon;



        }
        #endregion

        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);
        private async void snimi_Click(object sender, EventArgs e)
        {


            var validacija = true;

            if (!(this.zenskoInput.Checked || muskoInput.Checked))
            {
                MessageBox.Show("Odaberi spol");
                errorProvider.SetError(zenskoInput, null);
                validacija = false;

            }


            if (this.ValidateChildren()&&validacija)
            {
                //za radio button 
                string spolRadio = null;
                foreach (Control control in this.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radio = control as RadioButton;
                        if (radio.Checked)
                        {
                            spolRadio = radio.Text;
                        }
                    }
                }

                var request = new KorisniciInsertRequest()
                {

                    Ime = imeInput.Text,
                    Prezime = prezimeInput.Text,
                    KorisnickoIme = imeInput.Text.ToLower() + "." + prezimeInput.Text.ToLower(),

                    Adresa = adresaInput.Text,
                    Jmbg = "111",
                    Spol = spolRadio,
                
                    DatumRodjenja = dateTimePicker1.Value,
                    Telefon = telefonInput.Text,
                    Email = emailInput.Text


                };

                var idObj = gradovInput.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int GradId))//ako je ispravno selektovano dobijemo id parametar
                {
                    request.gradId = GradId;
                }


                await korisniciService.Update<TurAgencijaRS2_Model.Korisnici>(_Id, request);

                
                MessageBox.Show("Podaci uspjesno  izmijenjeni");
                mainZaposlenik_Load(null,e);

            }
        }



        #region  logika

        private void label5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            zaduzenjaZaposlenik zaduzenjaZaposlenik = new zaduzenjaZaposlenik(_Id);

            zaduzenjaZaposlenik.Closed += (s, args) => this.Close();
            zaduzenjaZaposlenik.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region validacija
        private void imeInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imeInput.Text))
            {
                errorProvider.SetError(imeInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(imeInput, null);
            }

            if (imeInput.Text.Length < 3)
            {
                errorProvider.SetError(imeInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }

        }

        private void prezimeInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(prezimeInput.Text))
            {
                errorProvider.SetError(prezimeInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(prezimeInput, null);
            }

            if (prezimeInput.Text.Length < 3)
            {
                errorProvider.SetError(prezimeInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }

        }

       

        private void gradovInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gradovInput.Text))
            {
                errorProvider.SetError(gradovInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(gradovInput, null);
            }
        }

        private void adresaInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(adresaInput.Text))
            {
                errorProvider.SetError(adresaInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(adresaInput, null);
            }

            if (adresaInput.Text.Length < 3)
            {
                errorProvider.SetError(adresaInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }

        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                errorProvider.SetError(dateTimePicker1, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dateTimePicker1, null);
            }
        }

        private void telefonInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(telefonInput.Text))
            {
                errorProvider.SetError(telefonInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(telefonInput, null);
            }

            if (telefonInput.Text.Length < 3)
            {
                errorProvider.SetError(telefonInput, Properties.Resources.Min_char);
                e.Cancel = true;
            }

            if (!Regex.IsMatch(telefonInput.Text, "^[0-9]*$"))
            {
                errorProvider.SetError(telefonInput, "Dozvoljeni samo brojevi");
                e.Cancel = true;
            }


        }

        private void emailInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailInput.Text))
            {
                errorProvider.SetError(emailInput, Properties.Resources.Validation_Mandatory);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(emailInput, null);
            }
        }








        #endregion

        private void mainZaposlenik_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void mainZaposlenik_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void mainZaposlenik_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void IzmjenaLozinke_Click(object sender, EventArgs e)
        {
            this.Hide();

            izmjenaLozinke izmjenaLozinke = new izmjenaLozinke(_Id);

            izmjenaLozinke.Closed += (s, args) => this.Close();
            izmjenaLozinke.Show();
        }
    }
}
