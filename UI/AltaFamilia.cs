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
    public partial class AltaFamilia : Form
    {
        List<BE.Permiso> _listaAsignados;
        BLL.Permiso _permisoBll;

        public AltaFamilia()
        {
            _permisoBll = new BLL.Permiso();
            _listaAsignados = new List<BE.Permiso>();
            InitializeComponent();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {

            BE.Patente patente = lboxPatNoAsig.SelectedItem as BE.Patente;
            int repetido = 0;
            foreach(BE.Patente pat in _listaAsignados)
            {
                if (pat.Equals(patente))
                {
                    repetido = 1;
                }
            }
            if(repetido == 0)
            {
                _listaAsignados.Add(patente);
            }

            ActualizarlistAsignados(_listaAsignados);

        }

        private void ActualizarlistAsignados(List<BE.Permiso> lista)
        {
            lboxPatAsig.DataSource = null;
            lboxPatAsig.DataSource = lista;
        }

        private void AltaFamilia_Load(object sender, EventArgs e)
        {
            var lista = _permisoBll.GetAllPatentes();
            lboxPatNoAsig.DataSource = lista;
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            BE.Patente patente = lboxPatAsig.SelectedItem as BE.Patente;
            _listaAsignados.Remove(patente);
            ActualizarlistAsignados(_listaAsignados);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombreFamilia = txtNombre.Text;
            BE.Familia familia = new BE.Familia();
            familia.nombre = nombreFamilia;
            foreach(BE.Patente patente in _listaAsignados)
            {
                familia.AgregarHijo(patente);
            }
            long dvh = BLL.DigitoVerificador.CalcularDV(familia, "Patente");
            familia.dvh = dvh;
            familia.esFamilia = 1;
            _permisoBll.GuardarPermiso(familia);
            _permisoBll.GuardarFamilia(familia);
            var opcion = MessageBox.Show("Familia creada con exito");
            if (opcion == DialogResult.OK)
            {
                CerrarVentana();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var opcion = MessageBox.Show("Seguro desea cancelar la operación?","Cancelar operacion",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            if(opcion == DialogResult.OK)
            {
                CerrarVentana();
            }
        }

        private void CerrarVentana()
        {
            this.Close();
        }
    }
}
