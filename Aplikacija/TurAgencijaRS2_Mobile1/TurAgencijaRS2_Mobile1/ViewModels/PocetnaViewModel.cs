using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
    public   class PocetnaViewModel:BaseViewModel
    {

       
        public PocetnaViewModel()
        {
            InitCommand = new Command(async (object x) => await Init(x));
        }

        public ICommand InitCommand { get; set; }



        int _korisnikId = 0;

        public int KorisnikId
        {
            get { return _korisnikId; }
            set { SetProperty(ref _korisnikId, value); }
        }


        public async Task Init(object _korisnikId)
        {
            KorisnikId = Convert.ToInt32( _korisnikId);
            
        }
    }
}
