using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurAgencijaRS2_WebApi.Services
{
  public  interface ICRUDService<T, TSearch,TInsert,TUpdate> : IService<T,TSearch> //zato sto i krud podrzava get i getById
    {
        T Insert(TInsert request);

        T Update(int Id, TUpdate request);


        T Delete(int Id);

    }
}
