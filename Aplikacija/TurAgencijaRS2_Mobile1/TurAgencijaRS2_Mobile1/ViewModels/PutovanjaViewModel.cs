using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurAgencijaRS2_Mobile1.Models;
using TurAgencijaRS2_Mobile1.Views;
using TurAgencijaRS2_Model;
using Xamarin.Forms;
using Putovanja = TurAgencijaRS2_Mobile1.Views.Putovanja;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
  public  class PutovanjaViewModel:BaseViewModel
    {

      


        private readonly APIService _gradoviService = new APIService("Gradovi");

        private readonly APIService putovanjaService = new APIService("Putovanja");

        private readonly APIService rezervacijeService = new APIService("Rezervacije");

        public int _korisnikId { get; set; }


        public int _ponudaId { get; set; }
        public PutovanjaViewModel()
        {
            InitCommand = new Command(async (object x) => await Init(x));
            InitSaPonudeCommand= new Command(async (object x) => await InitPonude((HelperZaId)(x)));


        }

        public ObservableCollection<TurAgencijaRS2_Mobile1.Models.Putovanje> putovanjaList { get; set; } = new ObservableCollection<TurAgencijaRS2_Mobile1.Models.Putovanje>();

        public ICommand InitCommand { get; set; }

        public ICommand InitSaPonudeCommand { get; set; }

        public ICommand KreirajRezervaciju
        {
            get
            {
                return new Command<int>((x) => NovaRezervacija(x));
            }
        }
        int _putovanjeId = 0;


        public async Task InitPonude(HelperZaId m)
        {
            putovanjaList.Clear();

             _korisnikId = m.korisnikId;

            _ponudaId = Convert.ToInt32(m.ponudaId);

            var listPutovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);

            foreach (var x in listPutovanja)
            {
                if (_ponudaId == x.PonudaId) { 
                var putovanje = new TurAgencijaRS2_Mobile1.Models.Putovanje()
                {
                    PonudaId = x.PonudaId,
                    PutovanjeId = x.PutovanjeId,
                    DatumPolaska = x.DatumPolaska.ToShortDateString(),
                    DatumPovratka = x.DatumPovratka.ToShortDateString(),
                    Cijena = x.Cijena,
                    GradId = x.GradId,
                    Opis = x.Opis,
                    Popust = x.Popust,



                };

                var gradic = await _gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(x.GradId);
                putovanje.grad = gradic.Naziv;
                putovanje.Slika = gradic.Slika;
                putovanjaList.Add(putovanje);

                }
            }
        }


      public async  Task< List<TurAgencijaRS2_Model.Putovanja>> orderbyOcjena(KorisnikRating korisnikRatings)
        {
            List<TurAgencijaRS2_Model.Putovanja> result = new List<TurAgencijaRS2_Model.Putovanja>();


            for (int i = 0; i < korisnikRatings.Ocjene.Count; i++)
            {
                for (int j = i + 1; j < korisnikRatings.Ocjene.Count; j++)
                {
                    if (korisnikRatings.Ocjene[i] < korisnikRatings.Ocjene[j])
                    {
                        var temp = new int();
                        temp = korisnikRatings.Ocjene[i];
                        korisnikRatings.Ocjene[i] = korisnikRatings.Ocjene[j];
                        korisnikRatings.Ocjene[j] = temp;

                        var putovanje = new int();


                        putovanje = korisnikRatings.PutovanjeId[i];
                        korisnikRatings.PutovanjeId[i] = korisnikRatings.PutovanjeId[j];
                        korisnikRatings.PutovanjeId[j] = putovanje;
                    }
                }
            }
            for (int i = 0; i < korisnikRatings.Ocjene.Count; i++)
            {
                var helper = await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(korisnikRatings.PutovanjeId[i]);

                result.Add(helper);
            }

            return result;

           
        }

       

      public   async Task Init(object m)
        {

            _korisnikId = Convert.ToInt32(m);

            putovanjaList.Clear();

            Recommender recommender = new Recommender();
          KorisnikRating korisnikRating=await recommender.GetNearestNeighborsAsync(_korisnikId);



            var listaPutovanjaScore =await orderbyOcjena(korisnikRating);

            var listPutovanja = await putovanjaService.Get<List<TurAgencijaRS2_Model.Putovanja>>(null);

            foreach (var x in listaPutovanjaScore)
            {
                var putovanje = new TurAgencijaRS2_Mobile1.Models.Putovanje()
                {
                    PonudaId = x.PonudaId,
                    PutovanjeId = x.PutovanjeId,
                    DatumPolaska = x.DatumPolaska.ToShortDateString(),
                    DatumPovratka = x.DatumPovratka.ToShortDateString(),
                    Cijena = x.Cijena,
                    GradId = x.GradId,
                    Opis = x.Opis,
                    Popust = x.Popust,



                };

                var gradic = await _gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(x.GradId);
                putovanje.grad = gradic.Naziv;
                putovanje.Slika = gradic.Slika;
                putovanjaList.Add(putovanje);
            }

         
            foreach (var x in listPutovanja)
            {
                var dodano = false;

                foreach (var y in listaPutovanjaScore)
                {
                    if (x.PutovanjeId == y.PutovanjeId)
                    {
                        dodano = true;
                       
                    }
                   
                }

                if(!dodano)
                {
                  
                        var putovanje = new TurAgencijaRS2_Mobile1.Models.Putovanje()
                        {
                            PonudaId = x.PonudaId,
                            PutovanjeId = x.PutovanjeId,
                            DatumPolaska = x.DatumPolaska.ToShortDateString(),
                            DatumPovratka = x.DatumPovratka.ToShortDateString(),
                            Cijena = x.Cijena,
                            GradId = x.GradId,
                            Opis = x.Opis,
                            Popust = x.Popust,



                        };


                        var gradic = await _gradoviService.GetById<TurAgencijaRS2_Model.Gradovi>(x.GradId);
                        putovanje.grad = gradic.Naziv;
                        putovanje.Slika = gradic.Slika;
                        putovanjaList.Add(putovanje);

                }

               

            }

            Console.WriteLine(putovanjaList);
        }

     

        public async void NovaRezervacija(int putovanjeId)
        {

            var putovanje = await putovanjaService.GetById<Putovanje>(putovanjeId);


            var rezervacija = new TurAgencijaRS2_Model.Rezervacije
            {
                DatumRezervacije = DateTime.Now,
                KorisnikId = _korisnikId,
                PutovanjeId = putovanjeId,
                SmjestajId = null,
                StatusRezervacijeId = 1,
                UkupanIznos = putovanje.Cijena
            };

            await rezervacijeService.Insert<TurAgencijaRS2_Model.Rezervacije>(rezervacija);

            await Application.Current.MainPage.DisplayAlert("Čestitke","Rezervacija uspješno dodana", "OK");

        }

    }
}
