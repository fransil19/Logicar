using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        public static SqlConnection instancia = null;

        private SqlConnection GetInstancia()
        {
            if(instancia == null)
            {
                instancia = new SqlConnection();
            }

            return instancia;
        }

        public SqlConnection Conectar()
        {
            SqlConnection conexion = GetInstancia();

            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }

        public void Desconectar()
        {
            SqlConnection conexion = GetInstancia();

            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
