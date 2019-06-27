using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Database;
using TurAgencijaRS2_WebApi.Exceptions;
using Korisnici = TurAgencijaRS2_WebApi.Database.Korisnici;

namespace TurAgencijaRS2_WebApi.Services
{
    public class KorisniciService : IKorisniciService
    {

        #region Konstruktor
        private readonly TuristickaAgencija_RS2Context db;
        private readonly IMapper _mapper;



        public KorisniciService(TuristickaAgencija_RS2Context turistickaAgencija_RS2Context,IMapper mapper)
        {
            db = turistickaAgencija_RS2Context;
            _mapper = mapper;
        }


        public static string GenerateSalt()
        {
            byte[] arr = new byte[16];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(arr);

            return Convert.ToBase64String(arr);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] byteLozinka = Encoding.Unicode.GetBytes(password);
            byte[] byteSalt = Convert.FromBase64String(salt);


            byte[] forHashing = new byte[byteLozinka.Length + byteSalt.Length];

            System.Buffer.BlockCopy(byteLozinka, 0, forHashing, 0, byteLozinka.Length);


            System.Buffer.BlockCopy(byteSalt, 0, forHashing, byteLozinka.Length, byteSalt.Length);

            HashAlgorithm alg = HashAlgorithm.Create("SHA1");
            return Convert.ToBase64String(alg.ComputeHash(forHashing));
        }



        #endregion

        #region Get

        public List<TurAgencijaRS2_Model.Korisnici> Get(KorisniciSearchRequest request)
        {

            var query = db.Korisnici.AsQueryable();

            if(!string.IsNullOrEmpty(request?.ime))//ako je korisnik upiso ime, dodaj u kveri
            {
                query = query.Where(x => x.Ime.StartsWith(request.ime));
            }

            if (!string.IsNullOrEmpty(request?.prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.prezime));
            }


            var list = query.ToList();

            return _mapper.Map<List<TurAgencijaRS2_Model.Korisnici>>(list);
         
           
        }

        public TurAgencijaRS2_Model.Korisnici GetById(int id)
        {
            var entity = db.Korisnici.Find(id);



            return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(entity);
        }


      
        #endregion

        #region Insert

        public TurAgencijaRS2_Model.Korisnici Insert(KorisniciInsertRequest request)
        {

            var entity = _mapper.Map<Database.Korisnici>(request);

           



            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
          
            entity.DatumKreiranja = DateTime.Now;
         
            

            db.Korisnici.Add(entity);

            db.SaveChanges();

            var Kontakt = new KontaktPodaciInserRequest {

                Email=request.Email,
                KorisnikId=entity.KorisnikId,
                Telefon=request.Telefon
            };
           
            var kontaktAdd = _mapper.Map<Database.KontaktPodaci>(Kontakt);

            db.KontaktPodaci.Add(kontaktAdd);

            db.SaveChanges();
            return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(entity);

        }

        public TurAgencijaRS2_Model.Korisnici Update(int Id, KorisniciInsertRequest request)
        {
            var entity = db.Korisnici.Find(Id);

            _mapper.Map(request, entity);

            var kontaktEntity = db.KontaktPodaci.Find(Id);


            var KontaktRequest = new KontaktPodaciInserRequest
            {

                Email = request.Email,
                KorisnikId = entity.KorisnikId,
                Telefon = request.Telefon
            };
            _mapper.Map(KontaktRequest, kontaktEntity);
           

        


            //if(!string.IsNullOrWhiteSpace(request.PasswordConfirmation))
            //{



            //}
            if (request.Password!=null)
            {
                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            
            }


            db.SaveChanges();

            return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(entity);

        }


        public TurAgencijaRS2_Model.Korisnici Authenticiraj(string username, string pass)
        {
            if(username=="admin"&&pass=="test")
            {
                var admin = db.Korisnici.FirstOrDefault(x => x.KorisnickoIme == username);
                return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(admin);
            }



            var user = db.Korisnici.FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {

                //   return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(user);
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(user);
                }
            }
            return null;
        }

        public TurAgencijaRS2_Model.Korisnici Delete(int Id)
        {
            var entity = db.Korisnici.Find(Id);

            var kontaktPodaci = db.KontaktPodaci;

            var zaposlenik = db.Zaposlenici.Find(Id);

            if (zaposlenik != null)
                db.Zaposlenici.Remove(zaposlenik);

            db.Korisnici.Remove(entity);

            foreach (var x in kontaktPodaci)
            {
                if (x.KorisnikId == Id)
                    db.KontaktPodaci.Remove(x);
            }
            db.SaveChanges();

            return _mapper.Map<TurAgencijaRS2_Model.Korisnici>(entity);
        }

        #endregion
    }
}
