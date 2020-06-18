using AccesoDatos1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccesoDatos1.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apuesta/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve();
            return a;
        }

        // POST: api/Apuesta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
