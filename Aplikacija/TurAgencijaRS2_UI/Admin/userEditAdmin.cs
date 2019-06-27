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

namespace TurAgencijaRS2_UI.Admin
{
    public partial class userEditAdmin : Form
    {

        private readonly APIService _service = new APIService("korisnici");
        private readonly APIService gradoviService = new APIService("gradovi");
        private readonly APIService kontaktPodaciService = new APIService("kontaktpodaci");

        private readonly APIService zaposleniciService = new APIService("zaposlenici");

        private readonly APIService turistiService = new APIService("Turisti");

        private readonly APIService rezervacijeService = new APIService("Rezervacije");


        private readonly APIService recenzijeService = new APIService("Recenzije");


        private readonly APIService zaduzenjaService = new APIService("Zaduzenja");


        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);

        private int korisnikId;
        public userEditAdmin(int _korisnikId)
        {
            korisnikId = _korisnikId;
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private  async void userEditAdmin_Load(object sender, EventArgs e)
        {
            var korisnik = await _service.GetById<TurAgencijaRS2_Model.Korisnici>(korisnikId);

            imeInput.Text = korisnik.Ime;
            prezimeInput.Text = korisnik.Prezime;

            adresaInput.Text = korisnik.Adresa;
            dateTimePicker1.Value = korisnik.DatumRodjenja;




            var grad = await gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(korisnik.gradId);


            var result = await gradoviService.Get<List<TurAgencijaRS2_Model.Gradovi>>(null);

            result.Insert(0, new TurAgencijaRS2_Model.Gradovi());

            result[0].Naziv = grad.Naziv;
            result[0].GradId = grad.GradId;

            gradovInput.DataSource = result;
            gradovInput.DisplayMember = "Naziv";
            gradovInput.ValueMember = "GradId";

            var kontaktPodatak = new TurAgencijaRS2_Model.KontaktPodaci();

            var kontaktPodaci = await kontaktPodaciService.Get<List<TurAgencijaRS2_Model.KontaktPodaci>>(null);

            foreach (var x in kontaktPodaci)
            {
                if (x.KorisnikId == korisnikId)
                    kontaktPodatak = x;
            }

            emailInput.Text = kontaktPodatak.Email;
            telefonInput.Text = kontaktPodatak.Telefon;


            var zaposlenik = new TurAgencijaRS2_Model.Zaposlenici();
            var zaposlenici = await zaposleniciService.Get<List<TurAgencijaRS2_Model.Zaposlenici>>(null);

            foreach (var x in zaposlenici)
            {
                if (x.KorisnikId == korisnikId)
                    zaposlenik = x;

            }

            if(zaposlenik.KorisnikId!=0)
            {
                if (zaposlenik.IsVodic)
                    vodicChek.Checked = true;
                zaposlenikChek.Checked = true;
            }
            if (korisnik.Spol == "M")
            {
                muskoInput.Checked = true;
            }
            else
            {
                zenskoInput.Checked = true;
            }
        }

        private async void obrisiBtn_Click(object sender, EventArgs e)
        {
           

            var sviTuristi = await turistiService.Get<List<TurAgencijaRS2_Model.Turisti>>(null);

            //biranje rezervacija i recenzija,ako je turist
            foreach (var x in sviTuristi)
            {
                if (x.KorisnikId == korisnikId)
                {
                    var sveRezervacije = await rezervacijeService.Get<List<TurAgencijaRS2_Model.Rezervacije>>(null);

                    foreach (var y in sveRezervacije)
                    {
                        if (y.KorisnikId == korisnikId)
                        {
                            var sveRecenzije = await recenzijeService.Get<List<TurAgencijaRS2_Model.Recenzije>>(null);
                            foreach (var z in sveRecenzije)
                            {
                                if (z.RezervacijaId == y.RezervacijaId)
                                    await recenzijeService.Delete<TurAgencijaRS2_Model.Recenzije>(z.RecenzijaId);
                            }
                            await rezervacijeService.Delete<TurAgencijaRS2_Model.Rezervacije>(y.RezervacijaId);
                        }
                    }

                    await turistiService.Delete<TurAgencijaRS2_Model.Turisti>(x.KorisnikId);
                }
            }

            var sviZaposlenici = await zaposleniciService.Get<List<TurAgencijaRS2_Model.Zaposlenici>>(null);

            var svaZaduzenja = await zaduzenjaService.Get<List<TurAgencijaRS2_Model.Zaduzenja>>(null);

            //brisanje zaposlenika

            foreach (var x in sviZaposlenici)
            {
                if(x.KorisnikId==korisnikId)
                {
                    foreach (var y in svaZaduzenja)
                    {
                        if (y.ZaposlenikId == korisnikId)
                            await zaduzenjaService.Delete<TurAgencijaRS2_Model.Zaduzenja>(y.ZaduzenjeId);
                    }

                  await  zaposleniciService.Delete<TurAgencijaRS2_Model.Zaposlenici>(korisnikId);
                }
            }
        
            var result = await _service.Delete<TurAgencijaRS2_Model.Korisnici>(korisnikId);

            MessageBox.Show("Korisnik uspjesno obrisan");
            this.Close();
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

        private void userEditAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void userEditAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }

        }

