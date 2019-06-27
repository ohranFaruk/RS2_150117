using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class KontaktPodaci
    {
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int KorisnikId { get; set; }

        public virtual Korisnici Korisnik { get; set; }
    }
}
