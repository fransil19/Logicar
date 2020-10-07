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

        public Empleado()
        {
            _empleadoDal = new DAL.Empleado();
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
                Usuario _usuarioBLL = new Usuario();
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

    }
}
