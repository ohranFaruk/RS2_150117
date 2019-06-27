using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class PutovanjaGrupe
    {
        public int PutovanjeGrupaId { get; set; }
        public int GrupaId { get; set; }
        public int PutovanjeId { get; set; }
        public DateTime DatumPutovanja { get; set; }
        public int KorisnikId { get; set; }

        public virtual Grupe Grupa { get; set; }
        public virtual Zaposlenici Korisnik { get; set; }
        public virtual Putovanja Putovanje { get; set; }
    }
}
