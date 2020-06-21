using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet";
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            return con;
        }

        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetString(4) + " " + res.GetInt32(5));
                    a = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetString(2), res.GetDouble(3), res.GetString(4), res.GetInt32(5));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch(MySqlException e) {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuesta.cantidad, apuesta.tipoCuota, apuesta.cuotaActual, apuesta.email, mercado.overUnder from apuesta LEFT JOIN mercado on apuesta.mercado = mercado.idMercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetDouble(0), res.GetString(1), res.GetDouble(2), res.GetString(3), res.GetString(4));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal List<ApuestaGetQuery> GetInfoApuesta(string correo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT a.cantidad, a.cuotaActual, a.tipoCuota, m.idPartido, m.overUnder FROM apuesta a INNER JOIN mercado m on a.mercado = m.idMercado WHERE a.email=@A";
            command.Parameters.AddWithValue("@A",correo);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaGetQuery a = null;
                List<ApuestaGetQuery> apuestas = new List<ApuestaGetQuery>();
                while (res.Read())
                {
                    a = new ApuestaGetQuery(res.GetDouble(0), res.GetDouble(1), res.GetString(2));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveMercado(int idMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT a.email, m.overUnder, a.tipoCuota, a.cuotaActual, a.cantidad FROM apuesta a INNER JOIN mercado m ON a.mercado=m.idMercado WHERE a.mercado=@A";
            command.Parameters.AddWithValue("@A", idMercado);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetDouble(4), res.GetString(2), res.GetDouble(3), res.GetString(0), res.GetString(1));
                    apuestas.Add(a);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal void Save(Apuesta a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuesta(cantidad, tipoCuota, cuotaActual, email, mercado) values ('" + a.Cantidad + "','" + a.TipoCuota + "','" + a.CuotaActual + "','" + a.Email + "','" + a.Mercado + "');";
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }

            /*-----------------------------------------------------*/

            if (a.TipoCuota.ToUpper() == "OVER")
            {
                command.CommandText = $"UPDATE mercado SET dineroOver =dineroOver+{a.Cantidad} where idMercado={a.Mercado};";
            }
            else
            {
                command.CommandText = $"UPDATE mercado SET dineroUnder =dineroUnder+{a.Cantidad} where idMercado={a.Mercado};";
            }

            Debug.WriteLine("comando " + command.CommandText);
            con.Close();

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine("Error de conexión");
                con.Close();
            }

            command.CommandText = $"SELECT dineroOver, dineroUnder FROM mercado WHERE idMercado={a.Mercado}";

            double dinero_over = 0;
            double dinero_under = 0;
            double cuotaOver;
            double cuotaUnder;

            try
            {
                con.Open();

                MySqlDataReader res = command.ExecuteReader();
                List<Mercado> mercadosLista = new List<Mercado>();

                while (res.Read())
                {
                    Debug.WriteLine(res.GetDouble(0));
                    dinero_over += res.GetDouble(0);
                    dinero_under += res.GetDouble(1);
                }
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine("Error de conexión");
                con.Close();
            }


            if (dinero_over != 0)
            {
                double probabilidadOver = dinero_over / (dinero_over + dinero_under);
                cuotaOver = 1 / probabilidadOver * 0.95;
            }
            else
            {
                cuotaOver = 0;
            }
            if (dinero_under != 0)
            {
                double probabilidadUnder = dinero_under / (dinero_over + dinero_under);
                cuotaUnder = 1 / probabilidadUnder * 0.95;
            }
            else
            {
                cuotaUnder = 0;
            }

            command.CommandText = "UPDATE mercado SET cuotaOver = " +
                cuotaOver + ", cuotaUnder = " + cuotaUnder + "where idMercado=" + a.Mercado + " ;";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine("Error de conexión");
                con.Close();
            }
        }
    }
}