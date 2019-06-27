using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Zaduzenja
    {
        public int ZaduzenjeId { get; set; }
        public int PutovanjeId { get; set; }
        public int ZaposlenikId { get; set; }
        public bool Odgodjeno { get; set; }
        public string Opis { get; set; }
        public bool NaCekanju { get; set; }

        public virtual Putovanja Putovanje { get; set; }
        public virtual Zaposlenici Zaposlenik { get; set; }
    }
}
