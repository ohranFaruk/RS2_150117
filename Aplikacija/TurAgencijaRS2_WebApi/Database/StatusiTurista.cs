using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class StatusiTurista
    {
        public StatusiTurista()
        {
            Turisti = new HashSet<Turisti>();
        }

        public int StatusTuristaId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Turisti> Turisti { get; set; }
    }
}
