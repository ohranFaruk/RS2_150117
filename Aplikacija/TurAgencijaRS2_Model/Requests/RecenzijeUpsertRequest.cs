using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model.Requests
{
   public class RecenzijeUpsertRequest
    {

        public int RezervacijaId { get; set; }
        public string Komentar { get; set; }
        public int? Ocjena { get; set; }
        public DateTime DatumKomentara { get; set; }
    }
}
