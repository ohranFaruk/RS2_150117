using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurAgencijaRS2_Model;
using TurAgencijaRS2_WebApi.Services;

namespace TurAgencijaRS2_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegijeController : BaseController<TurAgencijaRS2_Model.Regije,object>
    {
       public RegijeController(IService<Regije,object> service):base(service)
        {

        }

    }
}