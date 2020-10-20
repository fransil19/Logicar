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
    public partial class ReestablecerSistema : Form
    {
        BLL.Bitacora _bitacoraBll;

        public ReestablecerSistema()
        {
            _bitacoraBll = new BLL.Bitacora();
            InitializeComponent();
        }

        private void ReestablecerSistema_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnRestaurarBase_Click(object sender, EventArgs e)
        {
            this.Hide();
            Restaurar formRestaurar = new Restaurar();
            formRestaurar.MdiParent = this.ParentForm;
            formRestaurar.Show();
            formRestaurar.FormClosed += new FormClosedEventHandler(Form_Closed);

        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void grillaBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarGrilla()
        {
            grillaBitacora.DataSource = null;
            var lista = _bitacoraBll.ListarBitacora();
            grillaBitacora.DataSource = lista.Select(r => new
            {
                ID = r.id,
                Usuario = BLL.Cifrado.Desencriptar(r.usuario.usuario),
                Descripcion = BLL.Cifrado.Desencriptar(r.descripcion),
                Criticidad = r.criticidad == 1 ? "ALTO" : r.criticidad == 2 ? "MEDIO" : "BAJO",
                Fecha = r.fecha
            }).ToList();
        }

        private void btnReestablecerDigitos_Click(object sender, EventArgs e)
        {
            BLL.DigitoVerificador.RecalcularDV();
        }
    }
}
