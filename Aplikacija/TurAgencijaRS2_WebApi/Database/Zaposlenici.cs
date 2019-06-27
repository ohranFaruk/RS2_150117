using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Zaposlenici
    {
        public Zaposlenici()
        {
            PutovanjaGrupe = new HashSet<PutovanjaGrupe>();
            Zaduzenja = new HashSet<Zaduzenja>();
        }

   
        public DateTime DatumZaposljavanja { get; set; }
        public int MjeseciIskustva { get; set; }
        public bool IsVodic { get; set; }
        public int KorisnikId { get; set; }
        public int? StatusVodicaId { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        public virtual StatusiVodica StatusVodica { get; set; }
        public virtual ICollection<PutovanjaGrupe> PutovanjaGrupe { get; set; }
        public virtual ICollection<Zaduzenja> Zaduzenja { get; set; }
    }
}
