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
    public partial class BuscarCliente : Form, Services.IIdiomaObserver
    {

        BLL.Cliente _clienteBll;
        BLL.Bitacora _bitacoraBll;
        public BE.Cliente cliente { get; set; } 
        public BuscarCliente()
        {
            _clienteBll = new BLL.Cliente();
            _bitacoraBll = new BLL.Bitacora();
            InitializeComponent();
            Traducir();
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNroDoc.Text))
            {
                MessageBox.Show("Por favor debe introducir un numero de documento");
                return;
            }
            if (!int.TryParse(txtNroDoc.Text, out int n))
            {
                MessageBox.Show("Por favor debe introducir un formato numerico para el numero de documento");
                return;
            }

            var tDoc = (KeyValuePair<int, string>)cmbTipoDoc.SelectedItem;
            int tipoDoc = tDoc.Key;
            long nroDoc = long.Parse(txtNroDoc.Text);

            try
            {
                cliente = _clienteBll.BuscarCliente(tipoDoc, nroDoc);
                var opcion = MessageBox.Show("Cliente Encontrado", $@"Se encontro el cliente = {cliente.Apellido},{cliente.Nombre}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (opcion == DialogResult.OK)
                {
                    this.Close();
                }
            }   
            catch(Exception exp)
            {
                var usuario = Services.SessionManager.GetInstance.Usuario;
                _bitacoraBll.RegistrarBitacora(usuario,$"No se encontro el cliente de documento = {nroDoc}",2);
                var opcion = MessageBox.Show(exp.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (opcion == DialogResult.OK)
                {
                    this.Close();
                }
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

            if (lblBuscarCliente.Name != null && traducciones.ContainsKey(lblBuscarCliente.Name.ToString()))
                this.lblBuscarCliente.Text = traducciones[lblBuscarCliente.Name.ToString()].Texto;


            if (lblTipoDoc.Name != null && traducciones.ContainsKey(lblTipoDoc.Name.ToString()))
                this.lblTipoDoc.Text = traducciones[lblTipoDoc.Name.ToString()].Texto;


            if (lblNroDoc.Name != null && traducciones.ContainsKey(lblNroDoc.Name.ToString()))
                this.lblNroDoc.Text = traducciones[lblNroDoc.Name.ToString()].Texto;

            if (btnBuscar.Name != null && traducciones.ContainsKey(btnBuscar.Name.ToString()))
                this.btnBuscar.Text = traducciones[btnBuscar.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;
        }

        private void BuscarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
