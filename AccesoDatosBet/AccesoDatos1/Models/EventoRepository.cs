using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class EventoRepository
    {
        private MySqlConnection Connect() {
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mydb";
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            return con;
        }
        internal Evento Retrieve() {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Evento e = null;
            if (res.Read()) {
                Debug.WriteLine("Recuperado: "+ res.GetInt32(0)+" "+res.GetString(1)+" "+res.GetString(2)+" "+res.GetInt32(3));
                e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
            }
            con.Close();
            return e;
        }
    }
}