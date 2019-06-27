using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Smjestaji
    {
        public Smjestaji()
        {
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int SmjestajId { get; set; }
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int BrojZvjezdica { get; set; }
        public decimal CijenaNoc { get; set; }
        public string Opis { get; set; }
        public string WebStranica { get; set; }
        public bool IsAktivan { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public virtual Gradovi Grad { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
