using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model.Requests
{
  public  class ZaduzenjaUpsertRequest
    {

     
        public int PutovanjeId { get; set; }
        public int ZaposlenikId { get; set; }
        public bool Odgodjeno { get; set; }
        public string Opis { get; set; }
        public bool NaCekanju { get; set; }


    }
}
