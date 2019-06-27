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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Komentar = TurAgencijaRS2_Mobile1.Views.Komentar;
using Rezervacije = TurAgencijaRS2_Model.Rezervacije;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
   public class RezervacijeViewModel:BaseViewModel
    {


        private readonly APIService rezervacijeService = new APIService("Rezervacije");
        private readonly APIService putovanjaService = new APIService("Putovanja");

        private readonly APIService gradoviService = new APIService("Gradovi");


        private readonly APIService recenzijeService = new APIService("Recenzije");
        public int korisnikId { get; set; }
        public RezervacijeViewModel()
        {
            InitCommand = new Command(async (object x) => await Init(x));


        }

        public ICommand InitCommand { get; set; }

        public ICommand ObrisiRezervaciju
        {
            get
            {
                return new Command<int>((x) => BrisanjeRezervacije(x));
            }
        }


        //public ICommand Komentiraj
        //{
        //    get
        //    {
        //        return new Command<int>((x) => Komentar(x));
        //    }
        //}


        public ObservableCollection<Rezervacija> rezervacijeList { get; set; } = new ObservableCollection<Rezervacija>();

        public async Task Init(object m)
        {
            korisnikId = Convert.ToInt32(m);
            var listRezervacije = await rezervacijeService.Get<IEnumerable<TurAgencijaRS2_Model.Rezervacije>>(null);

        

            rezervacijeList.Clear();

            foreach (var x in listRezervacije)
            {
                if(x.KorisnikId==korisnikId)
                {
                    var rez = new Rezervacija();
                    rez.DatumR = x.DatumRezervacije.ToShortDateString();
                    rez.iznos = x.UkupanIznos;
                    rez.RezervacijaId = x.RezervacijaId;
                    rez.Putovanje = await getNazivPutovanja(x.PutovanjeId);
                    rezervacijeList.Add(rez);
                }

            
            }

        }

        public async Task<string> getNazivPutovanja(int putovanjeId)
        {
            var svaPutovanja =await putovanjaService.GetById<TurAgencijaRS2_Model.Putovanja>(putovanjeId);

            var gradovi = await gradoviService.GetById<Gradovi>(svaPutovanja.GradId);

            return gradovi.Naziv;

        }

        public async void BrisanjeRezervacije(int rezervacijaId)
        {
          
            var sveRecenzije = await recenzijeService.Get < List <Recenzije>> (null);
            var recenzijaHelp = new TurAgencijaRS2_Model.Recenzije();
            foreach (var x in sveRecenzije )
            {
                if(x.RezervacijaId==rezervacijaId)
                {

                    recenzijaHelp = x;
                }
            }
            if(recenzijaHelp.RecenzijaId!=0)
            await recenzijeService.Delete<Recenzije>(recenzijaHelp.RecenzijaId);

         
            await rezervacijeService.Delete<Rezervacije>(rezervacijaId);
          await  Application.Current.MainPage.DisplayAlert("Pozor", "Rezervacija otkazana", "OK");
         await   Init(korisnikId);
        }

        //public  void Komentar(int rezervacijaId)
        //{
        //    //  Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();


        //    //  MenuPages.Add(4, new NavigationPage(new Komentar(rezervacijaId)));
         
        //    MasterDetailPage fpm = new MasterDetailPage
        //    {
        //        Master = new MenuPage(),
        //        Detail = new NavigationPage(new Komentar(rezervacijaId))
        //    };
        //    Application.Current.MainPage = fpm;


        //    //   Application.Current.MainPage = new NavigationPage(new Komentar(rezervacijaId));
        //}
    }
}
