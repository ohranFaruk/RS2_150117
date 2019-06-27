using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1.Models
{
  public  class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public string Putovanje { get; set; }
        public string DatumR { get; set; }
        public decimal iznos { get; set; }
    }
}
