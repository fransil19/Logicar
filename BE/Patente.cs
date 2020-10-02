using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patente : Permiso
    {
        public override IList<Permiso> Hijos
        {
            get
            {
                return new List<Permiso>();
            }

        }

        public override void AgregarHijo(Permiso c)
        {

        }

        public override void VaciarHijos()
        {

        }

    }
}
