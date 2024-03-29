﻿using System;

using TurAgencijaRS2_Mobile1.Models;

namespace TurAgencijaRS2_Mobile1.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
