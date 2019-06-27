using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Database;
using Gradovi = TurAgencijaRS2_WebApi.Database.Gradovi;

namespace TurAgencijaRS2_WebApi.Services
{
    public class GradoviService : BaseCRUDService<TurAgencijaRS2_Model.Gradovi,GradoviSearchRequest,Gradovi,GradoviUpsertRequest,GradoviUpsertRequest>
    {

        public GradoviService(TuristickaAgencija_RS2Context context,IMapper mapper):base(context,mapper)
        {

        }

        public override List<TurAgencijaRS2_Model.Gradovi> Get(GradoviSearchRequest search)
        {

            //filtriranje po regiji

            var query = db.Set<Gradovi>().AsQueryable();

            if(search?.RegijaId.HasValue==true)
            {
                query = query.Where(x => x.RegijaId == search.RegijaId);
            }
            query = query.OrderBy(x => x.Naziv);

            var list = query.ToList();

            return _mapper.Map <List<TurAgencijaRS2_Model.Gradovi >> (list);

        }
    }
}
