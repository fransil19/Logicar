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
    public partial class AsignarFamilias : Form, Services.IIdiomaObserver
    {
        BE.Empleado _empleado;
        BLL.Permiso _permisoBll;
        BLL.Usuario _usuarioBll;
        List<BE.Permiso> _listaAsignados;

        public AsignarFamilias(BE.Empleado empleado)
        {
            _empleado = empleado;
            _permisoBll = new BLL.Permiso();
            _usuarioBll = new BLL.Usuario();
            _listaAsignados = _empleado.usuario.Permisos != null ? _empleado.usuario.Permisos.FindAll(r=> r.esFamilia == 1) : new List<BE.Permiso>();
            InitializeComponent();
            Traducir();
        }

        private void AsignarFamilias_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            txtUsuario.Text = BLL.Cifrado.Desencriptar(_empleado.usuario.usuario);
            var lista = _permisoBll.GetAllFamilias();

            lboxFamDisponibles.DataSource = null;
            lboxFamDisponibles.DataSource = lista;

            ActualizarlistAsignados(_listaAsignados);
        }

        private void ActualizarlistAsignados(List<BE.Permiso> lista)
        {
            lboxFamAsignadas.DataSource = null;
            lboxFamAsignadas.DataSource = lista;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            BE.Familia familia = lboxFamDisponibles.SelectedItem as BE.Familia;
            int repetido = 0;

            foreach (BE.Familia fam in _listaAsignados)
            {
                if (fam.id.Equals(familia.id))
                {
                    repetido = 1;
                }
            }
            if (repetido == 0)
            {
                _listaAsignados.Add(familia);
            }

            ActualizarlistAsignados(_listaAsignados);
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            BE.Familia familia = lboxFamAsignadas.SelectedItem as BE.Familia;
            _permisoBll.FillFamilyComponents(familia);
            bool enUso = _permisoBll.FamiliaEnUso(familia);
            if (enUso)
            {
                _listaAsignados.Remove(familia);
                ActualizarlistAsignados(_listaAsignados);
            }
            else
            {
                MessageBox.Show("No se puede desasignar la familia ya que hay permisos que no estarian asignados");
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _empleado.usuario.Permisos.RemoveAll(r => r.esFamilia == 1);
            foreach (BE.Familia fam in _listaAsignados)
            {
                _empleado.usuario.Permisos.Add(fam);
            }
            _usuarioBll.GuardarPermisos(_empleado.usuario);

            var opcion = MessageBox.Show("Familias asignadas al usuario con exito");
            if (opcion == DialogResult.OK)
            {
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

            if (lblAFamUsuario.Name != null && traducciones.ContainsKey(lblAFamUsuario.Name.ToString()))
                this.lblAFamUsuario.Text = traducciones[lblAFamUsuario.Name.ToString()].Texto;


            if (lblUsuario.Name != null && traducciones.ContainsKey(lblUsuario.Name.ToString()))
                this.lblUsuario.Text = traducciones[lblUsuario.Name.ToString()].Texto;

            if (grpDatosUsuario.Name != null && traducciones.ContainsKey(grpDatosUsuario.Name.ToString()))
                this.grpDatosUsuario.Text = traducciones[grpDatosUsuario.Name.ToString()].Texto;

            if (btnAceptar.Name != null && traducciones.ContainsKey(btnAceptar.Name.ToString()))
                this.btnAceptar.Text = traducciones[btnAceptar.Name.ToString()].Texto;

            if (grpAsignarFamilias.Name != null && traducciones.ContainsKey(grpAsignarFamilias.Name.ToString()))
                this.grpAsignarFamilias.Text = traducciones[grpAsignarFamilias.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;

            if (btnAsignar.Name != null && traducciones.ContainsKey(btnAsignar.Name.ToString()))
                this.btnAsignar.Text = traducciones[btnAsignar.Name.ToString()].Texto;

            if (btnDesasignar.Name != null && traducciones.ContainsKey(btnDesasignar.Name.ToString()))
                this.btnDesasignar.Text = traducciones[btnDesasignar.Name.ToString()].Texto;

            if (lblFamiliasAsignadas.Name != null && traducciones.ContainsKey(lblFamiliasAsignadas.Name.ToString()))
                this.lblFamiliasAsignadas.Text = traducciones[lblFamiliasAsignadas.Name.ToString()].Texto;

            if (lblFamiliasDisponibles.Name != null && traducciones.ContainsKey(lblFamiliasDisponibles.Name.ToString()))
                this.lblFamiliasDisponibles.Text = traducciones[lblFamiliasDisponibles.Name.ToString()].Texto;
        }

        private void AsignarFamilias_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
