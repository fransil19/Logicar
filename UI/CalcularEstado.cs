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
    public partial class CalcularEstado : Form, Services.IIdiomaObserver
    {
        BLL.Estado _estadoBll;
        public BE.Estado _estado;
        public DialogResult _dialog;

        public CalcularEstado()
        {
            _estadoBll = new BLL.Estado();
            _estado = new BE.Estado();
            InitializeComponent();
            Traducir();
        }

        private void CalcularEstado_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "MUY MALO");
            comboSource.Add(2, "MALO");
            comboSource.Add(3, "REGULAR");
            comboSource.Add(4, "BUENO");
            comboSource.Add(5, "EXCELENTE");
            cmbMotor.DataSource = new BindingSource(comboSource, null);
            cmbMotor.DisplayMember = "Value";
            cmbMotor.ValueMember = "Key";
            cmbMotor.SelectedValue = 1;

            cmbCarroceria.DataSource = new BindingSource(comboSource, null);
            cmbCarroceria.DisplayMember = "Value";
            cmbCarroceria.ValueMember = "Key";
            cmbCarroceria.SelectedValue = 1;

            cmbFrenos.DataSource = new BindingSource(comboSource, null);
            cmbFrenos.DisplayMember = "Value";
            cmbFrenos.ValueMember = "Key";
            cmbFrenos.SelectedValue = 1;

            cmbAmortiguacion.DataSource = new BindingSource(comboSource, null);
            cmbAmortiguacion.DisplayMember = "Value";
            cmbAmortiguacion.ValueMember = "Key";
            cmbAmortiguacion.SelectedValue = 1;

            cmbImpSonoro.DataSource = new BindingSource(comboSource, null);
            cmbImpSonoro.DisplayMember = "Value";
            cmbImpSonoro.ValueMember = "Key";
            cmbImpSonoro.SelectedValue = 1;

            cmbInterior.DataSource = new BindingSource(comboSource, null);
            cmbInterior.DisplayMember = "Value";
            cmbInterior.ValueMember = "Key";
            cmbInterior.SelectedValue = 1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int valorMotor = int.Parse(cmbMotor.SelectedValue.ToString());
            int valorCarroceria = int.Parse(cmbCarroceria.SelectedValue.ToString());
            int valorFrenos = int.Parse(cmbFrenos.SelectedValue.ToString());
            int valorAmortiguacion = int.Parse(cmbAmortiguacion.SelectedValue.ToString());
            int valorImpSonoro = int.Parse(cmbImpSonoro.SelectedValue.ToString());
            int valorInterior = int.Parse(cmbInterior.SelectedValue.ToString());

            try
            {
                _estado = _estadoBll.ComprobarEstado(valorMotor, valorCarroceria, valorFrenos,
                    valorAmortiguacion, valorImpSonoro, valorInterior);
                _dialog = DialogResult.OK;
                MessageBox.Show("El estado del vehiculo es aceptable", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _dialog = DialogResult.Cancel;
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

            if (lblCalcularEstado.Name != null && traducciones.ContainsKey(lblCalcularEstado.Name.ToString()))
                this.lblCalcularEstado.Text = traducciones[lblCalcularEstado.Name.ToString()].Texto;


            if (lblMotor.Name != null && traducciones.ContainsKey(lblMotor.Name.ToString()))
                this.lblMotor.Text = traducciones[lblMotor.Name.ToString()].Texto;


            if (lblCarroceria.Name != null && traducciones.ContainsKey(lblCarroceria.Name.ToString()))
                this.lblCarroceria.Text = traducciones[lblCarroceria.Name.ToString()].Texto;

            if (lblFrenos.Name != null && traducciones.ContainsKey(lblFrenos.Name.ToString()))
                this.lblFrenos.Text = traducciones[lblFrenos.Name.ToString()].Texto;

            if (lblAmortiguacion.Name != null && traducciones.ContainsKey(lblAmortiguacion.Name.ToString()))
                this.lblAmortiguacion.Text = traducciones[lblAmortiguacion.Name.ToString()].Texto;

            if (lblImpactoSonoro.Name != null && traducciones.ContainsKey(lblImpactoSonoro.Name.ToString()))
                this.lblImpactoSonoro.Text = traducciones[lblImpactoSonoro.Name.ToString()].Texto;

            if (lblInterior.Name != null && traducciones.ContainsKey(lblInterior.Name.ToString()))
                this.lblInterior.Text = traducciones[lblInterior.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;
        }

        private void CalcularEstado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
