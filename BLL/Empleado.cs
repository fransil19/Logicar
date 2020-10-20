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

        public Empleado()
        {
            _empleadoDal = new DAL.Empleado();
            _usuarioBLL = new Usuario();
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
            catch(Exception e)
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
            empleado.estado = 0;
            _usuarioBLL.EliminarUsuario(empleado.usuario);
            ActualizarEmpleado(empleado);
            return empleado;
        }

    }
}
