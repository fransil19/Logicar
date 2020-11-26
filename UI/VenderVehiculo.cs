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
    public partial class VenderVehiculo : Form, Services.IIdiomaObserver
    {
        BE.Cliente cliente;
        BLL.VehiculoStock _vehiculoStockBll;
        BE.VehiculoStock _vehiculo;
        BLL.Bitacora _bitacoraBll;
        BLL.Venta _ventaBLL;
        public VenderVehiculo()
        {
            _bitacoraBll = new BLL.Bitacora();
            _vehiculoStockBll = new BLL.VehiculoStock();
            _ventaBLL = new BLL.Venta();
            InitializeComponent();
            Traducir();
        }

        private void VenderVehiculo_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            txtPrecioVenta.Enabled = false;

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscarCliente formBuscarCliente = new BuscarCliente();
            formBuscarCliente.MdiParent = this.ParentForm;
            formBuscarCliente.Show();
            formBuscarCliente.FormClosed += new FormClosedEventHandler(Form_Closed);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string patenteCifrado = BLL.Cifrado.Encriptar(txtPatente.Text.ToUpper(), true);
            try
            {
                _vehiculo = _vehiculoStockBll.BuscarVehiculoDisponible(patenteCifrado);
                txtTipoVehiculo.Text = _vehiculo.TipoVehiculo.ToString();
                txtMarca.Text = _vehiculo.Marca;
                txtModelo.Text = _vehiculo.Modelo;
                txtVersion.Text = _vehiculo.Version;
                txtKilometraje.Text = _vehiculo.Kilometraje.ToString();
                txtPrecioVenta.Text = BLL.Cifrado.Desencriptar(_vehiculo.Precio);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + txtPatente.Text.ToUpper(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var usuario = Services.SessionManager.GetInstance.Usuario;
                _bitacoraBll.RegistrarBitacora(usuario, $"No se encuentra el vehiculo de patente = {txtPatente.Text.ToUpper()}", 2);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if(cliente != null && _vehiculo != null)
            {
                BE.Venta _venta = new BE.Venta();
                _venta.Cliente = cliente;
                _venta.Vehiculo = _vehiculo;
                _venta.Precio = int.Parse(BLL.Cifrado.Desencriptar(_vehiculo.Precio));
                var usuario = Services.SessionManager.GetInstance.Usuario;
                BLL.Empleado _empleadoBll = new BLL.Empleado();
                _venta.Empleado = _empleadoBll.GetEmpleadoUsuario(usuario);
                _venta.Fecha = DateTime.Now;

                _ventaBLL.RegistrarVenta(_venta);
                _bitacoraBll.RegistrarBitacora(usuario, $"Se realizo la venta del vehiculo de patente = {txtPatente.Text.ToUpper()} al cliente de documento = {cliente.NroDoc}", 3);
                MessageBox.Show("Se registro la venta con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe asociar un cliente o un vehiculo para proceder con la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            if (lblVenderVehiculo.Name != null && traducciones.ContainsKey(lblVenderVehiculo.Name.ToString()))
                this.lblVenderVehiculo.Text = traducciones[lblVenderVehiculo.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (lblApellido.Name != null && traducciones.ContainsKey(lblApellido.Name.ToString()))
                this.lblApellido.Text = traducciones[lblApellido.Name.ToString()].Texto;

            if (grpClienteElegido.Name != null && traducciones.ContainsKey(grpClienteElegido.Name.ToString()))
                this.grpClienteElegido.Text = traducciones[grpClienteElegido.Name.ToString()].Texto;

            if (grpDatosDelVehiculo.Name != null && traducciones.ContainsKey(grpDatosDelVehiculo.Name.ToString()))
                this.grpDatosDelVehiculo.Text = traducciones[grpDatosDelVehiculo.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (btnVender.Name != null && traducciones.ContainsKey(btnVender.Name.ToString()))
                this.btnVender.Text = traducciones[btnVender.Name.ToString()].Texto;

            if (lblPatente.Name != null && traducciones.ContainsKey(lblPatente.Name.ToString()))
                this.lblPatente.Text = traducciones[lblPatente.Name.ToString()].Texto;

            if (lblTipoDeVehiculo.Name != null && traducciones.ContainsKey(lblTipoDeVehiculo.Name.ToString()))
                this.lblTipoDeVehiculo.Text = traducciones[lblTipoDeVehiculo.Name.ToString()].Texto;

            if (lblMarca.Name != null && traducciones.ContainsKey(lblMarca.Name.ToString()))
                this.lblMarca.Text = traducciones[lblMarca.Name.ToString()].Texto;

            if (lblModelo.Name != null && traducciones.ContainsKey(lblModelo.Name.ToString()))
                this.lblModelo.Text = traducciones[lblModelo.Name.ToString()].Texto;

            if (lblVersion.Name != null && traducciones.ContainsKey(lblVersion.Name.ToString()))
                this.lblVersion.Text = traducciones[lblVersion.Name.ToString()].Texto;

            if (lblKilometraje.Name != null && traducciones.ContainsKey(lblKilometraje.Name.ToString()))
                this.lblKilometraje.Text = traducciones[lblKilometraje.Name.ToString()].Texto;

            if (lblPrecioVenta.Name != null && traducciones.ContainsKey(lblPrecioVenta.Name.ToString()))
                this.lblPrecioVenta.Text = traducciones[lblPrecioVenta.Name.ToString()].Texto;
        }

        private void VenderVehiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            BuscarCliente formBuscarCliente = (BuscarCliente)sender;
            if (formBuscarCliente.cliente != null)
            {
                cliente = formBuscarCliente.cliente;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                this.Show();
            }
            else
            {
                this.Show();
            }
            
        }
    }
}
