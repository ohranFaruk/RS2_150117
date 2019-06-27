using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurAgencijaRS2_Mobile1.Models;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_Model.Requests;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
   public class KomentarViewModel:BaseViewModel
    {

        public int rezervacijaId { get; set; }
        public List<PickerHelper> Ocjene { get; set; }
      
      


        private readonly APIService putovanjaService = new APIService("Putovanja");

        private readonly APIService rezervacijeService = new APIService("Rezervacije");

        private readonly APIService recenzijeService = new APIService("Recenzije");

        private readonly APIService gradoviService = new APIService("Gradovi");

        public KomentarViewModel()
        {
            InitCommand = new Command(async (object x) => await Init(x));
            SubmitCommand = new Command(async () => await Submit());

            Ocjene = GetValues();
        }


        string _komentar = string.Empty;

        public string Komentar
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }


        string _naziv = string.Empty;

        public string Naziv
        {
            get { return _naziv; }
            set { SetProperty(ref _naziv, value); }
        }


        private PickerHelper _selectedOcjena =null; 
        public PickerHelper SelectedOcjena
        {
            get
            {
                return _selectedOcjena;
            }
            set
            {
                SetProperty(ref _selectedOcjena, value);
                //put here your code  

            }
        }




      public ICommand InitCommand { get; set; }


        public ICommand SubmitCommand { get; set; }

        public  async Task Init(object m)
        {
            
            rezervacijaId = Convert.ToInt32(m);

            var rezervacija = await rezervacijeService.GetById<Rezervacije>(rezervacijaId);

            var putovanje = await putovanjaService.GetById<Putovanje>(rezervacija.PutovanjeId);

            var sviGradovi = await putovanjaService.Get<List<Gradovi>>(null);

           
            
                foreach (var x in sviGradovi )
                {
                if (x.GradId == putovanje.GradId)
                {
                   
                   var put = await gradoviService.GetById<Gradovi>(x.GradId);
                    Naziv = put.Naziv;
                }
                }

          

        }

        public static List<PickerHelper> GetValues()
        {
            var value = new List<PickerHelper>()
            {
                new PickerHelper(){Key=1, Value="1"},

                new PickerHelper(){Key=2, Value="2"},

                new PickerHelper(){Key=3, Value="3"},

                new PickerHelper(){Key=4, Value="4"},

                new PickerHelper(){Key=5, Value="5"},
            };
            return value;
        }

        public async Task Submit()
        {

            if(validacija())
            { 
            RecenzijeUpsertRequest request = new RecenzijeUpsertRequest
            {
                RezervacijaId = rezervacijaId,
                DatumKomentara = DateTime.Now,
                Ocjena = Convert.ToInt32(SelectedOcjena.Value),
                Komentar = Komentar
            };

            await recenzijeService.Insert<Recenzije>(request);
          await  Application.Current.MainPage.DisplayAlert("Pozor", "Komentar uspješno snimljen", "OK");
            }
        }

        public bool validacija()
        {
            var valid = true;

            if (Komentar == "")
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Komentar je obavezan ! ", "OK");
                return valid = false;
            }

            if (SelectedOcjena == null)
            {
                Application.Current.MainPage.DisplayAlert("Pozor", "Ocjena je obavezna ! ", "OK");
                return valid = false;
            }

            return valid;

        }



    }
}
