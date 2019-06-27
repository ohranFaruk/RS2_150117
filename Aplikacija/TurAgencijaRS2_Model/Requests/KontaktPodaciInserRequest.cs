using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model.Requests
{
  public  class KontaktPodaciInserRequest
    {
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int KorisnikId { get; set; }
    }
}
