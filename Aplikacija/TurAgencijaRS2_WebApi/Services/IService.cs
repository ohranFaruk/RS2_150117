using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurAgencijaRS2_WebApi.Services
{
   public interface IService<T, TSearch>
    {

        List<T> Get(TSearch search);


        T GetById(int id);

   
    }
}
