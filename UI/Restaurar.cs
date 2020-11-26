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
    public partial class Restaurar : Form, Services.IIdiomaObserver
    {
        BLL.Backup _backupBll;
        BE.Usuario usuario;
        public Restaurar(BE.Usuario user = null)
        {
            usuario = user;
            _backupBll = new BLL.Backup();
            InitializeComponent();
            Traducir();
        }

        private void btnOrigen_Click(object sender, EventArgs e)
        {
            OpenFileDialog elegirCarpetaRestore = new OpenFileDialog();
            if (elegirCarpetaRestore.ShowDialog() == DialogResult.OK)
            {
                txtDestino.Text = elegirCarpetaRestore.FileName;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                BLL.Bitacora _bitacoraBll = new BLL.Bitacora();
                if (Services.SessionManager.IsLogged())
                {
                    usuario = Services.SessionManager.GetInstance.Usuario;
                }
                
                string Ruta = txtDestino.Text;
                string mensaje = _backupBll.RealizarRestore(Ruta);
                var opcion = MessageBox.Show(mensaje, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (opcion == DialogResult.OK)
                {
                    _bitacoraBll.RegistrarBitacora(usuario, $@"Se realizo la restauracion del sistema desde un backup.", 1);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No seleccionó ninguna ruta para guardar el Backup.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (lblRestaurarBase.Name != null && traducciones.ContainsKey(lblRestaurarBase.Name.ToString()))
                this.lblRestaurarBase.Text = traducciones[lblRestaurarBase.Name.ToString()].Texto;


            if (grpRestaurar.Name != null && traducciones.ContainsKey(grpRestaurar.Name.ToString()))
                this.grpRestaurar.Text = traducciones[grpRestaurar.Name.ToString()].Texto;


            if (lblOrigen.Name != null && traducciones.ContainsKey(lblOrigen.Name.ToString()))
                this.lblOrigen.Text = traducciones[lblOrigen.Name.ToString()].Texto;

            if (btnRestaurar.Name != null && traducciones.ContainsKey(btnRestaurar.Name.ToString()))
                this.btnRestaurar.Text = traducciones[btnRestaurar.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;
        }

        private void Restaurar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void Restaurar_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
        }
    }
}
