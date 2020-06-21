using AccesoDatos1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccesoDatos1.Controllers
{
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventoRepository();
            //List<Evento> eventos = repo.Retrieve();
            List<EventoDTO> eventos = repo.RetrieveDTO();
            return eventos;
        }

        // GET: api/Evento/5
        public Evento Get(int id)
        {
            /* repo = new EventoRepository();
            Evento e = repo.Retrieve();*/
            return null;
        }

        // POST: api/Evento
        public void Post([FromBody]Evento evento)
        {
            var repo = new EventoRepository();
            repo.Save(evento);
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}
