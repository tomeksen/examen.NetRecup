using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AccesoDatos1.Models
{
    public class MercadoRepository
    {
        private MySqlConnection Connect()
        {
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mydb";
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            return con;
        }

        internal Mercado Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Mercado m = null;
            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetInt32(2) + " " + res.GetInt32(3)+" " + res.GetInt32(4)+" " + res.GetInt32(5));
                m = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetInt32(2), res.GetInt32(3), res.GetInt32(4), res.GetInt32(5));
            }
            con.Close();
            return m;


        }
    }
}