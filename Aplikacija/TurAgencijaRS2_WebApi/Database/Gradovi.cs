using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Gradovi
    {
        public Gradovi()
        {
            Korisnici = new HashSet<Korisnici>();
            Putovanja = new HashSet<Putovanja>();
            Smjestaji = new HashSet<Smjestaji>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int RegijaId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public virtual Regije Regija { get; set; }
        public virtual ICollection<Korisnici> Korisnici { get; set; }
        public virtual ICollection<Putovanja> Putovanja { get; set; }
        public virtual ICollection<Smjestaji> Smjestaji { get; set; }
    }
}
