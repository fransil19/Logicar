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
    public partial class Login : Form, Services.IIdiomaObserver
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
            Traducir();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //Verifico que los campos no esten vacios
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Por favor complete los campos requeridos");
                return;
            }
            string usuarioCifrado = BLL.Cifrado.Encriptar(txtUsuario.Text.ToUpper(), true);
            string passCifrado = BLL.Cifrado.Encriptar(txtPass.Text.ToUpper(), false);

            try
            {
                int error_verificado = BLL.DigitoVerificador.VerificarDV();
                BE.Usuario usuario;
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
                _usuarioBLL.DesbloquearUsuario(usuario);
                _permisoBll.FillUserComponents(usuario);
                var _esAdmin = _usuarioBLL.VerificarPermisos(usuario);

                if (error_verificado == 1)
                {
                    if (_esAdmin)
                    {
                        string mensaje = "";
                        //muestra pantalla para reestablecer.
                        var idioma = cmbIdioma.SelectedItem as BE.Idioma;
                        if (idioma.Nombre == "Español")
                        {
                            mensaje = "Desea ver la bitacora del sistema?";
                        }
                        else
                        {
                            mensaje = "Do you want to see the system log?";
                        }
                        var opcion = MessageBox.Show(mensaje, "Error de integridad", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                        if(opcion == DialogResult.Yes)
                        {
                            this.Hide();
                            ReestablecerSistema formRestablecer = new ReestablecerSistema(usuario);
                            formRestablecer.Show();
                            formRestablecer.FormClosed += new FormClosedEventHandler(Login_FormClosed);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error, por favor contacte con el administrador del sistema.");
                        return;
                    }
                }

                _bitacoraBll.RegistrarBitacora(usuario,$@"El usuario {txtUsuario.Text} ingreso en el sistema",3);

                Services.SessionManager.Login(usuario,cmbIdioma.SelectedItem as BE.Idioma);

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

        public void UpdateLanguage(BE.Idioma idioma)
        {
            Traducir(idioma);
        }

        private void Traducir(BE.Idioma idioma = null)
        {
            var traducciones = Services.Traductor.ObtenerTraducciones(idioma);

            if (this.Tag != null && traducciones.ContainsKey(this.Tag.ToString()))
                this.Text = traducciones[this.Tag.ToString()].Texto;



            if (lblUsuario.Name != null && traducciones.ContainsKey(lblUsuario.Name.ToString()))
                lblUsuario.Text = traducciones[lblUsuario.Name.ToString()].Texto;

            if (lblContrasena.Name != null && traducciones.ContainsKey(lblContrasena.Name.ToString()))
                lblContrasena.Text = traducciones[lblContrasena.Name.ToString()].Texto;

            if (lblSelIdioma.Name != null && traducciones.ContainsKey(lblSelIdioma.Name.ToString()))
                lblSelIdioma.Text = traducciones[lblSelIdioma.Name.ToString()].Texto;

            if (linkCPass.Name != null && traducciones.ContainsKey(linkCPass.Name.ToString()))
                linkCPass.Text = traducciones[linkCPass.Name.ToString()].Texto;

            if (btnIngresar.Name != null && traducciones.ContainsKey(btnIngresar.Name.ToString()))
                btnIngresar.Text = traducciones[btnIngresar.Name.ToString()].Texto;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            var idiomas = Services.Traductor.ObtenerIdiomas();
            cmbIdioma.DataSource = idiomas;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLanguage(cmbIdioma.SelectedItem as BE.Idioma);
        }

        private void linkCPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Por favor complete el campo usuario requerido");
                return;
            }
            try
            {
                _usuarioBLL.CambiarContrasena(txtUsuario.Text);
                var idioma = cmbIdioma.SelectedItem as BE.Idioma;
                if (idioma.Nombre == "Español") 
                {
                    MessageBox.Show("Se cambio la contraseña correctamente");
                }
                else
                {
                    MessageBox.Show("The password was changed correctly");
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
