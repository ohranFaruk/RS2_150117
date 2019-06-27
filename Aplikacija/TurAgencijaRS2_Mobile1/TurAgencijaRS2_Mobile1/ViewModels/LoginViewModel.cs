using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurAgencijaRS2_Mobile1.Models;
using TurAgencijaRS2_Mobile1.Views;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
 public   class LoginViewModel:BaseViewModel
    {

        private readonly APIService service = new APIService("Regije");

        private readonly APIService korisniciService = new APIService("Korisnici");

        public int korisnikId { get; set; }


        public LoginViewModel()
        {

            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(()=> Register());

        }



        string _username = string.Empty;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }


        string _password = string.Empty;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        async Task Login()
        {
            IsBusy = true;

            APIService.Username = Username;
            APIService.Password = Password;

            var sviKorisnici = await korisniciService.Get<List<Korisnici>>(null);

            var korisnik = new Korisnici();

            foreach (var x in sviKorisnici)
            {
                if (x.KorisnickoIme == Username)
                    korisnikId = x.KorisnikId;
            }
            try
            {
                if (validacija()) { 
                    await service.Get<dynamic>(null);

             
                Application.Current.MainPage = new MainPage(korisnikId);
                }
            }
            catch (Exception ex)
            {

               
            }



        }
        void Register()
        {
            Application.Current.MainPage = new Registracija();
        }

        public bool validacija()
        {
            var valid = true;

            if(Username=="")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Korisnicko ime je obavezno ! ", "OK");
                return valid = false;
            }

            if (Password == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Password  je obavezan ! ", "OK");
                return valid = false;
            }

            return valid;
        }
    }


    
}
