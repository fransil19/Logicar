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
    public partial class AltaEmpleado : Form, Services.IIdiomaObserver
    {
        public AltaEmpleado()
        {
            InitializeComponent();
            Traducir();
        }

        private void AltaEmpleado_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "DNI");
            comboSource.Add(2, "CUIL");
            comboSource.Add(3, "CUIT");
            comboSource.Add(4, "LIBRETA CIVICA");
            cmbTDoc.DataSource = new BindingSource(comboSource, null);
            cmbTDoc.DisplayMember = "Value";
            cmbTDoc.ValueMember = "Key";
            cmbTDoc.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BE.Empleado empleado = new BE.Empleado();

            if(txtNombre.Text == "" || txtNombre.Text == null || txtApellido.Text == "" || txtApellido.Text == null ||
               txtDomicilio.Text == "" || txtDomicilio.Text == null || txtNroDoc.Text == "" || txtNroDoc.Text == null
               || txtEmail.Text == "" || txtEmail.Text == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios");
                return;
            }
            
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string domicilio = txtDomicilio.Text;
            var tipoDoc = (KeyValuePair<int,string>) cmbTDoc.SelectedItem;
            long nroDoc = long.Parse(txtNroDoc.Text);
            string email = txtEmail.Text;
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                long telefono = long.Parse(txtTelefono.Text);
                empleado.telefono = telefono;

            }
            

            empleado.nombre = nombre.ToUpper();
            empleado.apellido = apellido.ToUpper();
            empleado.domicilio = domicilio;
            empleado.tipoDocumento = tipoDoc.Key;
            empleado.nroDocumento = nroDoc;
            empleado.email = email;
            empleado.estado = 1;

            BLL.Empleado bllEmpleado = new BLL.Empleado();
            bllEmpleado.AltaEmpleado(empleado);
            var dialogResult = MessageBox.Show("Se cargo el empleado");
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

        private void label3_Click(object sender, EventArgs e)
        {

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

            if (lblAltaDeEmpleado.Name != null && traducciones.ContainsKey(lblAltaDeEmpleado.Name.ToString()))
                this.lblAltaDeEmpleado.Text = traducciones[lblAltaDeEmpleado.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (lblApellido.Name != null && traducciones.ContainsKey(lblApellido.Name.ToString()))
                this.lblApellido.Text = traducciones[lblApellido.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (lblTipoDoc.Name != null && traducciones.ContainsKey(lblTipoDoc.Name.ToString()))
                this.lblTipoDoc.Text = traducciones[lblTipoDoc.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (lblNroDoc.Name != null && traducciones.ContainsKey(lblNroDoc.Name.ToString()))
                this.lblNroDoc.Text = traducciones[lblNroDoc.Name.ToString()].Texto;

            if (lblDomicilio.Name != null && traducciones.ContainsKey(lblDomicilio.Name.ToString()))
                this.lblDomicilio.Text = traducciones[lblDomicilio.Name.ToString()].Texto;

            if (lblEmail.Name != null && traducciones.ContainsKey(lblEmail.Name.ToString()))
                this.lblEmail.Text = traducciones[lblEmail.Name.ToString()].Texto;

            if (lblTelefono.Name != null && traducciones.ContainsKey(lblTelefono.Name.ToString()))
                this.lblTelefono.Text = traducciones[lblTelefono.Name.ToString()].Texto;
        }

        private void AltaEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
