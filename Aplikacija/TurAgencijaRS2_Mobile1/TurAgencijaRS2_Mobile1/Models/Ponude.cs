using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TurAgencijaRS2_Mobile1.Models
{
   public class Ponude
    {

        public int PonudaId { get; set; }
        public string NazivPonude { get; set; }
        public string DatumPocetka { get; set; }
        public string DatumZavrsetka { get; set; }
        public bool IsAktivna { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public byte[] Slika { get; set; }

        public int brojPutovanja { get; set; }
    }
}
