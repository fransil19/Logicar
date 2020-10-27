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

        public List<BE.DigitoVerificador> TraerDVV()
        {
            string query = $@"SELECT * FROM digito_verificador;";
            List<BE.DigitoVerificador> listaDvv = new List<BE.DigitoVerificador>();
            var reader = _acceso.GetReader(query);
            while (reader.Read())
            {
                BE.DigitoVerificador digito = new BE.DigitoVerificador();
                digito.id = int.Parse(reader["id"].ToString());
                digito.nombreTabla = reader["nombre_tabla"].ToString();
                digito.valorDvv = long.Parse(reader["dvv"].ToString());
                listaDvv.Add(digito);
            }
            _acceso.CloseReader(reader);
            return listaDvv;
        }
        public DataTable TraerTabla(string nombreTabla)
        {
            string query = $@"SELECT * from {nombreTabla};";
            DataTable tabla = _acceso.ExecuteReader(query);
            return tabla;
        }

        public void ActualizarDVV(long dvv, string nombreTabla)
        {
            string query = $@"UPDATE Digito_Verificador SET dvv = {dvv} WHERE nombre_tabla = '{nombreTabla}';";
            _acceso.ExecuteNonQuery(query);
        }

        public void ActualizarDVH(long dvh, string nombreTabla, string campoIdentificador, string valorIdentificador)
        {
            string query = $@"UPDATE {nombreTabla} set dvh = {dvh} WHERE {campoIdentificador} = {valorIdentificador}";
            _acceso.ExecuteNonQuery(query);
        }
    }
}
