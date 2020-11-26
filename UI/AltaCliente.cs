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
    public partial class AltaCliente : Form, Services.IIdiomaObserver
    {
        public AltaCliente()
        {
            InitializeComponent();
            Traducir();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "DNI");
            comboSource.Add(2, "CUIL");
            comboSource.Add(3, "CUIT");
            comboSource.Add(4, "LIBRETA CIVICA");
            cmbTipoDoc.DataSource = new BindingSource(comboSource, null);
            cmbTipoDoc.DisplayMember = "Value";
            cmbTipoDoc.ValueMember = "Key";
            cmbTipoDoc.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BE.Cliente _cliente = new BE.Cliente();

            if (txtNombre.Text == "" || txtNombre.Text == null || txtApellido.Text == "" || txtApellido.Text == null ||
               txtDomicilio.Text == "" || txtDomicilio.Text == null || txtNroDoc.Text == "" || txtNroDoc.Text == null
               || txtEmail.Text == "" || txtEmail.Text == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios");
                return;
            }

            if (String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Por favor debe introducir un email o un telefono de contacto");
                return;
            }

            _cliente.Nombre = txtNombre.Text.ToUpper();
            _cliente.Apellido = txtApellido.Text.ToUpper();
            var tDoc = (KeyValuePair<int, string>)cmbTipoDoc.SelectedItem;
            _cliente.TipoDoc = tDoc.Key;
            _cliente.NroDoc = long.Parse(txtNroDoc.Text);
            _cliente.Domicilio = txtDomicilio.Text;
            _cliente.Email = txtEmail.Text;
            _cliente.Estado = true;
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                _cliente.Telefono = long.Parse(txtTelefono.Text);
            }

            BLL.Cliente _clienteBll = new BLL.Cliente();
            try
            {
                _clienteBll.AltaCliente(_cliente);
                var dialogResult = MessageBox.Show("Se cargo el cliente");
                //this.Hide();
                if (dialogResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (lblAltaCliente.Name != null && traducciones.ContainsKey(lblAltaCliente.Name.ToString()))
                this.lblAltaCliente.Text = traducciones[lblAltaCliente.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (lblApellido.Name != null && traducciones.ContainsKey(lblApellido.Name.ToString()))
                this.lblApellido.Text = traducciones[lblApellido.Name.ToString()].Texto;

            if (btnAgregar.Name != null && traducciones.ContainsKey(btnAgregar.Name.ToString()))
                this.btnAgregar.Text = traducciones[btnAgregar.Name.ToString()].Texto;

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

        private void AltaCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
