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
    public partial class AsignarPatentes : Form, Services.IIdiomaObserver
    {
        BE.Empleado _empleado;
        BLL.Permiso _permisoBll;
        BLL.Usuario _usuarioBll;
        List<BE.Permiso> _listaAsignados;

        public AsignarPatentes(BE.Empleado empleado)
        {
            _empleado = empleado;
            _permisoBll = new BLL.Permiso();
            _usuarioBll = new BLL.Usuario();
            _listaAsignados = _empleado.usuario.Permisos != null ? _empleado.usuario.Permisos.FindAll(r => r.esFamilia == 0) : new List<BE.Permiso>();
            InitializeComponent();
            Traducir();
        }

        private void AsignarPatentes_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            txtUsuario.Text = BLL.Cifrado.Desencriptar(_empleado.usuario.usuario);
            var lista = _permisoBll.GetAllPatentes();

            lboxPatDisponibles.DataSource = null;
            lboxPatDisponibles.DataSource = lista;

            lboxPatAsignadas.DataSource = null;
            lboxPatAsignadas.DataSource = _listaAsignados;

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            BE.Patente patente = lboxPatDisponibles.SelectedItem as BE.Patente;
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

        private void ActualizarlistAsignados(List<BE.Permiso> lista)
        {
            lboxPatAsignadas.DataSource = null;
            lboxPatAsignadas.DataSource = lista;
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            BE.Patente patente = lboxPatAsignadas.SelectedItem as BE.Patente;
            bool enUso = _permisoBll.PatenteEnUso(patente, _empleado);

            if (enUso) 
            {
                _listaAsignados.Remove(patente);
                ActualizarlistAsignados(_listaAsignados);
            }
            else
            {
                MessageBox.Show("No se puede desasignar el permiso, quedaria sin uso y eso no es posible");
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _empleado.usuario.Permisos.RemoveAll(r => r.esFamilia == 0);

            foreach(BE.Patente pat in _listaAsignados)
            {
                _empleado.usuario.Permisos.Add(pat);
            }
            _usuarioBll.GuardarPermisos(_empleado.usuario);

            var opcion = MessageBox.Show("Patentes asignadas al usuario con exito");
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

            if (lblAPatUsuario.Name != null && traducciones.ContainsKey(lblAPatUsuario.Name.ToString()))
                this.lblAPatUsuario.Text = traducciones[lblAPatUsuario.Name.ToString()].Texto;


            if (lblUsuario.Name != null && traducciones.ContainsKey(lblUsuario.Name.ToString()))
                this.lblUsuario.Text = traducciones[lblUsuario.Name.ToString()].Texto;

            if (grpDatosUsuario.Name != null && traducciones.ContainsKey(grpDatosUsuario.Name.ToString()))
                this.grpDatosUsuario.Text = traducciones[grpDatosUsuario.Name.ToString()].Texto;

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

            if (lblPatAsignadas.Name != null && traducciones.ContainsKey(lblPatAsignadas.Name.ToString()))
                this.lblPatAsignadas.Text = traducciones[lblPatAsignadas.Name.ToString()].Texto;

            if (lblPatDisponibles.Name != null && traducciones.ContainsKey(lblPatDisponibles.Name.ToString()))
                this.lblPatDisponibles.Text = traducciones[lblPatDisponibles.Name.ToString()].Texto;
        }

        private void AsignarPatentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }
    }
}