        private void userEditAdmin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void izmjenaLozinke_Click(object sender, EventArgs e)
        {
            this.Hide();

            izmjenaLozinke izmjenaLozinke = new izmjenaLozinke(korisnikId,true);

            izmjenaLozinke.Closed += (s, args) => this.Close();
            izmjenaLozinke.Show();
        }

        private async void snimi_Click(object sender, EventArgs e)
        {
            var validacija = true;

            if (!(this.zenskoInput.Checked || muskoInput.Checked))
            {
                MessageBox.Show("Odaberi spol");
                errorProvider.SetError(zenskoInput, null);
                validacija = false;

            }


            if (this.ValidateChildren() && validacija)
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
                var zaposleniciRequest = new ZaposleniciUpsertRequest()
                {
                    MjeseciIskustva = 11,
                    DatumZaposljavanja = DateTime.Now,
                    StatusVodicaId = 1

                };


                var idObj = gradovInput.SelectedValue;

                if (int.TryParse(idObj.ToString(), out int GradId))//ako je ispravno selektovano dobijemo id parametar
                {
                    request.gradId = GradId;
                }



             
                    await _service.Update<TurAgencijaRS2_Model.Korisnici>(korisnikId, request);

                    if (zaposlenikChek.Checked)
                    {
                        var korisniciAll = await _service.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);

                    var zaposleniciAll = await zaposleniciService.Get<List<TurAgencijaRS2_Model.Zaposlenici>>(null);
                    var zaposlenik = new TurAgencijaRS2_Model.Zaposlenici();

                    foreach (var x in zaposleniciAll)
                    {
                        if (korisnikId == x.KorisnikId)
                            zaposlenik = x;
                    }


                    if(zaposlenik.KorisnikId==0)
                    {
                        zaposleniciRequest.KorisnikId = korisnikId;
                        
                        await zaposleniciService.Insert<TurAgencijaRS2_Model.Zaposlenici>(zaposleniciRequest);
                    }

                    if (vodicChek.Checked)
                        {
                            zaposleniciRequest.IsVodic = true;
                        }
                        else zaposleniciRequest.IsVodic = false;

                    

                    var korisnik = new TurAgencijaRS2_Model.Korisnici();
                        foreach (var x in korisniciAll)
                        {
                            if (request.KorisnickoIme == x.KorisnickoIme)
                            {
                                korisnik = x;
                            }

                        }

                        zaposleniciRequest.KorisnikId = korisnik.KorisnikId;

                        await zaposleniciService.Update<TurAgencijaRS2_Model.Zaposlenici>(korisnikId, zaposleniciRequest);
                    }


                    MessageBox.Show("Podaci uspjesno izmijenjeni");

                this.Close();

            }
            



            }

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

            if (emailInput.Text.Length < 3)
            {
                errorProvider.SetError(emailInput, Properties.Resources.Min_char);
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
    }
}
