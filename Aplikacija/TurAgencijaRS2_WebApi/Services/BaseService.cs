using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurAgencijaRS2_WebApi.Database;

namespace TurAgencijaRS2_WebApi.Services
{
    public class BaseService<TModel, Tsearch,TDatabase> : IService<TModel, Tsearch> where TDatabase:class
    {


        protected readonly TuristickaAgencija_RS2Context db;
        protected readonly IMapper _mapper;

        public BaseService(TuristickaAgencija_RS2Context turistickaAgencija_RS2Context, IMapper mapper)
        {
            db = turistickaAgencija_RS2Context;
            _mapper = mapper;
        }

        public virtual List<TModel> Get(Tsearch search)
        {

            var list = db.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = db.Set<TDatabase>().Find(id);

            return _mapper.Map<TModel>(entity);

        }
    }
}
