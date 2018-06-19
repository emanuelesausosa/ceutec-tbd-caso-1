using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TBD.imdb.Managers.Factories;

namespace TBD.imdb.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private AutorFactory _autorFactory;

        public ValuesController()
        {
            _autorFactory = new AutorFactory();
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            var data = _autorFactory.ObtenerTodosActores();
            return Ok(data);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [Route("autores")]
        public IHttpActionResult getAllAutors()
        {
            var data = _autorFactory.ObtenerTodosActores();
            return Ok(data);
        }
    }
}
