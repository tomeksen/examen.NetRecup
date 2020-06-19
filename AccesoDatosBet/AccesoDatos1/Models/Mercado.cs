using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class Mercado
    {
        int idMercado;
        double overUnder;
        double cuotaOver;
        double cuotaUnder;
        double dineroOver;
        double dineroUNder;
        int idPartido;

        public Mercado(int idMercado, double overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUNder, int idPartido)
        {
            this.IdMercado = idMercado;
            this.OverUnder = overUnder;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
            this.DineroOver = dineroOver;
            this.DineroUNder = dineroUNder;
            this.IdPartido = idPartido;
        }

        public int IdMercado { get => idMercado; set => idMercado = value; }
        public double OverUnder { get => overUnder; set => overUnder = value; }
        public double CuotaOver { get => cuotaOver; set => cuotaOver = value; }
        public double CuotaUnder { get => cuotaUnder; set => cuotaUnder = value; }
        public double DineroOver { get => dineroOver; set => dineroOver = value; }
        public double DineroUNder { get => dineroUNder; set => dineroUNder = value; }
        public int IdPartido { get => idPartido; set => idPartido = value; }
    }

    public class MercadoDTO
    {
        double overUnder;
        double cuotaOver;
        double cuotaUnder;

        public MercadoDTO(double overUnder, double cuotaOver, double cuotaUnder)
        {
            this.OverUnder = overUnder;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
        }

        public double OverUnder { get => overUnder; set => overUnder = value; }
        public double CuotaOver { get => cuotaOver; set => cuotaOver = value; }
        public double CuotaUnder { get => cuotaUnder; set => cuotaUnder = value; }
    }
}