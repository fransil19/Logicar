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
    public partial class AltaVehiculo : Form, Services.IIdiomaObserver
    {
        BLL.VehiculoStock _vehiculoStockBll;
        BE.Cliente cliente;
        BLL.Bitacora _bitacoraBll;
        BE.VehiculoStock vehiculo;

        public AltaVehiculo()
        {
            _vehiculoStockBll = new BLL.VehiculoStock();
            _bitacoraBll = new BLL.Bitacora();
            InitializeComponent();
            Traducir();
        }

        private void AltaVehiculo_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "HATCHBACK");
            comboSource.Add(2, "SEDAN");
            comboSource.Add(3, "SUV");
            comboSource.Add(4, "PICKUP");
            comboSource.Add(5, "FURGON");
            cmbTipoVehiculo.DataSource = new BindingSource(comboSource, null);
            cmbTipoVehiculo.DisplayMember = "Value";
            cmbTipoVehiculo.ValueMember = "Key";
            cmbTipoVehiculo.SelectedIndex = 0;
        }

        private void btnComprobarVehiculo_Click(object sender, EventArgs e)
        {
            var usuario = Services.SessionManager.GetInstance.Usuario;
            if (cliente == null)
            {
                MessageBox.Show("Por favor busque el cliente relacionado al vehiculo");
                return;
            }

            if (txtPatente.Text == "" || txtPatente.Text == null || txtMarca.Text == "" || txtMarca.Text == null ||
               txtModelo.Text == "" || txtModelo.Text == null || txtVersion.Text == "" || txtVersion.Text == null
               || txtAnio.Text == "" || txtAnio.Text == null || txtColor.Text == "" || txtColor.Text == null 
               || txtKilometraje.Text == "" || txtKilometraje.Text == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios");
                return;
            }

            vehiculo = new BE.VehiculoStock();
            vehiculo.Patente = txtPatente.Text.ToUpper();
            vehiculo.TipoVehiculo = cmbTipoVehiculo.SelectedIndex;
            vehiculo.Marca = txtMarca.Text.ToUpper();
            vehiculo.Modelo = txtModelo.Text.ToUpper();
            vehiculo.Version = txtVersion.Text.ToUpper();
            vehiculo.Anio = int.Parse(txtAnio.Text);
            vehiculo.Color = txtColor.Text;
            vehiculo.Kilometraje = int.Parse(txtKilometraje.Text);
            vehiculo.Cliente = cliente;
            

            string patenteCifrada = BLL.Cifrado.Encriptar(vehiculo.Patente, true);
            try
            {
                var vehiculoExiste = _vehiculoStockBll.BuscarVehiculoPatente(patenteCifrada);
                if (vehiculoExiste != null)
                {
                    _bitacoraBll.RegistrarBitacora(usuario, $"El vehiculo de patente = {vehiculo.Patente} ya existe", 1);
                    MessageBox.Show("EL vehiculo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool existencia = _vehiculoStockBll.VerificarExistencia(vehiculo);

                if (existencia)
                {
                    MessageBox.Show("Ya existen demasiados vehiculos similares o no se encuentra en los mas vendibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Hide();
                CalcularEstado frmCalcularEstado = new CalcularEstado();
                frmCalcularEstado.MdiParent = this.ParentForm;
                frmCalcularEstado.Show();
                frmCalcularEstado.FormClosed += new FormClosedEventHandler(Form_Closed2);

            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            if(vehiculo.Estado == null)
            {
                MessageBox.Show("Debe comprobar el estado del vehiculo primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int precio = 0;
            vehiculo.Patente = BLL.Cifrado.Encriptar(vehiculo.Patente, true);
            vehiculo.Precio = BLL.Cifrado.Encriptar(precio.ToString(), true);

            vehiculo.Dvh = BLL.DigitoVerificador.CalcularDV(vehiculo, "vehiculoStock");
            var usuario = Services.SessionManager.GetInstance.Usuario;

            _vehiculoStockBll.AltaVehiculo(vehiculo);
            _bitacoraBll.RegistrarBitacora(usuario, $"Se realizo el alta del vehiculo de patente = {BLL.Cifrado.Desencriptar(vehiculo.Patente)}", 2);

            MessageBox.Show("Se realizo el alta del vehiculo con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Seguro desea cancelar la operación?", "Cancelar operacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (opcion == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            
                BuscarCliente formBuscarCliente = new BuscarCliente();
                formBuscarCliente.MdiParent = this.ParentForm;
                formBuscarCliente.Show();
                formBuscarCliente.FormClosed += new FormClosedEventHandler(Form_Closed);

        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            BuscarCliente formBuscarCliente = (BuscarCliente)sender;
            cliente = formBuscarCliente.cliente;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            this.Show();
        }
        private void Form_Closed2(object sender, FormClosedEventArgs e)
        {
            var usuario = Services.SessionManager.GetInstance.Usuario;
            CalcularEstado frmCalcularEstado = (CalcularEstado)sender;
            if (frmCalcularEstado._dialog == DialogResult.OK)
            {
                vehiculo.Estado = frmCalcularEstado._estado;
                //MessageBox.Show("El estado del vehiculo es aceptable", "Estado OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAgregarVehiculo.Enabled = true;
                this.Show();
            }
            else
            {
                _bitacoraBll.RegistrarBitacora(usuario, $"El vehiculo de patente = {vehiculo.Patente} no tiene un estado aceptable", 1);
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

            if (lblAltaDeVehiculo.Name != null && traducciones.ContainsKey(lblAltaDeVehiculo.Name.ToString()))
                this.lblAltaDeVehiculo.Text = traducciones[lblAltaDeVehiculo.Name.ToString()].Texto;


            if (grpClienteElegido.Name != null && traducciones.ContainsKey(grpClienteElegido.Name.ToString()))
                this.grpClienteElegido.Text = traducciones[grpClienteElegido.Name.ToString()].Texto;

            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;

            if (lblApellido.Name != null && traducciones.ContainsKey(lblApellido.Name.ToString()))
                this.lblApellido.Text = traducciones[lblApellido.Name.ToString()].Texto;

            if (grpDatosDelVehiculo.Name != null && traducciones.ContainsKey(grpDatosDelVehiculo.Name.ToString()))
                this.grpDatosDelVehiculo.Text = traducciones[grpDatosDelVehiculo.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (lblPatente.Name != null && traducciones.ContainsKey(lblPatente.Name.ToString()))
                this.lblPatente.Text = traducciones[lblPatente.Name.ToString()].Texto;

            if (lblMarca.Name != null && traducciones.ContainsKey(lblMarca.Name.ToString()))
                this.lblMarca.Text = traducciones[lblMarca.Name.ToString()].Texto;

            if (lblTipoDeVehiculo.Name != null && traducciones.ContainsKey(lblTipoDeVehiculo.Name.ToString()))
                this.lblTipoDeVehiculo.Text = traducciones[lblTipoDeVehiculo.Name.ToString()].Texto;

            if (lblModelo.Name != null && traducciones.ContainsKey(lblModelo.Name.ToString()))
                this.lblModelo.Text = traducciones[lblModelo.Name.ToString()].Texto;

            if (lblAnio.Name != null && traducciones.ContainsKey(lblAnio.Name.ToString()))
                this.lblAnio.Text = traducciones[lblAnio.Name.ToString()].Texto;

            if (lblVersion.Name != null && traducciones.ContainsKey(lblVersion.Name.ToString()))
                this.lblVersion.Text = traducciones[lblVersion.Name.ToString()].Texto;

            if (lblColor.Name != null && traducciones.ContainsKey(lblColor.Name.ToString()))
                this.lblColor.Text = traducciones[lblColor.Name.ToString()].Texto;

            if (lblKilometraje.Name != null && traducciones.ContainsKey(lblKilometraje.Name.ToString()))
                this.lblKilometraje.Text = traducciones[lblKilometraje.Name.ToString()].Texto;

            if (btnComprobarVehiculo.Name != null && traducciones.ContainsKey(btnComprobarVehiculo.Name.ToString()))
                this.btnComprobarVehiculo.Text = traducciones[btnComprobarVehiculo.Name.ToString()].Texto;

            if (btnAgregarVehiculo.Name != null && traducciones.ContainsKey(btnAgregarVehiculo.Name.ToString()))
                this.btnAgregarVehiculo.Text = traducciones[btnAgregarVehiculo.Name.ToString()].Texto;
        }

        private void AltaVehiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
