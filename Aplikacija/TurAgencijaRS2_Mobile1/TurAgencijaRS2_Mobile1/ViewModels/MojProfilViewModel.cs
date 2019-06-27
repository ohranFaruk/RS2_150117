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
using Korisnici = TurAgencijaRS2_Model.Korisnici;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
    public class MojProfilViewModel:BaseViewModel
    {

        private readonly APIService korisniciService = new APIService("korisnici");
        private readonly APIService kontaktService = new APIService("kontaktpodaci");


        private readonly APIService gradoviService = new APIService("gradovi");

        public int korisnikId { get; set; }

        public List<SpolPickerHelper> spol { get; set; }

      



        public ObservableCollection<GradoviPickerHelper> gradoviList { get; set; } = new ObservableCollection<GradoviPickerHelper>();


        public   MojProfilViewModel()


        {

            SubmitCommand = new Command(async () => await Submit());


            InitCommand = new Command(async (object x) => await Init(x));


            //rec.GetAllRatings();




        }

       

        public ICommand InitCommand { get; set; }

        public ICommand SubmitCommand { get; set; }



       


        GradoviPickerHelper _selectedGrad = null;
        public GradoviPickerHelper SelectedGrad 
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
               

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


     public    async Task Init(object m)
        {

         
            var sviGradovi = await gradoviService.Get<List<Gradovi>>(null);
         
            var counter = 0;
            gradoviList.Clear();
            foreach (var x in sviGradovi)
            {
                counter++;
                gradoviList.Add(new GradoviPickerHelper() { Key = counter, Id = x.GradId, naziv = x.Naziv });
            }


            korisnikId = Convert.ToInt32(m);


         


            var korisnik = await korisniciService.GetById<Korisnici>(korisnikId);




            var kontakt = await kontaktService.GetById<TurAgencijaRS2_Model.KontaktPodaci>(korisnikId);

            Ime = korisnik.Ime;
            Prezime = korisnik.Prezime;
            Spol = korisnik.Spol;
            Adresa = korisnik.Adresa;
            datumRodjenja = korisnik.DatumRodjenja;
            Telefon = kontakt.Telefon;
            Email = kontakt.Email;

            
        }

        


      

      

      public   async Task Submit()
        {
            if (validacija()) { 
          var  korisnik=await korisniciService.GetById<Korisnici>(korisnikId);

             

            Models.KorisniciInsertRequest request = new Models.KorisniciInsertRequest
            {
                Ime = Ime,
                Prezime = Prezime,
                Spol = korisnik.Spol,
                Adresa = Adresa,
                DatumRodjenja = datumRodjenja,
                Password = Password,
                Email = Email,
                Telefon = Telefon,
                Jmbg = "111",
                KorisnickoIme = Ime.ToLower() +"." +Prezime.ToLower(),
                gradId = SelectedGrad.Id

            };




            await korisniciService.Update<Models.KorisniciInsertRequest>(korisnikId, request);

           
            await Application.Current.MainPage.DisplayAlert("Pozor", "Podaci uspjesno izmijenjeni", "OK");

                Application.Current.MainPage = new LoginPage();
            }

        }


        public bool validacija()
        {
            var valid = true;

            if (Ime == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Ime ime je obavezno ! ", "OK");
                return valid = false;
            }

            if (Prezime == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Prezime  je obavezano ! ", "OK");
                return valid = false;
            }

            if (Adresa == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Adresa  je obavezna ! ", "OK");
                return valid = false;
            }

            if (Spol == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Polje spol  je obavezno ! ", "OK");
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



            return valid;
        }


    }
}
