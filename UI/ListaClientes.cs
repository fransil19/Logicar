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
    public partial class ListaClientes : Form, Services.IIdiomaObserver
    {
        BLL.Cliente _clienteBll;
        public ListaClientes()
        {
            _clienteBll = new BLL.Cliente();
            InitializeComponent();
            Traducir();
        }

        private void ActualizarGrilla()
        {
            grillaCliente.DataSource = null;
            List<BE.Cliente> lista = _clienteBll.ListarClientes();
            grillaCliente.DataSource = lista.Select(r => new
            {
                ID = r.Id,
                Nombre = r.Nombre,
                Apellido = r.Apellido,
                TipoDocumento = r.TipoDoc == 1 ? "DNI" : r.TipoDoc == 2 ? "CUIL" : r.TipoDoc == 3 ? "CUIT" : r.TipoDoc == 4 ? "LIBRETA CIVICA" : "DESCONOCIDO",
                NroDocumento = r.NroDoc,
                Domicilio = r.Domicilio,
                Telefono = r.Telefono,
                Email = r.Email,
                Estado = r.Estado == true ? "ACTIVO" : "INACTIVO",
            }).ToList();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AltaCliente formACliente = new AltaCliente();
            formACliente.MdiParent = this.ParentForm;
            formACliente.Show();
            formACliente.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            ActualizarGrilla();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaCliente.CurrentRow.Cells[0].Value;
            var listaFamilias = _clienteBll.ListarClientes();
            BE.Cliente _cliente = listaFamilias.Where(i => i.Id == indice).FirstOrDefault();
            this.Hide();
            ModificarCliente formMCliente = new ModificarCliente(_cliente);
            formMCliente.MdiParent = this.ParentForm;
            formMCliente.Show();
            formMCliente.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Seguro desea cancelar la operación?", "Cancelar operacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (opcion == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaCliente.CurrentRow.Cells[0].Value;
            var listaFamilias = _clienteBll.ListarClientes();
            BE.Cliente _cliente = listaFamilias.Where(i => i.Id == indice).FirstOrDefault();
            try
            {
                _clienteBll.EliminarCliente(_cliente);
                MessageBox.Show("Cliente eliminado correctamente");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            ActualizarGrilla();
        }

        private void grillaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClienteSel.Text = grillaCliente.Rows[e.RowIndex].Cells[1].Value.ToString()+ " "+ grillaCliente.Rows[e.RowIndex].Cells[2].Value.ToString();
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

            if (lblListaClientes.Name != null && traducciones.ContainsKey(lblListaClientes.Name.ToString()))
                this.lblListaClientes.Text = traducciones[lblListaClientes.Name.ToString()].Texto;


            if (lblCliente.Name != null && traducciones.ContainsKey(lblCliente.Name.ToString()))
                this.lblCliente.Text = traducciones[lblCliente.Name.ToString()].Texto;


            if (grpClienteElegido.Name != null && traducciones.ContainsKey(grpClienteElegido.Name.ToString()))
                this.grpClienteElegido.Text = traducciones[grpClienteElegido.Name.ToString()].Texto;

            if (btnAgregar.Name != null && traducciones.ContainsKey(btnAgregar.Name.ToString()))
                this.btnAgregar.Text = traducciones[btnAgregar.Name.ToString()].Texto;

            if (btnModificar.Name != null && traducciones.ContainsKey(btnModificar.Name.ToString()))
                this.btnModificar.Text = traducciones[btnModificar.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (btnEliminar.Name != null && traducciones.ContainsKey(btnEliminar.Name.ToString()))
                this.btnEliminar.Text = traducciones[btnEliminar.Name.ToString()].Texto;
        }

        private void ListaClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AltaCliente formACliente = new AltaCliente();
            formACliente.MdiParent = this.ParentForm;
            formACliente.Show();
            formACliente.FormClosed += new FormClosedEventHandler(Form_Closed);
        }
    }
}
