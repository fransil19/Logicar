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

        private void actualizarGrilla()
        {
            grillaEmpleado.DataSource = null;
            List<BE.Empleado> lista = _empleadoBLL.ListarEmpleados();
            grillaEmpleado.DataSource = lista.Select(r => new
            {
                Legajo = r.legajo,
                Usuario = BLL.Cifrado.Desencriptar(r.usuario.usuario),
                Nombre = r.nombre,
                Apellido = r.apellido,
                TipoDocumento = r.tipoDocumento,
                NroDocumento = r.nroDocumento,
                Domicilio = r.domicilio,
                Telefono = r.telefono,
                Email = r.email,
                Estado = r.estado,
            }).ToList();
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {
            actualizarGrilla();
        }

        private void grillaEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuarioSel.Text = grillaEmpleado.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
