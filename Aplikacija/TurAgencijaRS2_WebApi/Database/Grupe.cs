using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Grupe
    {
        public Grupe()
        {
            PutovanjaGrupe = new HashSet<PutovanjaGrupe>();
            Turisti = new HashSet<Turisti>();
        }

        public int GrupaId { get; set; }
        public string NazivGrupe { get; set; }
        public int MaxBrojTurisa { get; set; }

        public virtual ICollection<PutovanjaGrupe> PutovanjaGrupe { get; set; }
        public virtual ICollection<Turisti> Turisti { get; set; }
    }
}
