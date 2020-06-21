using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class EventoRepository
    {
        private MySqlConnection Connect() {
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet";
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            return con;
        }

        internal List<Evento> Retrieve() {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Evento e = null;
                List<Evento> eventos = new List<Evento>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                    eventos.Add(e);
                }

                con.Close();
                return eventos;
            }
            catch(MySqlException e) {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal void Save(Mercado mercado)
        {
            throw new NotImplementedException();
        }

        internal List<EventoDTO> RetrieveDTO()
        {

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();

                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetString(1) + " " + res.GetString(2));
                    e = new EventoDTO(res.GetString(1), res.GetString(2));
                    eventos.Add(e);
                }

                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }

        internal void Save(Evento e)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into partido(equipoLocal, equipoVisitante, goles) values ('" + e.EquipoLocal + "','" + e.EquipoVisitante + "','" + e.Goles + "');";
            Debug.WriteLine("comando "+command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException o) {
                Debug.WriteLine("Se ha producido un error de conexión");
            }
        }
    }
}