using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Services;

namespace TurAgencijaRS2_WebApi.Controllers
{
   
    public class ZaposleniciController : BaseCRUDController<TurAgencijaRS2_Model.Zaposlenici, object, ZaposleniciUpsertRequest, ZaposleniciUpsertRequest>
    {
        public ZaposleniciController(ICRUDService<TurAgencijaRS2_Model.Zaposlenici, object, ZaposleniciUpsertRequest, ZaposleniciUpsertRequest> service) : base(service)
        {

        }

    }
}