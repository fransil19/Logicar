using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Empleado
    {
        private int _legajo;

        public int legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        private int _tipoDocumento;

        public int tipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        private long _nroDocumento;

        public long nroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }

        private String _nombre;

        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private String _apellido;

        public String apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private String _domicilio;

        public String domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        private String _email;

        public String email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _telefono;

        public int telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private int _estado;

        public int estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private Usuario _usuario;

        public Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

    }
}
