using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurAgencijaRS2_Mobile1.Models;
using TurAgencijaRS2_Mobile1.Views;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_Model.Requests;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1.ViewModels
{


   


  public  class RegistracijaViewModel:BaseViewModel
    {
        private readonly APIService korisniciService = new APIService("korisnici");

        private readonly GradoviService gradoviService = new GradoviService("gradovi");


        private readonly KorisniciService korisniciInsert = new KorisniciService("korisnici");


        private readonly TuristiService turistiInsert = new TuristiService("Turisti");


        public List<SpolPickerHelper> spol { get; set; }

        public ObservableCollection<GradoviPickerHelper> gradoviList { get; set; } = new ObservableCollection<GradoviPickerHelper>();

        public RegistracijaViewModel()
        {
            SubmitCommand = new Command(async () => await Submit());

            InitCommand = new Command(async () => await Init());

            spol = getSpol();

            
        }
        public ICommand InitCommand { get; set; }

        GradoviPickerHelper _selectedGrad = null;
        public GradoviPickerHelper SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);


            }
        }



        SpolPickerHelper _selectedSpol = null;
        public SpolPickerHelper SelectedSpol
        {
            get { return _selectedSpol; }
            set
            {
                SetProperty(ref _selectedSpol, value);


            }
        }


        #region Forma
        string _ime = string.Empty;

        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }


        string _prezime = string.Empty;

        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        string _spol = string.Empty;

        public string Spol
        {
            get { return _spol; }
            set { SetProperty(ref _spol, value); }
        }


        string _adresa = string.Empty;

        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        string _password = string.Empty;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        string _telefon = string.Empty;

        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }


        string _email = string.Empty;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        DateTime _datumRodjenja = DateTime.Now;

        public DateTime datumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }
        #endregion


        public ICommand SubmitCommand { get; set; }

        public async Task Init()
        {
            var sviGradovi = await gradoviService.Get<List<Gradovi>>(null);

            var counter = 0;
            gradoviList.Clear();
            foreach (var x in sviGradovi)
            {
                counter++;
                gradoviList.Add(new GradoviPickerHelper() { Key = counter, Id = x.GradId, naziv = x.Naziv });
            }
        }

            public async Task Submit()
        {
            if (validacija()) {
              
                    Models.KorisniciInsertRequest request = new Models.KorisniciInsertRequest
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        KorisnickoIme = Ime.ToLower() + "." + Prezime.ToLower(),
                        Password = Password,
                        Adresa = Adresa,
                        gradId = SelectedGrad.Id,
                        Spol = SelectedSpol.Value,
                        Jmbg = "1111111111111",
                        Telefon = Telefon,
                        Email = Email,
                        DatumRodjenja = datumRodjenja

                    };


                    var sviKorisnici = await korisniciService.Get<List<Models.Korisnici>>(null);
                    var kIme = false;

                    foreach (var x in sviKorisnici)
                    {
                        if(request.KorisnickoIme==x.KorisnickoIme)
                        {
                            kIme = true;
                        }
                    }

                    if(!kIme)
                    { 
                    await korisniciInsert.Insert<Models.KorisniciInsertRequest>(request);
                 
                    var korisniciTuristi= await korisniciService.Get<List<Models.Korisnici>>(null);
                    foreach (var x in korisniciTuristi)
                    {
                        if (x.KorisnickoIme == request.KorisnickoIme)
                        {
                            var turistiInsertrequest = new TuristiInsertRequest
                            {
                                KorisnikId = x.KorisnikId,
                                GrupaId = 1,
                                Indeks = "TUR" + x.KorisnikId.ToString(),
                                StatusTuristaId = 1
                            };

                            await turistiInsert.Insert<TuristiInsertRequest>(turistiInsertrequest);


                        }
                    }

                    await Application.Current.MainPage.DisplayAlert("Čestitke", "Uspješno ste se registrovali", "OK");
                    Application.Current.MainPage = new LoginPage();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Pozor", "Ime i prezime već postoje ! ", "OK");
                    }
                
              
                
            }
        }

        private bool validacija()
        {
            var valid = true;

            if (Ime == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Ime  je obavezno ! ", "OK");
                return valid = false;
            }

            if (Prezime == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Prezime  je obavezno ! ", "OK");
                return valid = false;
            }

            if (Email == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Email  je obavezan ! ", "OK");
                return valid = false;
            }



            if (Telefon == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Telefon  je obavezan ! ", "OK");
                return valid = false;
            }
            if (Password == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Password  je obavezan ! ", "OK");
                return valid = false;
            }

            if (SelectedGrad == null)
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Grad  je obavezan ! ", "OK");
                return valid = false;
            }


            if (SelectedSpol == null)
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Polje spol  je obavezno ! ", "OK");
                return valid = false;
            }

            if (Adresa == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Adresa  je obavezna ! ", "OK");
                return valid = false;
            }

           
        

        



        


            return valid;
        }

        public List<SpolPickerHelper> getSpol()
        {
            var spol = new List<SpolPickerHelper>
            {
                new SpolPickerHelper{Key=1,Value="M"},

                new SpolPickerHelper{Key=2,Value="Z"},
            };

            return spol;
        }


    }
}
