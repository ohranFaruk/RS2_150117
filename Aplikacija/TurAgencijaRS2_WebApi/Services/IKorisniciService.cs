using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Database;

namespace TurAgencijaRS2_WebApi.Services
{
  public  interface IKorisniciService
    {
        List<TurAgencijaRS2_Model.Korisnici> Get(KorisniciSearchRequest request);



        TurAgencijaRS2_Model.Korisnici GetById(int id);


        TurAgencijaRS2_Model.Korisnici Insert(KorisniciInsertRequest request);


        TurAgencijaRS2_Model.Korisnici Update(int Id,KorisniciInsertRequest request);

        TurAgencijaRS2_Model.Korisnici Delete(int Id);
        TurAgencijaRS2_Model.Korisnici Authenticiraj(string username, string pass);

    }
}
