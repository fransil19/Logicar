using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace UI
{
    public partial class ListaEmpleados : Form, Services.IIdiomaObserver
    {
        BLL.Empleado _empleadoBLL;
        BLL.Usuario _usuarioBll;
        BLL.Permiso _permisoBll;
        public ListaEmpleados()
        {
            _usuarioBll = new BLL.Usuario();
            _permisoBll = new BLL.Permiso();
            _empleadoBLL = new BLL.Empleado();
            InitializeComponent();
            Traducir();
        }

        private void ActualizarGrilla()
        {
            grillaEmpleado.DataSource = null;
            List<BE.Empleado> lista = _empleadoBLL.ListarEmpleados();
            grillaEmpleado.DataSource = lista.Select(r => new
            {
                Legajo = r.legajo,
                Usuario = BLL.Cifrado.Desencriptar(r.usuario.usuario),
                Nombre = r.nombre,
                Apellido = r.apellido,
                TipoDocumento = r.tipoDocumento == 1 ? "DNI" : r.tipoDocumento == 2 ? "CUIL" : r.tipoDocumento == 3 ? "CUIT" : r.tipoDocumento == 4 ? "LIBRETA CIVICA" : "DESCONOCIDO",
                NroDocumento = r.nroDocumento,
                Domicilio = r.domicilio,
                Telefono = r.telefono,
                Email = r.email,
                Estado = r.estado == 1 ? "ACTIVO" : "INACTIVO",
            }).ToList();
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            ActualizarGrilla();
        }

        private void grillaEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuarioSel.Text = grillaEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaEmpleado formAEmpleado = new AltaEmpleado();
            formAEmpleado.MdiParent = this.ParentForm;
            formAEmpleado.Show();
            formAEmpleado.FormClosed += new FormClosedEventHandler(Form_Closed);

           
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaEmpleado.CurrentRow.Cells[0].Value;
            var listaEmpleados = _empleadoBLL.ListarEmpleados();
            var empleado = listaEmpleados.Where(i => i.legajo == indice).FirstOrDefault();
            this.Hide();
            ModificarEmpleado formMEmpleado = new ModificarEmpleado(empleado);
            formMEmpleado.MdiParent = this.ParentForm;
            formMEmpleado.Show();
            formMEmpleado.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnAsignarPat_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaEmpleado.CurrentRow.Cells[0].Value;
            var listaEmpleados = _empleadoBLL.ListarEmpleados();
            var empleado = listaEmpleados.Where(i => i.legajo == indice).FirstOrDefault();
            this.Hide();
            AsignarPatentes formAsigPatentes = new AsignarPatentes(empleado);
            formAsigPatentes.MdiParent = this.ParentForm;
            formAsigPatentes.Show();
            formAsigPatentes.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnAdminFam_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaEmpleado.CurrentRow.Cells[0].Value;
            var listaEmpleados = _empleadoBLL.ListarEmpleados();
            var empleado = listaEmpleados.Where(i => i.legajo == indice).FirstOrDefault();
            this.Hide();
            AsignarFamilias formAsigFamilias = new AsignarFamilias(empleado);
            formAsigFamilias.MdiParent = this.ParentForm;
            formAsigFamilias.Show();
            formAsigFamilias.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaEmpleado.CurrentRow.Cells[0].Value;
            var listaEmpleados = _empleadoBLL.ListarEmpleados();
            BE.Empleado empleado = listaEmpleados.Where(i => i.legajo == indice).FirstOrDefault();
            if(empleado.estado == 0)
            {
                MessageBox.Show("El empleado ya se encuentra inactivo");
                return;
            }
            try
            {
                _empleadoBLL.EliminarEmpleado(empleado);
                MessageBox.Show("Empleado y usuario eliminado ");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            ActualizarGrilla();
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaEmpleado.CurrentRow.Cells[0].Value;
            var listaEmpleados = _empleadoBLL.ListarEmpleados();
            BE.Empleado empleado = listaEmpleados.Where(i => i.legajo == indice).FirstOrDefault();
            try
            {
                _usuarioBll.DesbloquearUsuario(empleado.usuario);
                MessageBox.Show("Se reestablecio el usuario");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            ActualizarGrilla();
        }

        public void UpdateLanguage(BE.Idioma idioma)
        {
            Traducir();
        }
        private void Traducir()
        {
            BE.Idioma idioma = null;
            if (Services.SessionManager.IsLogged())
                idioma = Services.SessionManager.GetInstance.Idioma;


            var traducciones = Services.Traductor.ObtenerTraducciones(idioma);

            if (lblListaEmpleados.Name != null && traducciones.ContainsKey(lblListaEmpleados.Name.ToString()))
                this.lblListaEmpleados.Text = traducciones[lblListaEmpleados.Name.ToString()].Texto;


            if (lblUsuario.Name != null && traducciones.ContainsKey(lblUsuario.Name.ToString()))
                this.lblUsuario.Text = traducciones[lblUsuario.Name.ToString()].Texto;


            if (grpUsuarioElegido.Name != null && traducciones.ContainsKey(grpUsuarioElegido.Name.ToString()))
                this.grpUsuarioElegido.Text = traducciones[grpUsuarioElegido.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (btnModificar.Name != null && traducciones.ContainsKey(btnModificar.Name.ToString()))
                this.btnModificar.Text = traducciones[btnModificar.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (btnEliminar.Name != null && traducciones.ContainsKey(btnEliminar.Name.ToString()))
                this.btnEliminar.Text = traducciones[btnEliminar.Name.ToString()].Texto;

            if (btnDesbloquear.Name != null && traducciones.ContainsKey(btnDesbloquear.Name.ToString()))
                this.btnDesbloquear.Text = traducciones[btnDesbloquear.Name.ToString()].Texto;

            if (btnAdminFam.Name != null && traducciones.ContainsKey(btnAdminFam.Name.ToString()))
                this.btnAdminFam.Text = traducciones[btnAdminFam.Name.ToString()].Texto;

            if (btnAdminPat.Name != null && traducciones.ContainsKey(btnAdminPat.Name.ToString()))
                this.btnAdminPat.Text = traducciones[btnAdminPat.Name.ToString()].Texto;

            if (btnAgregarEmpleado.Name != null && traducciones.ContainsKey(btnAgregarEmpleado.Name.ToString()))
                this.btnAgregarEmpleado.Text = traducciones[btnAgregarEmpleado.Name.ToString()].Texto;
        }

        private void ListaEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
