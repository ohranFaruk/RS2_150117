using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Kontinenti
    {
        public Kontinenti()
        {
            Drzave = new HashSet<Drzave>();
        }

        public int KontinentId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Drzave> Drzave { get; set; }
    }
}
