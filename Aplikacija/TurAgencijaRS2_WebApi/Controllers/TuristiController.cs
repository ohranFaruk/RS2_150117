using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Services;

namespace TurAgencijaRS2_WebApi.Controllers
{
   
    public class TuristiController : BaseCRUDController<TurAgencijaRS2_Model.Turisti, object, TuristiInsertRequest, TuristiInsertRequest>
    {
        public TuristiController(ICRUDService<TurAgencijaRS2_Model.Turisti, object, TuristiInsertRequest, TuristiInsertRequest> service) : base(service)
        {

        }

    }
}