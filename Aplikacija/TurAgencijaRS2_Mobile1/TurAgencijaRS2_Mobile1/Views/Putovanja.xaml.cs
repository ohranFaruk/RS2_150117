using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurAgencijaRS2_Mobile1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TurAgencijaRS2_Mobile1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]


    public class HelperZaId
    {
        public int korisnikId { get; set; }

        public int ponudaId { get; set; }
    }

    public partial class Putovanja : ContentPage
	{

        PutovanjaViewModel model = null;

        public int _korisnikId { get; set; }
        public int? _ponudaId { get; set; }

        public Putovanja (int korisnikId,int? ponudaId=null)
		{
            _korisnikId = korisnikId;
            _ponudaId = ponudaId;

          

            InitializeComponent ();
            BindingContext = model = new PutovanjaViewModel();
        }

        protected async override void OnAppearing()
        {

            HelperZaId helperZaId = new HelperZaId
            {
                korisnikId = _korisnikId,
                ponudaId = _ponudaId ?? default(int)
            };

            base.OnAppearing();

            if(_ponudaId!=null)
            {
                await model.InitPonude(helperZaId);
            }else 
             await model.Init(_korisnikId);


        }

       
    }
}