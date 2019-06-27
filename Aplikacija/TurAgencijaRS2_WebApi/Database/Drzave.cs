using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Drzave
    {
        public Drzave()
        {
            Regije = new HashSet<Regije>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public int KontinentId { get; set; }

        public virtual Kontinenti Kontinent { get; set; }
        public virtual ICollection<Regije> Regije { get; set; }
    }
}
