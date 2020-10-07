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
        Usuario _usuarioDal;

        public Empleado()
        {
            _acceso = new Acceso();
            _usuarioDal = new Usuario();
        }

        public BE.Empleado GuardarEmpleado(BE.Empleado empleado)
        {
            string sql = $@"insert into empleado (nombre,apellido,domicilio,email,tipo_documento,nro_documento,estado,telefono) 
                         VALUES ('{empleado.nombre}','{empleado.apellido}','{empleado.domicilio}','{empleado.email}',
                         {empleado.tipoDocumento},{empleado.nroDocumento},{empleado.estado},{empleado.telefono}); 
                         SELECT legajo AS LastID FROM empleado WHERE legajo = @@Identity;";
            if (empleado.usuario != null)
            {
                sql = $@"insert into empleado (nombre,apellido,domicilio,email,tipo_documento,nro_documento,estado,telefono,id_usuario) 
                         VALUES ('{empleado.nombre}','{empleado.apellido}','{empleado.domicilio}','{empleado.email}',
                         {empleado.tipoDocumento},{empleado.nroDocumento},{empleado.estado},{empleado.telefono},{empleado.usuario.id}); 
                         SELECT legajo AS LastID FROM empleado WHERE legajo = @@Identity;";
            }

            int id = _acceso.ExecuteScalar(sql);
            empleado.legajo = id;
            return empleado;
        }

        public BE.Empleado BuscarEmpleado(BE.Empleado emp)
        {
            string sql = $@"SELECT * FROM empleado where tipo_documento = {emp.tipoDocumento} and nro_documento = {emp.nroDocumento}";

            var reader = _acceso.GetReader(sql);
            if (reader.HasRows)
            {
                BE.Empleado empleado = new BE.Empleado();
                while (reader.Read())
                {
                    empleado.legajo = int.Parse(reader["nombre"].ToString());
                    empleado.nombre = reader["nombre"].ToString();
                    empleado.apellido = reader["apellido"].ToString();
                    empleado.tipoDocumento = int.Parse(reader["tipo_documento"].ToString());
                    empleado.nroDocumento = int.Parse(reader["nro_documento"].ToString());
                    empleado.domicilio = reader["domicilio"].ToString();
                    empleado.email = reader["email"].ToString();
                    empleado.estado = int.Parse(reader["estado"].ToString());
                    empleado.telefono = int.Parse(reader["telefono"].ToString());
                    empleado.usuario = _usuarioDal.GetUsuarioId(int.Parse(reader["usuario"].ToString()));
                }
                _acceso.CloseReader(reader);
                return empleado;
            }
            else
            {
                _acceso.CloseReader(reader);
                throw new Exception("No se encontro el empleado");
            }
            
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
                emp.email = row["email"] != DBNull.Value ? row["email"].ToString() : "";
                emp.tipoDocumento = int.Parse(row["tipo_documento"].ToString());
                emp.nroDocumento = long.Parse(row["nro_documento"].ToString());
                emp.estado = int.Parse(row["estado"].ToString());
                emp.telefono = row["telefono"] != DBNull.Value ?  int.Parse(row["telefono"].ToString()) : 0;
                int _idUsuario = int.Parse(row["id_usuario"].ToString());
                Usuario _usuarioDal = new Usuario();
                BE.Usuario _usuario = _usuarioDal.GetUsuarioId(_idUsuario);

                emp.usuario = _usuario;

                lista.Add(emp);
            }

            return lista;
        }

        public void ActualizarEmpleado(BE.Empleado empleado)
        {
            string sql = $@"update empleado set nombre='{empleado.nombre}',apellido='{empleado.apellido}',domicilio='{empleado.domicilio}',
                         email='{empleado.email}',tipo_documento={empleado.tipoDocumento},nro_documento={empleado.nroDocumento},
                         estado={empleado.estado},telefono= {empleado.telefono}, id_usuario = {empleado.usuario.id} WHERE legajo = {empleado.legajo}
                         ;";
            _acceso.ExecuteNonQuery(sql);
        }
    }
}
