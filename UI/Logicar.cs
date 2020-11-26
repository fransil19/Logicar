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

            if (tsmiCambiarPass.Name != null && traducciones.ContainsKey(tsmiCambiarPass.Name.ToString()))
                this.tsmiCambiarPass.Text = traducciones[tsmiCambiarPass.Name.ToString()].Texto;

            if (mnuAdministrarEmpleados.Name != null && traducciones.ContainsKey(mnuAdministrarEmpleados.Name.ToString()))
                this.mnuAdministrarEmpleados.Text = traducciones[mnuAdministrarEmpleados.Name.ToString()].Texto;

            if (mnuAdministrarFamilias.Name != null && traducciones.ContainsKey(mnuAdministrarFamilias.Name.ToString()))
                this.mnuAdministrarFamilias.Text = traducciones[mnuAdministrarFamilias.Name.ToString()].Texto;

            if (mnuAdministrarClientes.Name != null && traducciones.ContainsKey(mnuAdministrarClientes.Name.ToString()))
                this.mnuAdministrarClientes.Text = traducciones[mnuAdministrarClientes.Name.ToString()].Texto;

            if (mnuBitacora.Name != null && traducciones.ContainsKey(mnuBitacora.Name.ToString()))
                this.mnuBitacora.Text = traducciones[mnuBitacora.Name.ToString()].Texto;

            if (mnuCompras.Name != null && traducciones.ContainsKey(mnuCompras.Name.ToString()))
                this.mnuCompras.Text = traducciones[mnuCompras.Name.ToString()].Texto;

            if (mnuReportes.Name != null && traducciones.ContainsKey(mnuReportes.Name.ToString()))
                this.mnuReportes.Text = traducciones[mnuReportes.Name.ToString()].Texto;

            if (mnuRespaldo.Name != null && traducciones.ContainsKey(mnuRespaldo.Name.ToString()))
                this.mnuRespaldo.Text = traducciones[mnuRespaldo.Name.ToString()].Texto;

            if (mnuVentas.Name != null && traducciones.ContainsKey(mnuVentas.Name.ToString()))
                this.mnuVentas.Text = traducciones[mnuVentas.Name.ToString()].Texto;

            if (tsmiAdquirirVehiculo.Name != null && traducciones.ContainsKey(tsmiAdquirirVehiculo.Name.ToString()))
                this.tsmiAdquirirVehiculo.Text = traducciones[tsmiAdquirirVehiculo.Name.ToString()].Texto;

            if (tsmiAltaDeVehiculo.Name != null && traducciones.ContainsKey(tsmiAltaDeVehiculo.Name.ToString()))
                this.tsmiAltaDeVehiculo.Text = traducciones[tsmiAltaDeVehiculo.Name.ToString()].Texto;

            if (tsmiBackup.Name != null && traducciones.ContainsKey(tsmiBackup.Name.ToString()))
                this.tsmiBackup.Text = traducciones[tsmiBackup.Name.ToString()].Texto;

            if (tsmiReporteDeVentas.Name != null && traducciones.ContainsKey(tsmiReporteDeVentas.Name.ToString()))
                this.tsmiReporteDeVentas.Text = traducciones[tsmiReporteDeVentas.Name.ToString()].Texto;

            if (tsmiRestaurar.Name != null && traducciones.ContainsKey(tsmiRestaurar.Name.ToString()))
                this.tsmiRestaurar.Text = traducciones[tsmiRestaurar.Name.ToString()].Texto;

            if (tsmiVenderVehiculo.Name != null && traducciones.ContainsKey(tsmiVenderVehiculo.Name.ToString()))
                this.tsmiVenderVehiculo.Text = traducciones[tsmiVenderVehiculo.Name.ToString()].Texto;

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
                mnuBitacora.Visible = Services.SessionManager.GetInstance.TienePermiso(mnuBitacora.Tag.ToString());

                tsmiAdquirirVehiculo.Enabled = Services.SessionManager.GetInstance.TienePermiso(tsmiAdquirirVehiculo.Tag.ToString());
                tsmiAltaDeVehiculo.Enabled = Services.SessionManager.GetInstance.TienePermiso(tsmiAltaDeVehiculo.Tag.ToString());
                if (tsmiAdquirirVehiculo.Enabled || tsmiAltaDeVehiculo.Enabled)
                {
                    mnuCompras.Visible = true;
                }
                else
                {
                    mnuCompras.Visible = false;
                }

                tsmiVenderVehiculo.Enabled = Services.SessionManager.GetInstance.TienePermiso(tsmiVenderVehiculo.Tag.ToString());
                if (tsmiVenderVehiculo.Enabled)
                {
                    mnuVentas.Visible = true;
                }
                else
                {
                    mnuVentas.Visible = false;
                }

                tsmiReporteDeVentas.Enabled = Services.SessionManager.GetInstance.TienePermiso(tsmiReporteDeVentas.Tag.ToString());
                if (tsmiReporteDeVentas.Enabled)
                {
                    mnuReportes.Visible = true;
                }
                else
                {
                    mnuReportes.Visible = false;
                }

                mnuAdministrarClientes.Enabled = Services.SessionManager.GetInstance.TienePermiso(mnuAdministrarClientes.Tag.ToString());
            }
            else
            {
                mnuAdministrarEmpleados.Visible = false;
                mnuAdministrarFamilias.Visible = false;
                tsmiBackup.Enabled = false;
                tsmiRestaurar.Enabled = false;
                mnuRespaldo.Visible = false;
                mnuBitacora.Visible = false;
                tsmiAdquirirVehiculo.Enabled = false;
                tsmiAltaDeVehiculo.Enabled = false;
                mnuCompras.Visible = false;
                tsmiVenderVehiculo.Enabled = false;
                mnuVentas.Visible = false;
                tsmiReporteDeVentas.Enabled = false;
                mnuReportes.Visible = false;
                mnuAdministrarClientes.Enabled = false;
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

        private void tsmiBackup_Click(object sender, EventArgs e)
        {
            Backup frmBackup = new Backup();
            frmBackup.MdiParent = this;
            frmBackup.Show();
        }

        private void tsmiRestaurar_Click(object sender, EventArgs e)
        {
            Restaurar frmRestaurar = new Restaurar();
            frmRestaurar.MdiParent = this;
            frmRestaurar.Show();
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            BLL.Bitacora _bitacoraBll = new BLL.Bitacora();
            var usuario = Services.SessionManager.GetInstance.Usuario;
            _bitacoraBll.RegistrarBitacora(usuario, $@"El usuario {BLL.Cifrado.Encriptar(usuario.usuario,true)} salio del sistema", 3);
            Services.SessionManager.Logout();
            this.Close();
        }

        private void mnuBitacora_Click(object sender, EventArgs e)
        {
            Bitacora formBitacora = new Bitacora();
            formBitacora.MdiParent = this;
            formBitacora.Show();
        }

        private void tsmiAdquirirVehiculo_Click(object sender, EventArgs e)
        {
            AdquirirVehiculo formAdquirirVehiculo = new AdquirirVehiculo();
            formAdquirirVehiculo.MdiParent = this;
            formAdquirirVehiculo.Show();
        }

        private void tsmiAltaDeVehiculo_Click(object sender, EventArgs e)
        {
            AltaVehiculo formAltaVehiculo = new AltaVehiculo();
            formAltaVehiculo.MdiParent = this;
            formAltaVehiculo.Show();
        }

        private void tsmiVenderVehiculo_Click(object sender, EventArgs e)
        {
            VenderVehiculo formVenderVehiculo = new VenderVehiculo();
            formVenderVehiculo.MdiParent = this;
            formVenderVehiculo.Show();
        }

        private void tsmiReporteDeVentas_Click(object sender, EventArgs e)
        {
            ReporteVentas formReporteVentas = new ReporteVentas();
            formReporteVentas.MdiParent = this;
            formReporteVentas.Show();
        }

        private void mnuAdministrarClientes_Click(object sender, EventArgs e)
        {
            ListaClientes formListaClientes = new ListaClientes();
            formListaClientes.MdiParent = this;
            formListaClientes.Show();
        }
    }
}
