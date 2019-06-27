﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1.Models
{
  public  class Korisnici
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


        public int gradId { get; set; }

        public string imePrezime { get; set; }
    }
}
