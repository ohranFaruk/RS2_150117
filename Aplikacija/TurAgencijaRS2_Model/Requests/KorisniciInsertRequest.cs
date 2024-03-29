﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TurAgencijaRS2_Model.Requests
{
  public  class KorisniciInsertRequest
    {

        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Jmbg { get; set; }
    
        public string Spol { get; set; }
        public string Adresa { get; set; }
        public string KorisnickoIme { get; set; }
      

        public string Password { get; set; }
     

        public int gradId { get; set; }


        public DateTime DatumRodjenja { get; set; }


        public string Telefon { get; set; }

        public string Email { get; set; }



    }
}
