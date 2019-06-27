using TurAgencijaRS2_Mobile1.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Windows.UI.Xaml.Controls;

namespace TurAgencijaRS2_Mobile1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
               
               
                   new HomeMenuItem {Id = MenuItemType.MojProfil, Title="Moj profil", ImageSource="profile.png" },
                    new HomeMenuItem {Id = MenuItemType.Ponude, Title="Ponude" , ImageSource="ponuda.png"},
                    new HomeMenuItem {Id = MenuItemType.Putovanja, Title="Putovanja", ImageSource="turizam.png" },
                    new HomeMenuItem {Id = MenuItemType.Rezervacije, Title="Rezervacije", ImageSource="rezervacija.PNG"  },
                    
                      new HomeMenuItem {Id = MenuItemType.Logout, Title="Logout", ImageSource="logout.PNG"  }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}