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
    public partial class ModificarFamilia : Form, Services.IIdiomaObserver
    {
        List<BE.Permiso> _listaAsignados;
        BLL.Permiso _permisoBll;
        BE.Familia familia;

        public ModificarFamilia(BE.Familia f)
        {
            familia = f;
            _permisoBll = new BLL.Permiso();
            _listaAsignados = f.Hijos.ToList();
            InitializeComponent();
        }

        private void ModificarFamilia_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            txtNombre.Text = familia.nombre;
            var lista = _permisoBll.GetAllPatentes();
            lboxPatNoAsig.DataSource = lista;
            lboxPatAsig.DataSource = familia.Hijos;

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            BE.Patente patente = lboxPatNoAsig.SelectedItem as BE.Patente;
            int repetido = 0;

            foreach (BE.Patente pat in _listaAsignados)
            {
                if (pat.id.Equals(patente.id))
                {
                    repetido = 1;
                }
            }
            if (repetido == 0)
            {
                _listaAsignados.Add(patente);
            }

            ActualizarlistAsignados(_listaAsignados);
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            BE.Patente patente = lboxPatAsig.SelectedItem as BE.Patente;
            bool enUso = _permisoBll.PatenteEnUso(patente, familia);
            if (enUso)
            {
                _listaAsignados.Remove(patente);
                ActualizarlistAsignados(_listaAsignados);
            }
            else
            {
                MessageBox.Show("No se puede remover el permiso, ya que no esta siendo utilizado por ninguna familia de permisos o usuario");
            }
        }

        private void ActualizarlistAsignados(List<BE.Permiso> lista)
        {
            lboxPatAsig.DataSource = null;
            lboxPatAsig.DataSource = lista;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombreFamilia = txtNombre.Text;
            familia.nombre = nombreFamilia;
            familia.VaciarHijos();
            foreach (BE.Patente patente in _listaAsignados)
            {
                familia.AgregarHijo(patente);
            }
            long dvh = BLL.DigitoVerificador.CalcularDV(familia, "Patente");
            familia.dvh = dvh;
            familia.esFamilia = 1;
            _permisoBll.GuardarFamilia(familia);
            MessageBox.Show("Familia modificada con exito");
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

            if (lblModificarFamilia.Name != null && traducciones.ContainsKey(lblModificarFamilia.Name.ToString()))
                this.lblModificarFamilia.Text = traducciones[lblModificarFamilia.Name.ToString()].Texto;


            if (lblNombre.Name != null && traducciones.ContainsKey(lblNombre.Name.ToString()))
                this.lblNombre.Text = traducciones[lblNombre.Name.ToString()].Texto;


            if (grpDatosDeFamilia.Name != null && traducciones.ContainsKey(grpDatosDeFamilia.Name.ToString()))
                this.grpDatosDeFamilia.Text = traducciones[grpDatosDeFamilia.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (grpAsignarPatentes.Name != null && traducciones.ContainsKey(grpAsignarPatentes.Name.ToString()))
                this.grpAsignarPatentes.Text = traducciones[grpAsignarPatentes.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (btnAsignar.Name != null && traducciones.ContainsKey(btnAsignar.Name.ToString()))
                this.btnAsignar.Text = traducciones[btnAsignar.Name.ToString()].Texto;

            if (btnDesasignar.Name != null && traducciones.ContainsKey(btnDesasignar.Name.ToString()))
                this.btnDesasignar.Text = traducciones[btnDesasignar.Name.ToString()].Texto;
        }
        private void ModificarFamilia_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
