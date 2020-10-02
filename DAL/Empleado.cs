using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Empleado
    {
        Acceso _acceso;

        public Empleado()
        {
            _acceso = new Acceso();
        }


        public List<BE.Empleado> ListarEmpleados()
        {
            string query = "SELECT * FROM Empleado;";
            List<BE.Empleado> lista = new List<BE.Empleado>();
            DataTable tabla = _acceso.ExecuteReader(query);

            foreach( DataRow row in tabla.Rows)
            {
                BE.Empleado emp = new BE.Empleado();
                emp.legajo = int.Parse(row["legajo"].ToString());
                emp.nombre = row["nombre"].ToString();
                emp.apellido = row["apellido"].ToString();
                emp.domicilio = row["domicilio"].ToString();
                emp.email = row["email"].ToString();
                emp.tipoDocumento = int.Parse(row["tipo_documento"].ToString());
                emp.nroDocumento = long.Parse(row["nro_documento"].ToString());
                emp.estado = int.Parse(row["estado"].ToString());
                
                int _idUsuario = int.Parse(row["id_usuario"].ToString());
                Usuario _usuarioDal = new Usuario();
                BE.Usuario _usuario = _usuarioDal.GetUsuarioId(_idUsuario);

                emp.usuario = _usuario;

                lista.Add(emp);
            }

            return lista;
        }
    }
}
