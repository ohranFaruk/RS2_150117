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
   
    public class RecenzijeController : BaseCRUDController<TurAgencijaRS2_Model.Recenzije, object, RecenzijeUpsertRequest, RecenzijeUpsertRequest>
    {

        public RecenzijeController(ICRUDService<TurAgencijaRS2_Model.Recenzije, object, RecenzijeUpsertRequest, RecenzijeUpsertRequest> service) : base(service)
        {

        }

    }
}