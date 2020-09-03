using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DigitoVerificador
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _nombreTabla;

        public String nombreTabla
        {
            get { return _nombreTabla; }
            set { _nombreTabla = value; }
        }

        private long _valorDvv;

        public long valorDvv
        {
            get { return _valorDvv; }
            set { _valorDvv = value; }
        }
    }
}
