using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_Model.Requests;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
 public   class GradoviViewModel:BaseViewModel
    {
        private readonly APIService _gradoviService = new APIService("Gradovi");

        private readonly APIService regijeService = new APIService("regije");
        public GradoviViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Gradovi> gradoviList { get; set; } = new ObservableCollection<Gradovi>();

        public ObservableCollection<Regije> regijeList { get; set; } = new ObservableCollection<Regije>();

        int _korisnikId = 0;
        public int KorisnikId
        {
            get { return _korisnikId; }
            set { SetProperty(ref _korisnikId, value); }
        }


        Regije _selectedRegije = null;
        public Regije SelectedRegija
        {
            get { return _selectedRegije; }
            set { SetProperty(ref _selectedRegije, value);
                if(value!=null)
                InitCommand.Execute(null);

            }
        }


        public ICommand InitCommand { get; set; }


      public  async Task Init()
        {

            if(regijeList.Count==0)
            { 
            var listRegije = await regijeService.Get<IEnumerable<Regije>>(null);

            foreach (var x in listRegije)
            {
                regijeList.Add(x);
            }

            }
            if (SelectedRegija != null)
            {
                GradoviSearchRequest searchRequest = new GradoviSearchRequest();
                searchRequest.RegijaId = SelectedRegija.RegijaId;
                var listGradovi = await _gradoviService.Get<IEnumerable<Gradovi>>(searchRequest);
                gradoviList.Clear();

                foreach (var x in listGradovi)
                {
                    gradoviList.Add(x);
                }
            }

          
        }





    }
}
