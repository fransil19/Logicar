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
    public partial class ModificarEmpleado : Form
    {
        BE.Empleado _empleado;
        public ModificarEmpleado(BE.Empleado empleado)
        {
            _empleado = empleado;
            InitializeComponent();
        }

        private void lblModificarEmpleado_Load(object sender, EventArgs e)
        {
            txtLegajo.Text = _empleado.legajo.ToString();
            txtNombre.Text = _empleado.nombre;
            txtApellido.Text = _empleado.apellido;
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "DNI");
            comboSource.Add(2, "CUIL");
            comboSource.Add(3, "CUIT");
            comboSource.Add(4, "LIBRETA CIVICA");
            cmbTDoc.DataSource = new BindingSource(comboSource, null);
            cmbTDoc.DisplayMember = "Value";
            cmbTDoc.ValueMember = "Key";
            cmbTDoc.SelectedIndex = 0;
            cmbTDoc.SelectedItem = _empleado.tipoDocumento-1;
            txtNroDoc.Text = _empleado.nroDocumento.ToString();
            txtDomicilio.Text = _empleado.domicilio;
            txtEmail.Text = _empleado.email;
            txtTelefono.Text = _empleado.telefono.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtNombre.Text == null || txtApellido.Text == "" || txtApellido.Text == null ||
               txtDomicilio.Text == "" || txtDomicilio.Text == null || txtNroDoc.Text == "" || txtNroDoc.Text == null
               || txtEmail.Text == "" || txtEmail.Text == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios");
                return;
            }

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string domicilio = txtDomicilio.Text;
            var tipoDoc = (KeyValuePair<int, string>)cmbTDoc.SelectedItem;
            long nroDoc = long.Parse(txtNroDoc.Text);
            string email = txtEmail.Text;
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                long telefono = long.Parse(txtTelefono.Text);
                _empleado.telefono = telefono;

            }
            _empleado.nombre = nombre;
            _empleado.apellido = apellido;
            _empleado.domicilio = domicilio;
            _empleado.tipoDocumento = tipoDoc.Key;
            _empleado.nroDocumento = nroDoc;
            _empleado.email = email;

            BLL.Empleado bllEmpleado = new BLL.Empleado();
            bllEmpleado.ActualizarEmpleado(_empleado);
            var dialogResult = MessageBox.Show("Se actualizo el empleado");
            this.Hide();
            if (dialogResult == DialogResult.Cancel)
            {
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Seguro desea cancelar la operación?", "Cancelar operacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (opcion == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
