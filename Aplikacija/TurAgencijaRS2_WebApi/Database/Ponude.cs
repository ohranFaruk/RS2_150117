using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Ponude
    {
        public Ponude()
        {
            Putovanja = new HashSet<Putovanja>();
        }

        public int PonudaId { get; set; }
        public string NazivPonude { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool IsAktivna { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public virtual ICollection<Putovanja> Putovanja { get; set; }
    }
}
