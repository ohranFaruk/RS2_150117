using System;
using System.Collections.Generic;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class Putovanja
    {
        public Putovanja()
        {
            PutovanjaGrupe = new HashSet<PutovanjaGrupe>();
            Rezervacije = new HashSet<Rezervacije>();
            Zaduzenja = new HashSet<Zaduzenja>();
        }

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

        public virtual Gradovi Grad { get; set; }
        public virtual Ponude Ponuda { get; set; }
        public virtual PrevoznaSredstva PrevoznoSredstvo { get; set; }
        public virtual ICollection<PutovanjaGrupe> PutovanjaGrupe { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
        public virtual ICollection<Zaduzenja> Zaduzenja { get; set; }
    }
}
