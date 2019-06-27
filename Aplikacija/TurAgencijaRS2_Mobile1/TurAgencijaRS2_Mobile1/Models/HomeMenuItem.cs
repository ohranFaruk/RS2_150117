using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Gradovi,
        MojProfil,
        Ponude,
        Putovanja,
        Rezervacije,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string ImageSource { get; set; }
    }
}
