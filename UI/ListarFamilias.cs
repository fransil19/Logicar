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
    public partial class ListarFamilias : Form
    {
        BLL.Permiso _permisoBLL;
        public ListarFamilias()
        {
            _permisoBLL = new BLL.Permiso();
            InitializeComponent();
        }

        private void ListarFamilias_Load(object sender, EventArgs e)
        {
            var listaFamilias = _permisoBLL.GetAllFamilias();
            grillaFamilias.DataSource = listaFamilias.Select(r => new
            {
                Id = r.id,
                Nombre = r.nombre,
                DVH = r.dvh,
            }).ToList(); ;
        }

        private void grillaFamilias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = grillaFamilias.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            AltaFamilia formAFamilia = new AltaFamilia();
            formAFamilia.Show();
        }

        private void btnModificarFamilia_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaFamilias.CurrentRow.Cells[0].Value;
            var listaFamilias = _permisoBLL.GetAllFamilias();
            var familia = listaFamilias.Where(i => i.id == indice).FirstOrDefault();
            _permisoBLL.FillFamilyComponents(familia);
            ModificarFamilia formMFamilia = new ModificarFamilia(familia);
            formMFamilia.Show();
        }

        private void btnEliminarFamilia_Click(object sender, EventArgs e)
        {
            int indice = (int)grillaFamilias.CurrentRow.Cells[0].Value;
            var listaFamilias = _permisoBLL.GetAllFamilias();
            BE.Familia familia = listaFamilias.Where(i => i.id == indice).FirstOrDefault();
            _permisoBLL.FillFamilyComponents(familia);
            try
            {
                _permisoBLL.EliminarFamilia(familia);
                MessageBox.Show("Familia eliminada correctamente");
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }
    }
}
