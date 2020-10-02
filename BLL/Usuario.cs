using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
