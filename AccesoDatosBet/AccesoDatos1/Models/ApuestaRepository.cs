using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection Connect()
        {
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mydb";
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            return con;
        }

        internal Apuesta Retrieve()
        {
            /*Apuesta a = new Apuesta(003,20,"Over",2,"lolo@gmail.com",003);
            return a;*/
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Apuesta a = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt32(5));
                a = new Apuesta(res.GetInt32(0), res.GetInt32(1), res.GetString(2), res.GetInt32(3), res.GetString(4), res.GetInt32(5));
            }
            con.Close();
            return a;
        }
    }
}