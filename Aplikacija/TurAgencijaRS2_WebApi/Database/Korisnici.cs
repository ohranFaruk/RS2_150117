using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Korisnici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Spol { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int GradId { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public virtual Gradovi Grad { get; set; }
        public virtual KontaktPodaci KontaktPodaci { get; set; }
        public virtual Turisti Turisti { get; set; }
        public virtual Zaposlenici Zaposlenici { get; set; }
    }
}
