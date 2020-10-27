using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Bitacora
    {
        Acceso _acceso;
        Usuario _usuarioDal;

        public Bitacora()
        {
            _acceso = new Acceso();
            _usuarioDal = new Usuario();
        }

        public void RegistrarBitacora(BE.Bitacora bitacora)
        {
            string query = string.Format("INSERT INTO bitacora (id_usuario,descripcion,criticidad,fecha,dvh) VALUES ({0},'{1}',{2},'{3}',{4})",
                bitacora.usuario.id, bitacora.descripcion, bitacora.criticidad, bitacora.fecha.ToString("yyyy-MM-dd HH:mm:ss"), bitacora.dvh);

            _acceso.ExecuteNonQuery(query);
        }

        public List<BE.Bitacora> ListarBitacora()
        {
            List<BE.Bitacora> listaBitacora = new List<BE.Bitacora>();
            string query = "SELECT * FROM Bitacora";
            DataTable tb;
            tb = _acceso.ExecuteReader(query);

            foreach (DataRow fila in tb.Rows)
            {
                BE.Bitacora bitacora = new BE.Bitacora();
                bitacora.id = int.Parse(fila["id"].ToString());
                bitacora.descripcion = fila["descripcion"].ToString();
                bitacora.criticidad = int.Parse(fila["criticidad"].ToString());
                bitacora.fecha = DateTime.Parse(fila["fecha"].ToString());
                bitacora.dvh = long.Parse(fila["dvh"].ToString());

                bitacora.usuario = _usuarioDal.GetUsuarioId(int.Parse(fila["id_usuario"].ToString()));
                listaBitacora.Add(bitacora);
            }
            return listaBitacora;
        }
    }
}
