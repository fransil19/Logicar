using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private int _tipoDoc;

        public int TipoDoc
        {
            get { return _tipoDoc; }
            set { _tipoDoc = value; }
        }

        private long _nroDoc;

        public long NroDoc
        {
            get { return _nroDoc; }
            set { _nroDoc = value; }
        }

        private string _nombre;

        private string _domicilio;

        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private long _telefono;

        public long Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private bool _estado;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

    }
}
