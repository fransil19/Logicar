using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Usuario _usuario;

        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _criticidad;

        public int criticidad
        {
            get { return _criticidad; }
            set { _criticidad = value; }
        }

        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private long _dvh;

        public long dvh
        {
            get { return _dvh; }
            set { _dvh = value; }
        }


    }
}
