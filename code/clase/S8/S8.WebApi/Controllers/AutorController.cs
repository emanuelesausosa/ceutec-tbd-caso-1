using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using S8.Managers.Managers;

namespace S8.WebApi.Controllers
{
    public class AutorController : ApiController
    {
        private AutorManager _autorManager;

        public AutorController()
        {
            _autorManager = new AutorManager();
        }


        [HttpGet]
        public IHttpActionResult getAllAutores()
        {
            var data = _autorManager.GetAllAutores();
            return Ok(data);
        }
    }
}
