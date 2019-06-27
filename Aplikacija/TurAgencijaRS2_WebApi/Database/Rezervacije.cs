using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Rezervacije
    {
        public Rezervacije()
        {
            Recenzije = new HashSet<Recenzije>();
        }

        public int RezervacijaId { get; set; }
        public int PutovanjeId { get; set; }
        public decimal UkupanIznos { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int StatusRezervacijeId { get; set; }
        public int? SmjestajId { get; set; }
        public int KorisnikId { get; set; }

        public virtual Turisti Korisnik { get; set; }
        public virtual Putovanja Putovanje { get; set; }
        public virtual Smjestaji Smjestaj { get; set; }
        public virtual StatusiRezervacija StatusRezervacije { get; set; }
        public virtual ICollection<Recenzije> Recenzije { get; set; }
    }
}
