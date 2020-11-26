using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Empleado
    {
        DAL.Empleado _empleadoDal;
        DAL.Usuario _usuarioDal;
        Usuario _usuarioBLL;
        Permiso _permisoBll;

        public Empleado()
        {
            _empleadoDal = new DAL.Empleado();
            _usuarioBLL = new Usuario();
            _permisoBll = new Permiso();
        }

        public void AltaEmpleado(BE.Empleado emp)
        {
            try
            {
                var empleadoExistente = _empleadoDal.BuscarEmpleado(emp);
                if (empleadoExistente != null)
                {
                    throw new Exception("El empleado indicado ya existe.");
                }
            }
            catch
            {
                _empleadoDal.GuardarEmpleado(emp);
                emp.usuario = _usuarioBLL.GenerarUsuario(emp);
                _empleadoDal.ActualizarEmpleado(emp);

                //encripto usuario que realiza el evento,registro en bitacora y "envia" por email.

            }

        }

        public List<BE.Empleado> ListarEmpleados()
        {
            List<BE.Empleado> lista = _empleadoDal.ListarEmpleados();
            return lista;
        }

        public void ActualizarEmpleado(BE.Empleado empleado)
        {
            _empleadoDal.ActualizarEmpleado(empleado);
        }

        public BE.Empleado EliminarEmpleado(BE.Empleado empleado)
        {
            var listaEmpleados = ListarEmpleados();
            var listaPermisos = _permisoBll.GetAllPatentes();
            HashSet<BE.Permiso> permisosUtilizados = new HashSet<BE.Permiso>();

            foreach (BE.Permiso p in listaPermisos)
            {
                foreach (BE.Empleado emp in listaEmpleados)
                {
                    if (empleado.legajo != emp.legajo && emp.estado != 0)
                    {
                        foreach (BE.Permiso pemp in emp.usuario.Permisos)
                        {
                            if (pemp.Hijos.Count == 0)
                            {
                                if (p.id == pemp.id)
                                {
                                    permisosUtilizados.Add(p);
                                }
                            }
                            else
                            {
                                foreach (BE.Permiso phijo in pemp.Hijos)
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
            }
            if (listaPermisos.Count() == permisosUtilizados.Count())
            {
                empleado.estado = 0;
                _usuarioBLL.EliminarUsuario(empleado.usuario);
                ActualizarEmpleado(empleado);
                return empleado;
            }
            else
            {
                throw new Exception("No puede dar de baja el usuario, quedarian permisos sin asignar");
            }
        }

        public BE.Empleado GetEmpleadoUsuario(BE.Usuario usuario)
        {
            return _empleadoDal.GetEmpleadoUsuario(usuario);
        }

    }
}
