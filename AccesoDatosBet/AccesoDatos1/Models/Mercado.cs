using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class Mercado
    {
        int idMercado;
        int overUnder;
        int cuotaOver;
        int cuotaUnder;
        int dineroOver;
        int dineroUNder;

        public Mercado(int idMercado, int overUnder, int cuotaOver, int cuotaUnder, int dineroOver, int dineroUNder)
        {
            this.idMercado = idMercado;
            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUNder = dineroUNder;
        }

        public int IdMercado { get => idMercado; set => idMercado = value; }
        public int OverUnder { get => overUnder; set => overUnder = value; }
        public int CuotaOver { get => cuotaOver; set => cuotaOver = value; }
        public int CuotaUnder { get => cuotaUnder; set => cuotaUnder = value; }
        public int DineroOver { get => dineroOver; set => dineroOver = value; }
        public int DineroUNder { get => dineroUNder; set => dineroUNder = value; }
    }
}