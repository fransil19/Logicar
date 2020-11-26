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
    public partial class ListarFamilias : Form, Services.IIdiomaObserver
    {
        BLL.Permiso _permisoBLL;
        Point location;
        public ListarFamilias()
        {
            _permisoBLL = new BLL.Permiso();
            InitializeComponent();
            Traducir();
        }

        private void ListarFamilias_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            CargarFamilias();
        }

        private void CargarFamilias()
        {
            grillaFamilias.DataSource = null;
            var listaFamilias = _permisoBLL.GetAllFamilias();
            grillaFamilias.DataSource = listaFamilias.Select(r => new
            {
                Id = r.id,
                Nombre = r.nombre,
                DVH = r.dvh,
            }).ToList(); ;
        }

        private void grillaFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = grillaFamilias.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            location = this.Location;
            this.Hide();
            AltaFamilia formAFamilia = new AltaFamilia();
            formAFamilia.MdiParent = this.ParentForm;
            formAFamilia.Show();
            formAFamilia.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnModificarFamilia_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaFamilias.CurrentRow.Cells[0].Value;
            var listaFamilias = _permisoBLL.GetAllFamilias();
            var familia = listaFamilias.Where(i => i.id == indice).FirstOrDefault();
            _permisoBLL.FillFamilyComponents(familia);
            this.Hide();
            ModificarFamilia formMFamilia = new ModificarFamilia(familia);
            formMFamilia.MdiParent = this.ParentForm;
            formMFamilia.Show();
            formMFamilia.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaFamilias.CurrentRow.Cells[0].Value;
            var listaFamilias = _permisoBLL.GetAllFamilias();
            BE.Familia familia = listaFamilias.Where(i => i.id == indice).FirstOrDefault();
            _permisoBLL.FillFamilyComponents(familia);
            try
            {
                _permisoBLL.EliminarFamilia(familia);
                MessageBox.Show("Familia eliminada correctamente");
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            CargarFamilias();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CerrarVentana();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Seguro desea cancelar la operación?", "Cancelar operacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (opcion == DialogResult.OK)
            {
                CerrarVentana();
            }
        }

        private void CerrarVentana()
        {
            this.Close();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.Location = location;
            this.Show();
            CargarFamilias();
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

            if (lblListaDeFamilias.Name != null && traducciones.ContainsKey(lblListaDeFamilias.Name.ToString()))
                this.lblListaDeFamilias.Text = traducciones[lblListaDeFamilias.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (grpFamiliaElegida.Name != null && traducciones.ContainsKey(grpFamiliaElegida.Name.ToString()))
                this.grpFamiliaElegida.Text = traducciones[grpFamiliaElegida.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (btnAgregarFamilia.Name != null && traducciones.ContainsKey(btnAgregarFamilia.Name.ToString()))
                this.btnAgregarFamilia.Text = traducciones[btnAgregarFamilia.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (btnEliminarFamilia.Name != null && traducciones.ContainsKey(btnEliminarFamilia.Name.ToString()))
                this.btnEliminarFamilia.Text = traducciones[btnEliminarFamilia.Name.ToString()].Texto;

            if (btnModificarFamilia.Name != null && traducciones.ContainsKey(btnModificarFamilia.Name.ToString()))
                this.btnModificarFamilia.Text = traducciones[btnModificarFamilia.Name.ToString()].Texto;
        }

        private void ListarFamilias_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
