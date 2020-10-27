using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Usuario
    {
        Acceso _acceso;
        Permiso _permisoDal;
        public Usuario()
        {
            _acceso = new Acceso();
            _permisoDal = new Permiso();
        }

        public void Actualizar(BE.Usuario usuario)
        {
            string query = string.Format(@"UPDATE usuario set usuario='{0}',contrasena='{1}',contador={2},estado={3},
                            email='{4}',dvh={5} where id = {6}", usuario.usuario, usuario.contrasena,
                          usuario.contador, usuario.estado, usuario.email, usuario.dvh,usuario.id);
            _acceso.ExecuteReader(query);
        }

        public BE.Usuario GetUsuarioUser(string user)
        {
            DataTable tb;
            string query = string.Format("SELECT * FROM usuario WHERE usuario = '{0}'",user);
            tb = _acceso.ExecuteReader(query);

            
            if(tb != null)
            {
                BE.Usuario usuario = new BE.Usuario();
                foreach (DataRow fila in tb.Rows)
                {
                    usuario.id = int.Parse(fila[0].ToString());
                    usuario.usuario = fila[1].ToString();
                    usuario.contrasena = fila[2].ToString();
                    usuario.contador = int.Parse(fila[3].ToString());
                    usuario.estado = int.Parse(fila[4].ToString());
                    usuario.email = fila[5].ToString();
                    usuario.dvh = long.Parse(fila[6].ToString());
                }
                _permisoDal.LlenarUsuarioPermisos(usuario);
                return usuario;
            }
            else
            {
                throw new Exception($@"No existe el usuario {user}");
            }
        }

        public BE.Usuario GetUsuarioId(int id)
        {
            DataTable tb;
            string query = string.Format("SELECT * FROM usuario WHERE id = {0}", id);
            tb = _acceso.ExecuteReader(query);

            BE.Usuario usuario = new BE.Usuario();
            if (tb != null)
            {
                foreach (DataRow fila in tb.Rows)
                {
                    usuario.id = int.Parse(fila[0].ToString());
                    usuario.usuario = fila[1].ToString();
                    usuario.contrasena = fila[2].ToString();
                    usuario.contador = int.Parse(fila[3].ToString());
                    usuario.estado = int.Parse(fila[4].ToString());
                    usuario.email = fila[5].ToString();
                    usuario.dvh = long.Parse(fila[6].ToString());
                }
                _permisoDal.LlenarUsuarioPermisos(usuario);
            }

            return usuario;

        }

        public List<BE.Usuario> ListarUsuarios()
        {
            List<BE.Usuario> listaUsuarios = new List<BE.Usuario>();
            DataTable tb;
            string query = string.Format("SELECT * FROM usuario");
            tb = _acceso.ExecuteReader(query);

            

            foreach (DataRow fila in tb.Rows)
            {
                BE.Usuario usuario = new BE.Usuario();

                usuario.id = int.Parse(fila[0].ToString());
                usuario.usuario = fila[1].ToString();
                usuario.contrasena = fila[2].ToString();
                usuario.contador = int.Parse(fila[3].ToString());
                usuario.estado = int.Parse(fila[4].ToString());
                usuario.email = fila[5].ToString();
                usuario.dvh = long.Parse(fila[6].ToString());

                _permisoDal.LlenarUsuarioPermisos(usuario);
                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }

        public BE.Usuario Insertar(BE.Usuario usuario)
        {
            string query = string.Format(@"INSERT INTO usuario (usuario,contrasena,contador,estado,email,dvh) 
                           output INSERTED.ID VALUES('{0}','{1}',{2},{3},'{4}',{5})",usuario.usuario,usuario.contrasena,
                           usuario.contador,usuario.estado,usuario.email,usuario.dvh);
            int id = _acceso.ExecuteScalar(query);
            usuario.id = id;

            return usuario;

        }

        public void GuardarPermisos(BE.Usuario u)
        {

            try
            {
              
                string query = $@"delete from patenteUsuario where id_usuario={u.id};";
                _acceso.ExecuteNonQuery(query);

                foreach (var perm in u.Permisos)
                {
                    query = $@"insert into patenteUsuario (id_usuario,id_patente) values ({u.id},{perm.id}) "; ;

                    _acceso.ExecuteNonQuery(query);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BE.Usuario> GetUsuariosFamilia(BE.Familia familia)
        {
            List<BE.Usuario> listaUsuarios = new List<BE.Usuario>();

            string sql = $@"SELECT u.* FROM usuario u 
                           INNER JOIN patenteusuario pu ON pu.id_usuario=u.id
                           WHERE id_patente = {familia.id};";

            var reader = _acceso.GetReader(sql);

            while (reader.Read())
            {
                BE.Usuario usuario = new BE.Usuario();
                usuario.id = int.Parse(reader["id"].ToString());
                usuario.usuario = reader["usuario"].ToString();
                usuario.contrasena = reader["contrasena"].ToString();
                usuario.contador = int.Parse(reader["contador"].ToString());
                usuario.estado = int.Parse(reader["estado"].ToString());
                usuario.email = reader["email"].ToString();
                usuario.dvh = long.Parse(reader["dvh"].ToString());
                listaUsuarios.Add(usuario);
            }
            _acceso.CloseReader(reader);

            return listaUsuarios;
        }

    }
}
