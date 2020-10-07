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
    public partial class AsignarPatentes : Form
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
            _listaAsignados = _empleado.usuario.Permisos != null ? _empleado.usuario.Permisos.ToList() : new List<BE.Permiso>();
            InitializeComponent();
        }

        private void AsignarPatentes_Load(object sender, EventArgs e)
        {
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
            _listaAsignados.Remove(patente);
            ActualizarlistAsignados(_listaAsignados);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _empleado.usuario.Permisos.Clear();
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
    }
}
