using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class Evento
    {
        int idPartido;
        string equipoLocal;
        string equipoVisitante;
        int goles;

        public Evento(int idPartido, string equipoLocal, string equipoVisitante, int goles)
        {
            this.idPartido = idPartido;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
            this.goles = goles;
        }

        public int IdPartido { get => idPartido; set => idPartido = value; }
        public string EquipoLocal { get => equipoLocal; set => equipoLocal = value; }
        public string EquipoVisitante { get => equipoVisitante; set => equipoVisitante = value; }
        public int Goles { get => goles; set => goles = value; }
    }

    public class EventoDTO {

        string equipoLocal;
        string equipoVisitante;

        public EventoDTO(string equipoLocal, string equipoVisitante)
        {
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
        }

        public string EquipoLocal { get => equipoLocal; set => equipoLocal = value; }
        public string EquipoVisitante { get => equipoVisitante; set => equipoVisitante = value; }
    }
}