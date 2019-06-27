using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurAgencijaRS2_WebApi.Services;

namespace TurAgencijaRS2_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TSearch> : ControllerBase
    {
        private readonly IService<T,TSearch> _service;
        public BaseController(IService<T,TSearch> service)
        {
            _service = service;
        }


        [HttpGet]

        public List<T> Get([FromQuery]TSearch search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]

        public T GetById(int id)
        {
            return _service.GetById(id);
        }



    }
}