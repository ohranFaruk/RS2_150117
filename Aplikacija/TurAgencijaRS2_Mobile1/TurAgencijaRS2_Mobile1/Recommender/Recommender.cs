using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TurAgencijaRS2_Mobile1.Models;
using TurAgencijaRS2_Model;

namespace TurAgencijaRS2_Mobile1
{
    public class Recommender
    {

        private readonly APIService turistiService = new APIService("Turisti");

        private readonly APIService korisniciService = new APIService("Korisnici");

        private readonly APIService rezervacijeService = new APIService("Rezervacije");


        private readonly APIService recenzijeService = new APIService("Recenzije");
    
        //vraca sve korisnike i njihove ocjene
        public async Task<KorisnikArticleRatingsTable>  GetAllRatings()
            {

            KorisnikArticleRatingsTable result = new KorisnikArticleRatingsTable();


            #region servisi
            List<Turisti> turisti = await turistiService.Get<List<Turisti>>(null);
            List<Rezervacije> sveRezervacije = await rezervacijeService.Get<List<Rezervacije>>(null);


            List<Recenzije> sveRecenzije = await recenzijeService.Get<List<Recenzije>>(null);

            List<TurAgencijaRS2_Model.Korisnici> korisnici = await korisniciService.Get<List<TurAgencijaRS2_Model.Korisnici>>(null);


            List<TurAgencijaRS2_Model.Korisnici> turistiKorisnici=new List<TurAgencijaRS2_Model.Korisnici>();

           
            //daje sve korisnike koji su turisti
            foreach (var x in korisnici )
            {
                foreach (var y in turisti)
                {
                    if (y.KorisnikId == x.KorisnikId)
                        turistiKorisnici.Add(x);
                }
            }
            #endregion


       


            var tCount = 0;
            var rvCount = 0;


            result.Korisnici = new List<KorisnikRating>();
            foreach (var x in turistiKorisnici)
            {
                KorisnikRating korisnikRating = new KorisnikRating();
                korisnikRating.KorisnikId = x.KorisnikId;
                korisnikRating.PutovanjeId = new List<int>();

                korisnikRating.Ocjene = new List<int>();
                foreach (var rv in sveRezervacije)
                {
                    if (rv.KorisnikId == x.KorisnikId)
                    {
                       


                        foreach (var rc in sveRecenzije)
                        {
                            if(rc.RezervacijaId==rv.RezervacijaId)
                            {
                                korisnikRating.Ocjene.Add( rc.Ocjena ?? default (int));
                                korisnikRating.PutovanjeId.Add(rv.PutovanjeId);
                                
                             




                            }
                         
                            rvCount++;
                        }


                     
                    }
                }
                result.Korisnici.Add(korisnikRating);




            }

            return result;



        }

     public async Task<KorisnikRating> GetKorisnikRating(int korisnikId)
        {
            KorisnikRating korisnikRating = new KorisnikRating();

            korisnikRating.KorisnikId = korisnikId;
            korisnikRating.Ocjene = new List<int>();
            korisnikRating.PutovanjeId = new List<int>();

            List<Rezervacije> sveRezervacije = await rezervacijeService.Get<List<Rezervacije>>(null);


            List<Recenzije> sveRecenzije = await recenzijeService.Get<List<Recenzije>>(null);

            foreach (var x in sveRezervacije)
            {
                if(x.KorisnikId==korisnikRating.KorisnikId)
                {
                  

                    foreach (var y in sveRecenzije)
                    {
                        if(y.RezervacijaId==x.RezervacijaId)
                        {
                            korisnikRating.PutovanjeId.Add(x.PutovanjeId);
                            korisnikRating.Ocjene.Add(y.Ocjena ?? default (int));
                        }
                    }
                }
            }

            return korisnikRating;


        }

        public async Task< KorisnikRating> GetNearestNeighborsAsync(int korisnikId)
        {
            var tajKorisnik = 0;

            KorisnikRating user = await GetKorisnikRating(korisnikId);

            List<KorisnikRating> neighbors = new List<KorisnikRating>();
            CorrelationUserComparer comparer = new CorrelationUserComparer();

            

           KorisnikArticleRatingsTable ratings = await GetAllRatings();

            for (int i = 0; i < ratings.Korisnici.Count; i++)
            {
                if (ratings.Korisnici[i].KorisnikId == user.KorisnikId)
                {

                    tajKorisnik = i;

                    ratings.Korisnici[i].Score = double.NegativeInfinity;
                }
                else
                {
                    ratings.Korisnici[i].Score =
                        comparer.CompareVectors(getZajednickeOcjene(ratings.Korisnici[i],user),getZajednickeOcjene( user,ratings.Korisnici[i]));
                }
            }

            ratings.Korisnici.RemoveAt(tajKorisnik);

            var result = sortDescendingScore(ratings.Korisnici);

            return (result[0]);

        }

        public List<int> getZajednickeOcjene(KorisnikRating korisnikRating,KorisnikRating logirani)
        {
            List<int> result = new List<int>();


            for (int i = 0; i < logirani.PutovanjeId.Count; i++)
            {
                for (int j = 0; j < korisnikRating.PutovanjeId.Count; j++)
                {
                    if(logirani.PutovanjeId[i]==korisnikRating.PutovanjeId[j])
                    {
                        result.Add(korisnikRating.Ocjene[j]);
                        break;
                    }
                }
            }

            return result;
        }



        public List<KorisnikRating> sortDescendingScore(List<KorisnikRating> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i+1; j < list.Count; j++)
                {
                    if(list[i].Score<list[j].Score)
                    {
                        var temp = new KorisnikRating();
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }


            return list;
        }

     



    }
}
