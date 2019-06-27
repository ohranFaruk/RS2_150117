using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Turisti
    {
        public Turisti()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public string Indeks { get; set; }
        public int KorisnikId { get; set; }
        public int StatusTuristaId { get; set; }
        public int GrupaId { get; set; }

        public virtual Grupe Grupa { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public virtual StatusiTurista StatusTurista { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
