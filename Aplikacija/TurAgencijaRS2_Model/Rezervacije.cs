using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model
{
  public  class Rezervacije
    {
        public int RezervacijaId { get; set; }
        public int PutovanjeId { get; set; }
        public decimal UkupanIznos { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int StatusRezervacijeId { get; set; }
        public int? SmjestajId { get; set; }
        public int KorisnikId { get; set; }

    }
}
