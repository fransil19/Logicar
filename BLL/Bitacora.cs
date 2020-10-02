using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Bitacora
    {

        public static void RegistrarBitacora(BE.Usuario usuario, string descripcion, int criticidad)
        {
            DAL.Acceso acceso = new DAL.Acceso();
            BE.Bitacora bitacora = new BE.Bitacora();
            descripcion = Cifrado.Encriptar(descripcion,false);

            DateTime fecha = new DateTime().Date;

            bitacora.usuario = usuario;
            bitacora.descripcion = descripcion;
            bitacora.fecha = fecha;
            bitacora.criticidad = criticidad;

            
            long dvh = DigitoVerificador.CalcularDV(bitacora,"bitacora");
            bitacora.dvh = dvh;

            string query = string.Format("INSERT INTO bitacora (id_usuario,descripcion,criticidad,fecha) VALUES ({0},{1},{2},{3})", 
                bitacora.usuario.id, bitacora.descripcion, bitacora.criticidad, bitacora.fecha);


        }
    }
}
