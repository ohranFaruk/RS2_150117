using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1.Models
{
   public class Komentar
    {
        public int RecenzijaId { get; set; }
        public int RezervacijaId { get; set; }
        public string Tekst { get; set; }
        public int? Ocjena { get; set; }
        public DateTime DatumKomentara { get; set; }
    }
}
