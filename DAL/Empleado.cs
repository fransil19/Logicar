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
            DataTable tabla = _acceso.ExecuteReader(sql);

            if (tabla.Rows.Count > 0)
            {
                BE.Empleado empleado = new BE.Empleado();
                foreach (DataRow fila in tabla.Rows)
                {
                    empleado.legajo = int.Parse(fila["legajo"].ToString());
                    empleado.nombre = fila["nombre"].ToString();
                    empleado.apellido = fila["apellido"].ToString();
                    empleado.tipoDocumento = int.Parse(fila["tipo_documento"].ToString());
                    empleado.nroDocumento = int.Parse(fila["nro_documento"].ToString());
                    empleado.domicilio = fila["domicilio"].ToString();
                    empleado.email = fila["email"].ToString();
                    empleado.estado = int.Parse(fila["estado"].ToString());
                    empleado.telefono = fila["telefono"] != DBNull.Value ? int.Parse(fila["telefono"].ToString()) : 0;
                    empleado.usuario = _usuarioDal.GetUsuarioId(int.Parse(fila["usuario"].ToString()));
                }
                return empleado;
            }
            else
            {
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

        public BE.Empleado GetEmpleadoUsuario(BE.Usuario usuario)
        {
            string sql = $@"SELECT * FROM empleado where id_usuario = {usuario.id}";

            var reader = _acceso.GetReader(sql);
            if (reader.HasRows)
            {
                BE.Empleado empleado = new BE.Empleado();
                while (reader.Read())
                {
                    empleado.legajo = int.Parse(reader["legajo"].ToString());
                    empleado.nombre = reader["nombre"].ToString();
                    empleado.apellido = reader["apellido"].ToString();
                    empleado.tipoDocumento = int.Parse(reader["tipo_documento"].ToString());
                    empleado.nroDocumento = int.Parse(reader["nro_documento"].ToString());
                    empleado.domicilio = reader["domicilio"].ToString();
                    empleado.email = reader["email"].ToString();
                    empleado.estado = int.Parse(reader["estado"].ToString());
                    empleado.telefono = reader["telefono"] != DBNull.Value ? int.Parse(reader["telefono"].ToString()) : 0;
                    empleado.usuario = usuario;
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

        public BE.Empleado BuscarEmpleadoLegajo(int legajo)
        {
            string sql = $@"SELECT * FROM empleado where legajo = {legajo}";
            DataTable tabla = _acceso.ExecuteReader(sql);

            if (tabla.Rows.Count > 0)
            {
                BE.Empleado empleado = new BE.Empleado();
                foreach (DataRow fila in tabla.Rows)
                {
                    empleado.legajo = int.Parse(fila["legajo"].ToString());
                    empleado.nombre = fila["nombre"].ToString();
                    empleado.apellido = fila["apellido"].ToString();
                    empleado.tipoDocumento = int.Parse(fila["tipo_documento"].ToString());
                    empleado.nroDocumento = int.Parse(fila["nro_documento"].ToString());
                    empleado.domicilio = fila["domicilio"].ToString();
                    empleado.email = fila["email"].ToString();
                    empleado.estado = int.Parse(fila["estado"].ToString());
                    empleado.telefono = fila["telefono"] != DBNull.Value ? int.Parse(fila["telefono"].ToString()) : 0;
                    empleado.usuario = _usuarioDal.GetUsuarioId(int.Parse(fila["id_usuario"].ToString()));
                }
                return empleado;
            }
            else
            {
                throw new Exception("No se encontro el empleado");
            }

        }
    }
}
