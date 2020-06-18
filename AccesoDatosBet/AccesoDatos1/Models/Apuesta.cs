using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class Apuesta
    {
        int idApuesta;
        int cantidad;
        string tipoCuota;
        int cuotaActual;
        string email;
        int mercado;

        public Apuesta(int idApuesta, int cantidad, string tipoCuota, int cuotaActual, string email, int mercado)
        {
            this.idApuesta = idApuesta;
            this.cantidad = cantidad;
            this.tipoCuota = tipoCuota;
            this.cuotaActual = cuotaActual;
            this.email = email;
            this.mercado = mercado;
        }

        public int IdApuesta { get => idApuesta; set => idApuesta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string TipoCuota { get => tipoCuota; set => tipoCuota = value; }
        public int CuotaActual { get => cuotaActual; set => cuotaActual = value; }
        public string Email { get => email; set => email = value; }
        public int Mercado { get => mercado; set => mercado = value; }
    }
}