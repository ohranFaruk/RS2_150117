using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model.Requests
{
  public  class TuristiInsertRequest
    {
        public string Indeks { get; set; }
        public int KorisnikId { get; set; }
        public int StatusTuristaId { get; set; }
        public int GrupaId { get; set; }
    }

}
