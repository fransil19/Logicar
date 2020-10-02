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
        public Login()
        {
            //Pruebo la conexion a la base para saber si esta activa.

            //
            _usuarioBLL = new BLL.Usuario();
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

            string resultadoLogin = _usuarioBLL.Login(txtUsuario.Text, txtPass.Text);





        }
    }
}
