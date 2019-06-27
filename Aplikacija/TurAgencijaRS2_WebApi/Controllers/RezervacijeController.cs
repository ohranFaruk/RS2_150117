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
   
    public class RezervacijeController : BaseCRUDController<TurAgencijaRS2_Model.Rezervacije, object, RecenzijeUpsertrequest, RecenzijeUpsertrequest>
    {
        public RezervacijeController(ICRUDService<TurAgencijaRS2_Model.Rezervacije, object, RecenzijeUpsertrequest, RecenzijeUpsertrequest> service) : base(service)
        {

        }

    }
}