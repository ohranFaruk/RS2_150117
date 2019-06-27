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

   
	public partial class Ponude : ContentPage
	{
        PonudeViewModel model = null;

        public int _korisnikId { get; set; }
        public Ponude (int korisnikId)
		{
            _korisnikId = korisnikId;
			InitializeComponent ();
            BindingContext = model = new PonudeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();


        }

        private async void Button1_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            var button = (Button)sender;

            await Navigation.PushAsync(new Putovanja(_korisnikId, Convert.ToInt32(button.BindingContext)));
        }

    }
}