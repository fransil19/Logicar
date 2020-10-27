using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Idioma
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private bool _default;

        public bool Default
        {
            get { return _default; }
            set { _default = value; }
        }

        override
        public string ToString()
        {
            return Nombre;
        }


    }
}
