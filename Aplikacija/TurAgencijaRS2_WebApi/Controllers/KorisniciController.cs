using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Database;
using TurAgencijaRS2_WebApi.Services;

namespace TurAgencijaRS2_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service)
        {
            _service = service;
        }


       



        [HttpGet]
        public List<TurAgencijaRS2_Model.Korisnici> Get([FromQuery]KorisniciSearchRequest request)
        {


            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public TurAgencijaRS2_Model.Korisnici GetById(int id)
        {


            return _service.GetById(id);
        }

        //[HttpGet("{username}")]
        //public TurAgencijaRS2_Model.Korisnici Get(KorisniciSearchRequest username)
        //{


        //    return _service.Get(username);
        //}



        [HttpPost]
        public TurAgencijaRS2_Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }


        [HttpPut("{id}")]
        public TurAgencijaRS2_Model.Korisnici Update(int id,KorisniciInsertRequest request)
        {
            return _service.Update(id,request);
        }


        [HttpDelete("{id}")]

        public TurAgencijaRS2_Model.Korisnici Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}