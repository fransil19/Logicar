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
            var listaFamilias = GetAllFamilias();
            var listaPatentes = GetAllPatentes();
            Empleado _empleadoBll = new Empleado();
            var listaEmpleados = _empleadoBll.ListarEmpleados();
            HashSet<BE.Permiso> permisosUtilizados = new HashSet<BE.Permiso>();

            foreach (BE.Permiso p in listaPatentes)
            {/*
                foreach (BE.Permiso fam in listaFamilias)
                {
                    if(familia.id != fam.id)
                    {
                        foreach(BE.Permiso pFam in fam.Hijos)
                        {
                            if(p.id == pFam.id)
                            {
                                permisosUtilizados.Add(p);
                            }
                        }
                    }
                }*/
                foreach(BE.Empleado emp in listaEmpleados)
                {
                    foreach(BE.Permiso pEmp in emp.usuario.Permisos)
                    {
                        if (pEmp.Hijos.Count == 0)
                        {
                            if (p.id == pEmp.id)
                            {
                                permisosUtilizados.Add(p);
                            }
                        }
                        else
                        {
                            foreach (BE.Permiso phijo in pEmp.Hijos)
                            {
                                if (p.id == phijo.id)
                                {
                                    permisosUtilizados.Add(p);
                                }
                            }
                        }
                    }
                }
            }

            if(listaPatentes.Count() == permisosUtilizados.Count())
            {
                _permisosDAL.EliminarFamilia(familia);
            }
            else
            {
                throw new Exception("No se puede borrar la familia porque hay permisos que quedarian sin utilizar");
            }
            
        }

        public bool PatenteEnUso(BE.Patente patente, BE.Familia familia)
        {
            Empleado _empleadoBll = new Empleado();
            var listaEmpleados = _empleadoBll.ListarEmpleados();
            bool enUso = false;
            foreach(BE.Empleado emp in listaEmpleados)
            {
                foreach(BE.Permiso p in emp.usuario.Permisos)
                {
                    if (p.Hijos.Count == 0)
                    {
                        if(patente.id == p.id)
                        {
                            enUso = true;
                            return enUso;
                        }
                    }
                    else
                    {
                        if(p.id != familia.id)
                        {
                            foreach(BE.Permiso pFam in p.Hijos)
                            {
                                if (patente.id == pFam.id)
                                {
                                    enUso = true;
                                    return enUso;
                                }
                            }
                        }
                    }
                }
            }
            return enUso;
        }

    }
}
