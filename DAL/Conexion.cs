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
        public static Conexion _instancia = null;
        public SqlConnection _con;

        private Conexion()
        {
            _con = new SqlConnection("Data Source=DESKTOP-HPTT8TA;Initial Catalog=Diploma;Integrated Security=True");
        }

        public static Conexion GetInstancia()
        {
            if(_instancia == null)
            {
                _instancia = new Conexion();
            }

            return _instancia;
        }

        public SqlConnection Conectar()
        {

            if (_con.State == System.Data.ConnectionState.Closed)
            {
                _con.Open();
            }

            return _con;
        }

        public void Desconectar()
        {
            if (_con.State == System.Data.ConnectionState.Open)
            {
                _con.Close();
            }
        }
    }
}
