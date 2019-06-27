using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Regije
    {
        public Regije()
        {
            Gradovi = new HashSet<Gradovi>();
        }

        public int RegijaId { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzave Drzava { get; set; }
        public virtual ICollection<Gradovi> Gradovi { get; set; }
    }
}
