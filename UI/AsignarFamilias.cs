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
    public partial class AsignarFamilias : Form
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
        }

        private void AsignarFamilias_Load(object sender, EventArgs e)
        {
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
            _listaAsignados.Remove(familia);
            ActualizarlistAsignados(_listaAsignados);
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
    }
}
