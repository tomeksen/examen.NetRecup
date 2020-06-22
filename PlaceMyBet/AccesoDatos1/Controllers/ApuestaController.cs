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
        //[Route("api/ApuestaExamen")]
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }

        //GET: api/Apuesta?correo=correo
        [Authorize(Roles = "Admin")]
        public IEnumerable<ApuestaGetQuery> GetInfoApuesta(string correo)
        {
            var repo = new ApuestaRepository();
            List<ApuestaGetQuery> apuestas = repo.GetInfoApuesta(correo);
            return apuestas;
        }

        [Authorize(Roles ="Admin")]
        public IEnumerable<ApuestaDTO> GetMercado(int idMercado)
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveMercado(idMercado);
            return apuestas;
        }

        // GET: api/Apuesta/5
        public Apuesta Get(int id)
        {
            /*var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve();*/
            return null;
        }

        // POST: api/Apuesta
        [Authorize]
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);
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
