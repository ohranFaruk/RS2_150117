using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class StatusiVodica
    {
        public StatusiVodica()
        {
            Zaposlenici = new HashSet<Zaposlenici>();
        }

        public int StatusVodicaId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Zaposlenici> Zaposlenici { get; set; }
    }
}
