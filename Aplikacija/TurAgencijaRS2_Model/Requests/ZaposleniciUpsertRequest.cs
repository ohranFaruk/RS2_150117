using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model.Requests
{
   public class ZaposleniciUpsertRequest
    {

        public DateTime DatumZaposljavanja { get; set; }
        public int MjeseciIskustva { get; set; }
        public bool IsVodic { get; set; }
        public int KorisnikId { get; set; }
        public int? StatusVodicaId { get; set; }

    }
}
