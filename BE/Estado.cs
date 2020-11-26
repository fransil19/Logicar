using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Estado
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _resultado;

        public int Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

    }
}
