using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurAgencijaRS2_WebApi.Database;

namespace TurAgencijaRS2_WebApi.Services
{
    public class BaseCRUDService<TModel, Tsearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, Tsearch, TDatabase>, ICRUDService<TModel, Tsearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(TuristickaAgencija_RS2Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            db.Set<TDatabase>().Add(entity);
            db.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = db.Set<TDatabase>().Find(id);
            db.Set<TDatabase>().Attach(entity);
            db.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);

            db.SaveChanges();

            return _mapper.Map<TModel>(entity);

        }

        public virtual TModel Delete(int id)
        {
            var entity = db.Set<TDatabase>().Find(id);
            db.Set<TDatabase>().Remove(entity);

            db.SaveChanges();

            return _mapper.Map<TModel>(entity);

        }

    }
}
