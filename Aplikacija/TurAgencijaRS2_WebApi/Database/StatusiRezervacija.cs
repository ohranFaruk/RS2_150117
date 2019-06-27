using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class StatusiRezervacija
    {
        public StatusiRezervacija()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int StatusRezervacijeId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
