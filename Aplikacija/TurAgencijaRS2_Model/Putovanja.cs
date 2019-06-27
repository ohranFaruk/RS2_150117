using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model
{
   public class Putovanja
    {

        public int PutovanjeId { get; set; }
        public int GradId { get; set; }
        public int? PrevoznoSredstvoId { get; set; }
        public int? PonudaId { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }
        public bool Aktivno { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string grad { get; set; }
    }
}
