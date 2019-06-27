using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model
{
   public class Recenzije
    {
        public int RecenzijaId { get; set; }
        public int RezervacijaId { get; set; }
        public string Komentar { get; set; }
        public int? Ocjena { get; set; }
        public DateTime DatumKomentara { get; set; }
    }
}
