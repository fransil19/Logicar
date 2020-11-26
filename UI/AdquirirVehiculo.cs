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
    public partial class AdquirirVehiculo : Form, Services.IIdiomaObserver
    {
        BLL.VehiculoStock _vehiculoStockBll;
        BE.Cliente cliente;
        BLL.Bitacora _bitacoraBll;
        BE.VehiculoStock _vehiculo;
        BLL.Compra _compraBll;

        int precioCompraSugerido;
        public AdquirirVehiculo()
        {
            _vehiculoStockBll = new BLL.VehiculoStock();
            _bitacoraBll = new BLL.Bitacora();
            _compraBll = new BLL.Compra();
            InitializeComponent();
            Traducir();
        }

        private void AdquirirVehiculo_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "COMPRA");
            comboSource.Add(2, "CONSIGNACION");
            cmbFormaAdquisicion.DataSource = new BindingSource(comboSource, null);
            cmbFormaAdquisicion.DisplayMember = "Value";
            cmbFormaAdquisicion.ValueMember = "Key";
            cmbFormaAdquisicion.SelectedIndex = 0;

            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;

            /*prueba
            List<BE.VehiculoMercado> lista = new List<BE.VehiculoMercado>();
            BE.VehiculoMercado _vm = new BE.VehiculoMercado();
            _vm.Id = 1;
            _vm.Marca = "FORD";
            _vm.Modelo = "FOCUS";
            _vm.TipoVehiculo = 1;
            _vm.Version = "S 17";
            _vm.PrecioMercado = 1000000;
            _vm.UnidadesVendidas = 1000;

            BE.VehiculoMercado _vm2 = new BE.VehiculoMercado();
            _vm2.Id = 1;
            _vm2.Marca = "PEUGEOT";
            _vm2.Modelo = "208";
            _vm2.TipoVehiculo = 1;
            _vm2.Version = "ACTIVE 18";
            _vm2.PrecioMercado = 875000;
            _vm2.UnidadesVendidas = 4000;
            lista.Add(_vm);
            lista.Add(_vm2);
            BLL.VehiculoMercado _vmBLL = new BLL.VehiculoMercado();
            _vmBLL.Prueba(lista);*/
            
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

            string patenteCifrado = BLL.Cifrado.Encriptar(txtPatente.Text.ToUpper(),true);
            try
            {
                _vehiculo = _vehiculoStockBll.BuscarVehiculoOfrecidoPatente(patenteCifrado);
                txtTipoVehiculo.Text = _vehiculo.TipoVehiculo.ToString();
                txtMarca.Text = _vehiculo.Marca;
                txtModelo.Text = _vehiculo.Modelo;
                txtVersion.Text = _vehiculo.Version;
                txtKilometraje.Text = _vehiculo.Kilometraje.ToString();
                
                
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message+ txtPatente.Text.ToUpper(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var usuario = Services.SessionManager.GetInstance.Usuario;
                _bitacoraBll.RegistrarBitacora(usuario, $"No se encuentra el vehiculo de patente = {txtPatente.Text.ToUpper()}", 2);
            }
        }

        private void btnCalcularPrecios_Click(object sender, EventArgs e)
        {
            var formaAdquisicion = cmbFormaAdquisicion.SelectedIndex;
            try
            {
                if (formaAdquisicion != 0)
                {
                    this.precioCompraSugerido = _compraBll.CalcularPrecio(_vehiculo, formaAdquisicion, int.Parse(txtPrecioVenta.Text));
                    txtPrecioCompra.Text = precioCompraSugerido.ToString();
                    MessageBox.Show("Se realizo el calculo de precios", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    this.precioCompraSugerido = _compraBll.CalcularPrecio(_vehiculo, formaAdquisicion);
                    txtPrecioCompra.Text = precioCompraSugerido.ToString();
                    txtPrecioVenta.Text = _vehiculo.Precio;
                    MessageBox.Show("Se realizo el calculo de precios", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdquirir_Click(object sender, EventArgs e)
        {
            _vehiculo.Adquirido = true;
            _vehiculo.Disponible = true;
            _vehiculo.Precio = BLL.Cifrado.Encriptar(_vehiculo.Precio, true);
            _vehiculo.Dvh = BLL.DigitoVerificador.CalcularDV(_vehiculo, "vehiculoStock");

            _vehiculoStockBll.ActualizarVehiculo(_vehiculo);
            BE.Compra compra= new BE.Compra();
            compra.Cliente = cliente;

            var usuario = Services.SessionManager.GetInstance.Usuario;
            BLL.Empleado _empleadoBll = new BLL.Empleado();
            compra.Empleado = _empleadoBll.GetEmpleadoUsuario(usuario);

            var formaAdquisicion = cmbFormaAdquisicion.SelectedIndex;
            if (formaAdquisicion != 0)
            {
                compra.EsConsignacion = BLL.Cifrado.Encriptar(true.ToString(),true);
            }
            else
            {
                compra.EsConsignacion = BLL.Cifrado.Encriptar(false.ToString(), true);
            }
            compra.VehiculoStock = _vehiculo;
            compra.Fecha = DateTime.Now;
            compra.PrecioSugerido = BLL.Cifrado.Encriptar(precioCompraSugerido.ToString(), true);
            compra.Dvh = BLL.DigitoVerificador.CalcularDV(compra,"compra");
            _compraBll.GuardarCompra(compra);
            MessageBox.Show("Se realizo la compra del vehiculo con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _bitacoraBll.RegistrarBitacora(usuario, $"Se realizo la compra del vehiculo de patente = {BLL.Cifrado.Desencriptar(_vehiculo.Patente)}" +
                $" a un precio de ${BLL.Cifrado.Desencriptar(compra.PrecioSugerido)}",3);

            this.Close();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            _vehiculo.Adquirido = false;
            _vehiculo.Dvh = BLL.DigitoVerificador.CalcularDV(_vehiculo, "vehiculoStock");
            _vehiculoStockBll.ActualizarVehiculo(_vehiculo);

            var usuario = Services.SessionManager.GetInstance.Usuario;
            _bitacoraBll.RegistrarBitacora(usuario, $"Se rechaza la compra del vehiculo de patente = {BLL.Cifrado.Desencriptar(_vehiculo.Patente)}", 2);
            this.Close();
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
                try
                {
                    _vehiculo = _vehiculoStockBll.BuscarVehiculoOfrecido(cliente);
                    txtPatente.Text = BLL.Cifrado.Desencriptar(_vehiculo.Patente);
                    txtTipoVehiculo.Text = _vehiculo.TipoVehiculo.ToString();
                    txtMarca.Text = _vehiculo.Marca;
                    txtModelo.Text = _vehiculo.Modelo;
                    txtVersion.Text = _vehiculo.Version;
                    txtKilometraje.Text = _vehiculo.Kilometraje.ToString();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void cmbFormaAdquisicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = cmbFormaAdquisicion.SelectedIndex;

            if(selectedValue == 1)
            {
                txtPrecioVenta.Enabled = true;
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

            if (lblAdquirirVehiculo.Name != null && traducciones.ContainsKey(lblAdquirirVehiculo.Name.ToString()))
                this.lblAdquirirVehiculo.Text = traducciones[lblAdquirirVehiculo.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (lblApellido.Name != null && traducciones.ContainsKey(lblApellido.Name.ToString()))
                this.lblApellido.Text = traducciones[lblApellido.Name.ToString()].Texto;

            if (grpClienteElegido.Name != null && traducciones.ContainsKey(grpClienteElegido.Name.ToString()))
                this.grpClienteElegido.Text = traducciones[grpClienteElegido.Name.ToString()].Texto;

            if (grpDatosDelVehiculo.Name != null && traducciones.ContainsKey(grpDatosDelVehiculo.Name.ToString()))
                this.grpDatosDelVehiculo.Text = traducciones[grpDatosDelVehiculo.Name.ToString()].Texto;

            if (btnRechazar.Name != null && traducciones.ContainsKey(btnRechazar.Name.ToString()))
                this.btnRechazar.Text = traducciones[btnRechazar.Name.ToString()].Texto;

            if (btnAdquirir.Name != null && traducciones.ContainsKey(btnAdquirir.Name.ToString()))
                this.btnAdquirir.Text = traducciones[btnAdquirir.Name.ToString()].Texto;

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

            if (lblPrecioCompra.Name != null && traducciones.ContainsKey(lblPrecioCompra.Name.ToString()))
                this.lblPrecioCompra.Text = traducciones[lblPrecioCompra.Name.ToString()].Texto;

            if (lblPrecioVenta.Name != null && traducciones.ContainsKey(lblPrecioVenta.Name.ToString()))
                this.lblPrecioVenta.Text = traducciones[lblPrecioVenta.Name.ToString()].Texto;

            if (lblFormaAdquisicion.Name != null && traducciones.ContainsKey(lblFormaAdquisicion.Name.ToString()))
                this.lblFormaAdquisicion.Text = traducciones[lblFormaAdquisicion.Name.ToString()].Texto;

            if (btnCalcularPrecios.Name != null && traducciones.ContainsKey(btnCalcularPrecios.Name.ToString()))
                this.btnCalcularPrecios.Text = traducciones[btnCalcularPrecios.Name.ToString()].Texto;
        }

        private void AdquirirVehiculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void lblAdquirirVehiculo_Click(object sender, EventArgs e)
        {

        }
    }
}
