using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model
{
   public class Ponude
    {
        public int PonudaId { get; set; }
        public string NazivPonude { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool IsAktivna { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
