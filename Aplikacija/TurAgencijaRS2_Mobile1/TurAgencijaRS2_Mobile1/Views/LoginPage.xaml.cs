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
	public partial class LoginPage : ContentPage
	{

        LoginViewModel model = null;
        public LoginPage ()
		{
          
			InitializeComponent ();
            BindingContext = model = new LoginViewModel();
        }

      

    
    }
}