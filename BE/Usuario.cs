using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _usuario;

        public String usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private String _contrasena;

        public String contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        private int _contador;

        public int contador
        {
            get { return _contador; }
            set { _contador = value; }
        }

        private String _email;

        public String email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _estado;

        public int estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private int _dvh;

        public int dvh
        {
            get { return _dvh; }
            set { _dvh = value; }
        }

    }
}
