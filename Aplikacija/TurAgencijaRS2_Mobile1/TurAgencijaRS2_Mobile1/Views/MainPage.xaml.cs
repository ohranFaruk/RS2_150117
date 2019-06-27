using TurAgencijaRS2_Mobile1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

namespace TurAgencijaRS2_Mobile1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();


        public int korisnikId { get; set; }

        public MainPage(int _korisnikId)
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
            korisnikId = _korisnikId;
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                   

                   

                    case (int)MenuItemType.MojProfil:
                        MenuPages.Add(id, new NavigationPage(new MojProfil(korisnikId)));
                        break;

                    case (int)MenuItemType.Ponude:
                        MenuPages.Add(id, new NavigationPage(new Ponude(korisnikId)));
                        break;


                    case (int)MenuItemType.Putovanja:
                        MenuPages.Add(id, new NavigationPage(new Putovanja(korisnikId)));
                        break;


                    case (int)MenuItemType.Rezervacije:
                        MenuPages.Add(id, new NavigationPage(new Rezervacije(korisnikId)));
                        break;

                    case (int)MenuItemType.Logout:
                        // CoreApplication.Exit();
                        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}