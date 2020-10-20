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
    public partial class Logicar : Form
    {
        public Logicar()
        {
            InitializeComponent();
        }

        private void mnuAdministrarEmpleados_Click(object sender, EventArgs e)
        {
            ListaEmpleados frmLEmpleados = new ListaEmpleados();
            frmLEmpleados.MdiParent = this;
            frmLEmpleados.Show();
        }

        private void mnuAdministrarFamilias_Click(object sender, EventArgs e)
        {
            ListarFamilias frmLFamilias = new ListarFamilias();
            frmLFamilias.MdiParent = this;
            frmLFamilias.Show();
        }
    }
}
