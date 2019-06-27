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

    public class PutovanjaController : BaseCRUDController<TurAgencijaRS2_Model.Putovanja, object,RezervacijeUpsertRequests,RezervacijeUpsertRequests>
    {
        public PutovanjaController(ICRUDService<TurAgencijaRS2_Model.Putovanja, object,RezervacijeUpsertRequests,RezervacijeUpsertRequests> service) : base(service)
        {

        }


      

    }
}