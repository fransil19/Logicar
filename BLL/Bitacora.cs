using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        DAL.Bitacora _bitacoraDal;
        public Bitacora()
        {
            _bitacoraDal = new DAL.Bitacora();
        }

        public void RegistrarBitacora(BE.Usuario usuario, string descripcion, int criticidad)
        {
            BE.Bitacora bitacora = new BE.Bitacora();
            descripcion = Cifrado.Encriptar(descripcion,false);

            DateTime fecha = DateTime.Now;

            bitacora.usuario = usuario;
            bitacora.descripcion = descripcion;
            bitacora.fecha = fecha;
            bitacora.criticidad = criticidad;

            
            long dvh = DigitoVerificador.CalcularDV(bitacora,"bitacora");
            bitacora.dvh = dvh;

            _bitacoraDal.RegistrarBitacora(bitacora);
        }

        public List<BE.Bitacora> ListarBitacora()
        {
            return _bitacoraDal.ListarBitacora();
        }
    }
}
