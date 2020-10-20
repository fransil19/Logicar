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
    public partial class Backup : Form
    {
        BLL.Backup _backupBll = new BLL.Backup();
        BLL.Usuario _usuarioBll = new BLL.Usuario();

        public Backup()
        {
            InitializeComponent();
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
    }
}
