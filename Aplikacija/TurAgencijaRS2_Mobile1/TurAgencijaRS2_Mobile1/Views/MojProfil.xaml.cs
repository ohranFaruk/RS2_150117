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
	public partial class MojProfil : ContentPage
	{
        MojProfilViewModel model = null;

        public int _korisnikId { get; set; }
        public MojProfil (int korisnikId)
		{
			InitializeComponent ();
            _korisnikId = korisnikId;

            BindingContext = model = new MojProfilViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_korisnikId);


        }

    }
}