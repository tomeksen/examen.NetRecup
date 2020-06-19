using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class Apuesta
    {
        int idApuesta;
        double cantidad;
        string tipoCuota;
        double cuotaActual;
        string email;
        int mercado;

        public Apuesta(int idApuesta, double cantidad, string tipoCuota, double cuotaActual, string email, int mercado)
        {
            this.IdApuesta = idApuesta;
            this.Cantidad = cantidad;
            this.TipoCuota = tipoCuota;
            this.CuotaActual = cuotaActual;
            this.Email = email;
            this.Mercado = mercado;
        }

        public int IdApuesta { get => idApuesta; set => idApuesta = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public string TipoCuota { get => tipoCuota; set => tipoCuota = value; }
        public double CuotaActual { get => cuotaActual; set => cuotaActual = value; }
        public string Email { get => email; set => email = value; }
        public int Mercado { get => mercado; set => mercado = value; }
    }

    public class ApuestaDTO {
        double cantidad;
        string tipoCuota;
        double cuotaActual;
        string email;
        string overUnder;

        public ApuestaDTO(double cantidad, string tipoCuota, double cuotaActual, string email, string overUnder)
        {
            this.Cantidad = cantidad;
            this.TipoCuota = tipoCuota;
            this.CuotaActual = cuotaActual; 
            this.Email = email;
            this.OverUnder = overUnder;
        }

        public double Cantidad { get => cantidad; set => cantidad = value; }
        public string TipoCuota { get => tipoCuota; set => tipoCuota = value; }
        public double CuotaActual { get => cuotaActual; set => cuotaActual = value; }
        public string Email { get => email; set => email = value; }
        public string OverUnder { get => overUnder; set => overUnder = value; }
    }

    public class ApuestaGetQuery {
        double cantidad;
        double cuotaActual;
        string tipoCuota;

        public ApuestaGetQuery(double cantidad, double cuotaActual, string tipoCuota)
        {
            this.Cantidad = cantidad;
            this.CuotaActual = cuotaActual;
            this.TipoCuota = tipoCuota;
        }

        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double CuotaActual { get => cuotaActual; set => cuotaActual = value; }
        public string TipoCuota { get => tipoCuota; set => tipoCuota = value; }
    }
}