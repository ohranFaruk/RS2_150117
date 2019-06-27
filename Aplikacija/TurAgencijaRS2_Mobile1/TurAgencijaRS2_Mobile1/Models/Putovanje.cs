using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1.Models
{
    public class Putovanje
    {
        public int PutovanjeId { get; set; }
        public int GradId { get; set; }
      
        public int? PonudaId { get; set; }
        public string DatumPolaska { get; set; }
        public string DatumPovratka { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }

        public byte[] Slika { get; set; }


        public string grad { get; set; }
    }
}
