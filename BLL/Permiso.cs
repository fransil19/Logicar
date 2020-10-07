using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Permiso
    {
        DAL.Permiso _permisosDAL;
        public Permiso()
        {
            _permisosDAL = new DAL.Permiso();
        }

        public bool Existe(BE.Permiso p, int id)
        {
            bool existe = false;

            if (p.id.Equals(id))
                existe = true;
            else

                foreach (var item in p.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }

        public BE.Permiso GuardarPermiso(BE.Permiso p)
        {
            return _permisosDAL.GuardarPermiso(p);
        }


        public void GuardarFamilia(BE.Familia f)
        {
            _permisosDAL.InsertarFamilia(f);
        }

        public IList<BE.Patente> GetAllPatentes()
        {
            return _permisosDAL.GetAllPatentes();
        }

        public IList<BE.Familia> GetAllFamilias()
        {
            return _permisosDAL.GetAllFamilias();
        }

        public IList<BE.Permiso> GetAll(string familia)
        {
            return _permisosDAL.GetAll(familia);

        }

        public void FillUserComponents(BE.Usuario u)
        {
            _permisosDAL.LlenarUsuarioPermisos(u);

        }

        public void FillFamilyComponents(BE.Familia f)
        {
            _permisosDAL.ListarFamiliaPatentes(f);
        }

        public void EliminarFamilia(BE.Familia familia)
        {
            _permisosDAL.EliminarFamilia(familia);
        }

    }
}
