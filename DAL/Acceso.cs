using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        Conexion con;
        public Acceso()
        {
        }

        public void executeNonQuery(String query)
        {
            con.conectar();
            SqlCommand command = new SqlCommand(,query);
        }
    }
}
