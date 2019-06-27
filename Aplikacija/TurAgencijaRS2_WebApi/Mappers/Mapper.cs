using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurAgencijaRS2_Model.Requests;

namespace TurAgencijaRS2_WebApi.Mappers
{
    public class Mapper:Profile
    {

        public Mapper()
        {

            CreateMap<Database.Korisnici, TurAgencijaRS2_Model.Korisnici>();

     

            CreateMap<Database.Korisnici, KorisniciInsertRequest>().ReverseMap();


        

            CreateMap<Database.Regije, TurAgencijaRS2_Model.Regije>();


            CreateMap<Database.Gradovi, TurAgencijaRS2_Model.Gradovi>();


            CreateMap<Database.Gradovi, GradoviUpsertRequest>().ReverseMap();



            CreateMap<Database.Putovanja, TurAgencijaRS2_Model.Putovanja>();

            CreateMap<Database.Putovanja, RezervacijeUpsertRequests>().ReverseMap();





            CreateMap<Database.Ponude, TurAgencijaRS2_Model.Ponude>();

            CreateMap<Database.Ponude, PonudeUpsertRequest>().ReverseMap();


            CreateMap<Database.Zaduzenja, TurAgencijaRS2_Model.Zaduzenja>();

            CreateMap<Database.Zaduzenja, ZaduzenjaUpsertRequest>().ReverseMap();

            CreateMap<Database.Recenzije, TurAgencijaRS2_Model.Recenzije>();

            CreateMap<Database.Recenzije, RecenzijeUpsertRequest>().ReverseMap();


            CreateMap<Database.Rezervacije, TurAgencijaRS2_Model.Rezervacije>();

            CreateMap<Database.Rezervacije, RecenzijeUpsertrequest>().ReverseMap();


            CreateMap<Database.Zaposlenici, TurAgencijaRS2_Model.Zaposlenici>();

            CreateMap<Database.Zaposlenici, ZaposleniciUpsertRequest>().ReverseMap();


            CreateMap<Database.KontaktPodaci, TurAgencijaRS2_Model.KontaktPodaci>();

            CreateMap<Database.KontaktPodaci, KontaktPodaciInserRequest>().ReverseMap();


            CreateMap<Database.Turisti, TurAgencijaRS2_Model.Turisti>();

            CreateMap<Database.Turisti, TuristiInsertRequest>().ReverseMap();




        }

    }
}
