using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL
{
    public class Usuario
    {
        DAL.Usuario _usuarioDal;
        Permiso _permisoBll;
        Bitacora _bitacoraBLL;

        public Usuario()
        {
            _usuarioDal = new DAL.Usuario();
            _permisoBll = new Permiso();
            _bitacoraBLL = new Bitacora();
        }

        public BE.Usuario Login(string usuario)
        {
            /* CIFRO EL USUARIO Y CONTRASEÑA */
            

            BE.Usuario user = _usuarioDal.GetUsuarioUser(usuario);

            if(user.usuario == null)
            {
                //Usuario o Contraseña incorrectos
                throw new Exception("Usuario o contraseña incorrectos");
            }

            return user;
        }

        public List<BE.Usuario> GetAll()
        {
            return _usuarioDal.ListarUsuarios();
        }

        public void GuardarPermisos(BE.Usuario u)
        {
            _usuarioDal.GuardarPermisos(u);
        }

        public BE.Usuario GenerarUsuario(BE.Empleado emp)
        {
            BE.Usuario usuario = new BE.Usuario();
            usuario.usuario = Cifrado.Encriptar("u"+emp.legajo.ToString().PadLeft(6, '0'), true);
            string pass = GenerarPassword(8);
            usuario.contrasena = Cifrado.Encriptar(pass, false);
            string[] nombres = emp.nombre.Split(' ');
            string email = "";
            foreach (string n in nombres)
            {
                email += n.Substring(0, 1);

            }
            string[] apellidos = emp.apellido.Split(' ');
            for (int i = 0; i < apellidos.Length; i++)
            {
                if ((i + 1) != apellidos.Length)
                {
                    email += apellidos[i].Substring(0, 1);
                }
                else
                {
                    email += apellidos[i];
                }
            }
            email += "@logicar.com.ar";
            usuario.email = email;
            usuario.estado = 1;
            usuario.dvh = DigitoVerificador.CalcularDV(usuario, "usuario");
            _usuarioDal = new DAL.Usuario();
            _usuarioDal.Insertar(usuario);

            return usuario;
        }

        public static string GenerarPassword(int longitud)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, longitud)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public BE.Usuario EliminarUsuario(BE.Usuario usuario)
        {
            usuario.estado = 0;
            _usuarioDal.Actualizar(usuario);
            return usuario;
        }

        public int BloquearUsuario(BE.Usuario usuario)
        {
            if(usuario.contador >= 3)
            {
                _permisoBll.FillUserComponents(usuario);
                var esAdmin = VerificarPermisos(usuario);

                if (esAdmin)
                {
                    //retorno que es admin
                    return 0;
                }
                else
                {
                    //no es admin
                    return 1;
                }
            }
            else
            {
                usuario.contador += 1;
                if (usuario.contador >= 3)
                {
                    _permisoBll.FillUserComponents(usuario);
                    var esAdmin = VerificarPermisos(usuario);

                    if (esAdmin)
                    {
                        //retorno que es admin
                        return 0;
                    }
                    else
                    {
                        usuario.dvh = DigitoVerificador.CalcularDV(usuario,"usuario");
                        _bitacoraBLL.RegistrarBitacora(usuario, "Contraseña Incorrecta, se bloqueo el usuario", 1);
                        _usuarioDal.Actualizar(usuario);
                        return 1;
                    }
                }

                usuario.dvh = DigitoVerificador.CalcularDV(usuario, "usuario");
                
                _bitacoraBLL.RegistrarBitacora(usuario, $@"Contraseña Incorrecta, se incrementa contador = {usuario.contador}", 1);
                _usuarioDal.Actualizar(usuario);
                return 2;

            }
        }

        public bool VerificarPermisos(BE.Usuario usuario)
        {
            IList<BE.Patente> listaPatentes = _permisoBll.GetAllPatentes();
            var listaModificada = new List<BE.Patente>();
            foreach (var permiso in usuario.Permisos)
            {
                foreach(var item in listaPatentes)
                {
                    if (permiso.Hijos.Count <= 0)
                    {
                        if (item.id == permiso.id)
                        {
                            if (listaModificada.Find(r => r.id == item.id) == null)
                            {
                                listaModificada.Add(item);
                            }
                        }
                    }
                    else
                    {
                        foreach(var pat in permiso.Hijos)
                        {
                            if (item.id == permiso.id)
                            {
                                if (listaModificada.Find(r => r.id == item.id) == null)
                                {
                                    listaModificada.Add(item);
                                }
                            }
                        }
                    }
                    
                }
            }

            if (listaPatentes.Count() == listaModificada.Count())
            {
                // Es administrador
                return true;
            }
            else
            {
                // No es admin
                return false;
            }
        }

        public void DesbloquearUsuarioAdmin(BE.Usuario usuario)
        {
            usuario.contador = 0;
            _usuarioDal.Actualizar(usuario);
        }
    }
}
