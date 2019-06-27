using System;
using System.Collections.Generic;
using System.Text;

namespace TurAgencijaRS2_Model
{
  public  class Gradovi
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public int RegijaId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
    }
}
