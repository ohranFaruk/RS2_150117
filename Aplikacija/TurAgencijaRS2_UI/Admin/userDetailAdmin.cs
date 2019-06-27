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
using TurAgencijaRS2_UI.Admin;

namespace TurAgencijaRS2_UI
{
    public partial class userDetailAdmin : Form
    {

        private readonly APIService _service=new APIService("korisnici");
        private readonly APIService gradoviService = new APIService("gradovi");
        private readonly APIService kontaktPodaciService = new APIService("kontaktpodaci");

        private readonly APIService zaposleniciService = new APIService("zaposlenici");

        private readonly APIService turistiService = new APIService("Turisti");
        private bool dragging = false;

        private Point offset;

        private Point start_Point = new Point(0, 0);


        private int? _Id = null;

        public userDetailAdmin(int? korisnikId=null)//null ako je kliknuto dodaj novi korisnik
        {


            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            _Id = korisnikId;


        }


        private async Task LoadGradovi()
        {
            var result = await gradoviService.Get<List<TurAgencijaRS2_Model.Gradovi>>(null);

            result.Insert(0, new TurAgencijaRS2_Model.Gradovi());

            gradovInput.DataSource = result;
            gradovInput.DisplayMember = "Naziv";
            gradovInput.ValueMember = "GradId";

        }



        private async void snimi_Click(object sender, EventArgs e)
        {
            var validacija=true;

            if(!(this.zenskoInput.Checked||muskoInput.Checked))
            {
                MessageBox.Show("Odaberi spol");
                errorProvider.SetError(zenskoInput, null);
                validacija= false;

            }

            if(this.ValidateChildren()&&validacija)
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
                    KorisnickoIme =imeInput.Text.ToLower()+"."+prezimeInput.Text.ToLower(),
                    
                    Adresa = adresaInput.Text,
                    Jmbg = "111",
                   Spol= spolRadio,
                   Password=lozinkaInput.Text,
                   DatumRodjenja=dateTimePicker1.Value,
                   Telefon=telefonInput.Text,
                   Email=emailInput.Text
                  
                 


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



                if (_Id.HasValue)
                {

                    await _service.Update<TurAgencijaRS2_Model.Korisnici>(_Id, request);

                    if (zaposlenikChek.Checked)
                    {
                        var korisniciAll = await _service.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);
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

                        await zaposleniciService.Update<TurAgencijaRS2_Model.Zaposlenici>(_Id,zaposleniciRequest);
                    }


                    MessageBox.Show("Korisnik uspjesno izmijenjen");
                  
                }
                else
                {
                    await _service.Insert<TurAgencijaRS2_Model.Korisnici>(request);

                 

                    if (zaposlenikChek.Checked)
                    {
                        var korisniciAll = await _service.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);
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

                        await zaposleniciService.Insert<TurAgencijaRS2_Model.Zaposlenici>(zaposleniciRequest);
                    }
                    else
                    {
                        // za turista
                        var korisniciAll = await _service.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);

                        var korisnik = new TurAgencijaRS2_Model.Korisnici();
                        foreach (var x in korisniciAll)
                        {
                            if (request.KorisnickoIme == x.KorisnickoIme)
                            {
                                korisnik = x;
                            }

                        }


                        var turistrequest = new TuristiInsertRequest
                        {
                            KorisnikId = korisnik.KorisnikId,
                            GrupaId = 1,
                            Indeks = "TUR" + korisnik.KorisnikId.ToString(),
                            StatusTuristaId = 1
                        };

                        await turistiService.Insert<TurAgencijaRS2_Model.Turisti>(turistrequest);




                    }

                    MessageBox.Show("Korisnik uspjesno dodan");
                }
                this.Close();

           

            }




        }

        private async void userDetailAdmin_Load(object sender, EventArgs e)
        {
            if(_Id.HasValue)
            {
                var korisnik = await _service.GetById<TurAgencijaRS2_Model.Korisnici>(_Id);

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


            }
            else
            {
                await LoadGradovi();
            }
        }

      

      
       

        private void label5_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

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

            if(prezimeInput.Text.Length<3)
            {
                errorProvider.SetError(prezimeInput, Properties.Resources.Min_char);
                e.Cancel = true;
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

        #endregion

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

        private void userDetailAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            start_Point = new Point(e.X, e.Y);
        }

        private void userDetailAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.start_Point.X, p.Y - this.start_Point.Y);
            }
        }

        private void userDetailAdmin_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

        }

     
    }
}
