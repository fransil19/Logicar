using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia : Permiso
    {
        private IList<Permiso> _hijos;
        public Familia()
        {
            _hijos = new List<Permiso>();
        }

        public override IList<Permiso> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        public override void VaciarHijos()
        {
            _hijos = new List<Permiso>();
        }
        public override void AgregarHijo(Permiso c)
        {
            _hijos.Add(c);
        }
    }
}

