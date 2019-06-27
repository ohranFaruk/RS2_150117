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
   
    public class GradoviController : BaseCRUDController<TurAgencijaRS2_Model.Gradovi,GradoviSearchRequest, GradoviUpsertRequest, GradoviUpsertRequest>
    {

        public GradoviController(ICRUDService<TurAgencijaRS2_Model.Gradovi, GradoviSearchRequest, GradoviUpsertRequest, GradoviUpsertRequest> service):base(service)
        {

        }


    }
}