using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Mobile1.Models
{
 public   class KorisnikRating
    {

        public int KorisnikId { get; set; }

        public List<int> PutovanjeId { get; set; }

        public List<int> Ocjene { get; set; }
        public double Score { get; set; }

    }
}
