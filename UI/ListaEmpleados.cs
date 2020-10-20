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
    public partial class ListaEmpleados : Form
    {
        BLL.Empleado _empleadoBLL;
        public ListaEmpleados()
        {
            _empleadoBLL = new BLL.Empleado();
            InitializeComponent();
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
    }
}
