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
        }

        public void ExecuteNonQuery(String query)
        {
            SqlCommand comando = new SqlCommand(query, con.Conectar());
            comando.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable ExecuteReader(String query)
        {
            SqlCommand comando = new SqlCommand(query, con.Conectar());
            SqlDataReader lector = comando.ExecuteReader();
            tabla.Load(lector);
            con.Desconectar();
            return tabla;
        }
    }
}
