using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurAgencijaRS2_WebApi.Services
{
  public  interface IGradoviService
    {

        List<TurAgencijaRS2_Model.Gradovi> Get();


        TurAgencijaRS2_Model.Gradovi GetById(int id);


    }
}
