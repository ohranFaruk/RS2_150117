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
	public partial class Komentar : ContentPage
	{

       KomentarViewModel model = null;
        private int _rezervacijaId { get; set; }
        public Komentar (int rezervacijaId)
		{
            _rezervacijaId = rezervacijaId;
			InitializeComponent ();

            BindingContext = model = new KomentarViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_rezervacijaId);


        }
    }
}