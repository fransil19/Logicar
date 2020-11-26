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
    public partial class ModificarEmpleado : Form, Services.IIdiomaObserver
    {
        BE.Empleado _empleado;
        public ModificarEmpleado(BE.Empleado empleado)
        {
            _empleado = empleado;
            InitializeComponent();
            Traducir();
        }

        private void lblModificarEmpleado_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            txtLegajo.Text = _empleado.legajo.ToString().PadLeft(6, '0');
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

            if (lblModificarEmpleado.Name != null && traducciones.ContainsKey(lblModificarEmpleado.Name.ToString()))
                this.lblModificarEmpleado.Text = traducciones[lblModificarEmpleado.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (lblApellido.Name != null && traducciones.ContainsKey(lblApellido.Name.ToString()))
                this.lblApellido.Text = traducciones[lblApellido.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (lblTDocumento.Name != null && traducciones.ContainsKey(lblTDocumento.Name.ToString()))
                this.lblTDocumento.Text = traducciones[lblTDocumento.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (lblNDocumento.Name != null && traducciones.ContainsKey(lblNDocumento.Name.ToString()))
                this.lblNDocumento.Text = traducciones[lblNDocumento.Name.ToString()].Texto;

            if (lblDomicilio.Name != null && traducciones.ContainsKey(lblDomicilio.Name.ToString()))
                this.lblDomicilio.Text = traducciones[lblDomicilio.Name.ToString()].Texto;

            if (lblEmail.Name != null && traducciones.ContainsKey(lblEmail.Name.ToString()))
                this.lblEmail.Text = traducciones[lblEmail.Name.ToString()].Texto;

            if (lblTelefono.Name != null && traducciones.ContainsKey(lblTelefono.Name.ToString()))
                this.lblTelefono.Text = traducciones[lblTelefono.Name.ToString()].Texto;
        }

        private void ModificarEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
