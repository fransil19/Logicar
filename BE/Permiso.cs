using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso
    {
        public string nombre { get; set; }
        public int id { get; set; }
        public long dvh { get; set; }
        public int esFamilia { get; set; }

        public abstract IList<Permiso> Hijos { get; }
        public abstract void AgregarHijo(Permiso c);
        public abstract void VaciarHijos();

        public override string ToString()
        {
            return nombre;
        }
    }
}
