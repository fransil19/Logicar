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
    public partial class Backup : Form, Services.IIdiomaObserver
    {
        BLL.Backup _backupBll = new BLL.Backup();
        BLL.Usuario _usuarioBll = new BLL.Usuario();

        public Backup()
        {
            InitializeComponent();
            Traducir();
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog elegirCarpetaBackup = new FolderBrowserDialog();
            if (elegirCarpetaBackup.ShowDialog() == DialogResult.OK)
            {
                txtDestino.Text = elegirCarpetaBackup.SelectedPath;
            }
        }

        private void btnGuardarBackup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDestino.Text))
            {
              
                string NombreBackup = (DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" +
                    DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + "-" +
                     DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString());
                string Ruta = txtDestino.Text + "\\";
                string mensaje = _backupBll.RealizarBackup(NombreBackup, Ruta);
                var opcion = MessageBox.Show(mensaje, "" , MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (opcion == DialogResult.OK)
                {
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

            if (lblBackup.Name != null && traducciones.ContainsKey(lblBackup.Name.ToString()))
                this.lblBackup.Text = traducciones[lblBackup.Name.ToString()].Texto;


            if (grpBackup.Name != null && traducciones.ContainsKey(grpBackup.Name.ToString()))
                this.grpBackup.Text = traducciones[grpBackup.Name.ToString()].Texto;


            if (lblDestino.Name != null && traducciones.ContainsKey(lblDestino.Name.ToString()))
                this.lblDestino.Text = traducciones[lblDestino.Name.ToString()].Texto;

            if (btnGuardarBackup.Name != null && traducciones.ContainsKey(btnGuardarBackup.Name.ToString()))
                this.btnGuardarBackup.Text = traducciones[btnGuardarBackup.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;
        }

        private void Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
        }
    }
}
