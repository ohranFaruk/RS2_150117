using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class PrevoznaSredstva
    {
        public PrevoznaSredstva()
        {
            Putovanja = new HashSet<Putovanja>();
        }

        public int PrevoznoSredstvoId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Putovanja> Putovanja { get; set; }
    }
}
