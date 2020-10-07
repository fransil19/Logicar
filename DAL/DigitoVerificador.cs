using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DigitoVerificador
    {
        Acceso _acceso;

        public DigitoVerificador()
        {
            _acceso = new Acceso();
        }

        public DataTable TraerTabla(string nombreTabla)
        {
            string query = $@"SELECT * from {nombreTabla};";
            DataTable tabla = _acceso.ExecuteReader(query);
            return tabla;
        }

        public void ActualizarDVV(long dvv, string nombreTabla)
        {
            string query = $@"UPDATE DigitoVerificador SET dvv = {dvv} WHERE nombre_tabla = '{nombreTabla}';";
            _acceso.ExecuteNonQuery(query);
        }
    }
}
