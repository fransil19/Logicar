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
    public partial class Logicar : Form, Services.IIdiomaObserver
    {
        BLL.Usuario _usuarioBLL;
        public Logicar()
        {
            _usuarioBLL = new BLL.Usuario();
            InitializeComponent();
            ValidarFormulario();
            MostrarIdiomas();
            MarcarIdioma();
            Traducir();
            ValidarPermisos();
        }

        private void mnuAdministrarEmpleados_Click(object sender, EventArgs e)
        {
            ListaEmpleados frmLEmpleados = new ListaEmpleados();
            frmLEmpleados.MdiParent = this;
            frmLEmpleados.Show();
        }

        private void mnuAdministrarFamilias_Click(object sender, EventArgs e)
        {
            ListarFamilias frmLFamilias = new ListarFamilias();
            frmLFamilias.MdiParent = this;
            frmLFamilias.Show();
        }

        void MarcarIdioma()
        {
            if (!Services.SessionManager.IsLogged())
            {
                foreach (var item in tsmiIdiomas.DropDownItems)
                {

                    var i = ((BE.Idioma)((ToolStripMenuItem)item).Tag);

                    ((ToolStripMenuItem)item).Checked = i.Default;
                    ((ToolStripMenuItem)item).Enabled = false;

                }
            }
            else
            {
                foreach (var item in tsmiIdiomas.DropDownItems)
                {

                    ((ToolStripMenuItem)item).Enabled = true;
                    ((ToolStripMenuItem)item).Checked = Services.SessionManager.GetInstance.Idioma.Id.Equals(((BE.Idioma)((ToolStripMenuItem)item).Tag).Id);
                }
            }
        }

        private void MostrarIdiomas()
        {
            var idiomas = Services.Traductor.ObtenerIdiomas();

            foreach (var item in idiomas)
            {
                var t = new ToolStripMenuItem();
                t.Text = item.Nombre;
                t.Tag = item;
                this.tsmiIdiomas.DropDownItems.Add(t);

                t.Click += idioma_Click;
            }

        }

        public void ValidarFormulario()
        {

            this.tsmiLogin.Enabled = !Services.SessionManager.IsLogged();
            this.tsmiLogout.Enabled = Services.SessionManager.IsLogged();
            MarcarIdioma();
            Traducir();
        }

        public void UpdateLanguage(BE.Idioma idioma)
        {


            MarcarIdioma();
            Traducir();

        }
        private void Traducir()
        {
            BE.Idioma idioma = null;
            if (Services.SessionManager.IsLogged())
                idioma = Services.SessionManager.GetInstance.Idioma;


            var traducciones = Services.Traductor.ObtenerTraducciones(idioma);

            if (mnuSesion.Name != null && traducciones.ContainsKey(mnuSesion.Name.ToString()))
                this.mnuSesion.Text = traducciones[mnuSesion.Name.ToString()].Texto;


            if (tsmiLogin.Name != null && traducciones.ContainsKey(tsmiLogin.Name.ToString()))
                this.tsmiLogin.Text = traducciones[tsmiLogin.Name.ToString()].Texto;


            if (tsmiLogout.Name != null && traducciones.ContainsKey(tsmiLogout.Name.ToString()))
                this.tsmiLogout.Text = traducciones[tsmiLogout.Name.ToString()].Texto;

            if (tsmiIdiomas.Name != null && traducciones.ContainsKey(tsmiIdiomas.Name.ToString()))
                this.tsmiIdiomas.Text = traducciones[tsmiIdiomas.Name.ToString()].Texto;

            MarcarIdioma();
        }

        private void idioma_Click(object sender, EventArgs e)
        {

            Services.SessionManager.CambiarIdioma(((BE.Idioma)((ToolStripMenuItem)sender).Tag));
            MarcarIdioma();
        }

        private void Logicar_Load(object sender, EventArgs e)
        {
           Services.SessionManager.SuscribirObservador(this);
        }

        private void Logicar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void tsmiLogin_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ValidarPermisos()
        {
            if (Services.SessionManager.IsLogged())
            {
                
                mnuAdministrarEmpleados.Visible = Services.SessionManager.GetInstance.TienePermiso(mnuAdministrarEmpleados.Tag.ToString());
                mnuAdministrarFamilias.Visible = Services.SessionManager.GetInstance.TienePermiso(mnuAdministrarFamilias.Tag.ToString());
                tsmiBackup.Enabled = Services.SessionManager.GetInstance.TienePermiso(tsmiBackup.Tag.ToString());
                tsmiRestaurar.Enabled = Services.SessionManager.GetInstance.TienePermiso(tsmiRestaurar.Tag.ToString());
                if(tsmiBackup.Enabled || tsmiRestaurar.Enabled)
                {
                    mnuRespaldo.Visible = true;
                }
                else
                {
                    mnuRespaldo.Visible = false;
                }
            }
            else
            {
                mnuAdministrarEmpleados.Visible = false;
                mnuAdministrarFamilias.Visible = false;
                tsmiBackup.Enabled = false;
                tsmiRestaurar.Enabled = false;
                mnuRespaldo.Visible = false;
            }
        }

        private void tsmiCambiarPass_Click(object sender, EventArgs e)
        {
            if (Services.SessionManager.IsLogged())
            {
                try
                {
                    var usuario = Services.SessionManager.GetInstance.Usuario;
                    _usuarioBLL.CambiarContrasena(usuario);
                    if(Services.SessionManager.GetInstance.Idioma.Nombre == "Español")
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
        }
    }
}
