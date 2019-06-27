using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model
{
  public  class Zaduzenja
    {

        public int ZaduzenjeId { get; set; }
        public int PutovanjeId { get; set; }
        public int ZaposlenikId { get; set; }
        public bool Odgodjeno { get; set; }
        public string Opis { get; set; }
        public bool NaCekanju { get; set; }


    }

}
