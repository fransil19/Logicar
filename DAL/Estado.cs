using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Estado
    {
        Acceso _acceso;

        public Estado()
        {
            _acceso = new Acceso();
        }

        public BE.Estado BuscarEstadoId(int id)
        {
            string query = $@"SELECT * FROM estado WHERE id = {id};";

           
            var reader = _acceso.GetReader(query);
            BE.Estado estado = new BE.Estado();

            while (reader.Read())
            {
                estado.Id = int.Parse(reader["id"].ToString());
                estado.Resultado = int.Parse(reader["resultado"].ToString());
            }

            _acceso.CloseReader(reader);
            return estado;
        }

        public BE.Estado GuardarEstado(BE.Estado _estado)
        {
            string query = $@"INSERT INTO estado (resultado) 
                           output INSERTED.ID VALUES({_estado.Resultado});";

            BE.Estado estado = new BE.Estado();

            int id = _acceso.ExecuteScalar(query);
            _estado.Id = id;

            return _estado;
        }
    }
}
