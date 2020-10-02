using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Acceso
    {
        Conexion con;
        DataTable tabla;

        public Acceso()
        {
            tabla = new DataTable();
            con = Conexion.GetInstancia();
        }

        public void ExecuteNonQuery(String query)
        {
            con.Conectar();
            SqlCommand comando = new SqlCommand(query, con._con);
            comando.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable ExecuteReader(String query)
        {
            con.Conectar();
            SqlCommand comando = new SqlCommand(query, con._con);
            SqlDataReader lector = comando.ExecuteReader();
            tabla.Load(lector);
            con.Desconectar();
            return tabla;
        }

        public int ExecuteScalar(String query)
        {
            con.Conectar();
            SqlCommand comando = new SqlCommand(query, con._con);
            var id = comando.ExecuteScalar();
            con.Desconectar();
            return (int)id;
        }
    }
}
