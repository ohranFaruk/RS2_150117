using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Recenzije
    {
        public int RecenzijaId { get; set; }
        public int RezervacijaId { get; set; }
        public string Komentar { get; set; }
        public int? Ocjena { get; set; }
        public DateTime DatumKomentara { get; set; }

        public virtual Rezervacije Rezervacija { get; set; }
    }
}
