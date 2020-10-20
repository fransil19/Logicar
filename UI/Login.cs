using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Login : Form
    {
        BLL.Usuario _usuarioBLL;
        BLL.Permiso _permisoBll;
        BLL.Bitacora _bitacoraBll;
        public Login()
        {
            
            _usuarioBLL = new BLL.Usuario();
            _permisoBll = new BLL.Permiso();
            _bitacoraBll = new BLL.Bitacora();
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //Verifico que los campos no esten vacios
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Por favor complete los campos requeridos");
                return;
            }
            string usuarioCifrado = BLL.Cifrado.Encriptar(txtUsuario.Text, true);
            string passCifrado = BLL.Cifrado.Encriptar(txtPass.Text, false);

            int error_verificado = BLL.DigitoVerificador.VerificarDV();
            BE.Usuario usuario;
            try
            {
                usuario = _usuarioBLL.Login(usuarioCifrado);
                if (usuario.contrasena != passCifrado)
                {
                    int bloqueado = _usuarioBLL.BloquearUsuario(usuario);

                    switch(bloqueado)
                    {
                        case 0:
                            break;
                        case 1:
                            MessageBox.Show("El usuario se encuentra bloqueado");
                            return;
                        case 2:
                            MessageBox.Show("Usuario o contraseña incorrectos");
                            return;
                    }
                }
                if (usuario.contador == 3)
                {
                    var esAdmin = _usuarioBLL.VerificarPermisos(usuario);
                    if (esAdmin)
                    {
                        var opcion = MessageBox.Show("El usuario se encuentra bloqueado, desea desbloquearlo ?", "Desbloquear Usuario?", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                        if(opcion == DialogResult.OK)
                        {
                            //Desbloquear usuario admin
                            _usuarioBLL.DesbloquearUsuarioAdmin(usuario);

                        }
                        else
                        {
                            return;
                        }
                    }
                }


                usuario.contador = 0;
                _permisoBll.FillUserComponents(usuario);
                var _esAdmin = _usuarioBLL.VerificarPermisos(usuario);

                if (error_verificado == 1)
                {
                    if (_esAdmin)
                    {
                        //muestra pantalla para reestablecer.
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error, por favor contacte con el administrador del sistema.");
                        return;
                    }
                }

                _bitacoraBll.RegistrarBitacora(usuario,$@"El usuario {txtUsuario.Text} ingreso en el sistema",3);

                Services.SessionManager.Login(usuario);

                MessageBox.Show("Ingreso Correcto");
                this.Hide();
                Logicar formLogicar = new Logicar();
                var cerro = formLogicar.ShowDialog();
                if(cerro == DialogResult.Cancel)
                {
                    this.Show();
                }

            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
