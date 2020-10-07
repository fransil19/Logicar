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

        public Usuario()
        {
            _usuarioDal = new DAL.Usuario();
        }

        public string Login(string usuario, string password)
        {

            //Verifico integridad de la base
            int error_verificado = DigitoVerificador.VerificarDV();

            /* CIFRO EL USUARIO Y CONTRASEÑA */
            string usuarioCifrado = Cifrado.Encriptar(usuario, true);
            string passCifrado = Cifrado.Encriptar(password, false);

            BE.Usuario user = _usuarioDal.GetUsuarioUser(usuarioCifrado);

            if(user.usuario == null)
            {
                throw new Exception("Usuario o Contraseña incorrectos");
            }
            else if(user.contrasena != passCifrado)
            {

            }
            else if(user.contador == 3)
            {

            }

            return "hola";//mensaje;
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
    }
}
