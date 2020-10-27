using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class ReestablecerSistema : Form
    {
        BLL.Bitacora _bitacoraBll;
        List<BE.Bitacora> lista;
        BLL.Usuario _usuarioBll;
        List<BE.Usuario> listaUsuarios;
        BE.Usuario usuario;

        public ReestablecerSistema(BE.Usuario user = null)
        {
            _bitacoraBll = new BLL.Bitacora();
            _usuarioBll = new BLL.Usuario();
            if(!Services.SessionManager.IsLogged())
            {
                usuario = user;
            }
            else
            {
                usuario = Services.SessionManager.GetInstance.Usuario;
            }
            InitializeComponent();
        }

        private void ReestablecerSistema_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            listaUsuarios = _usuarioBll.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            var listamodificada = listaUsuarios.Select(r => new { Id = r.id, Usuario = BLL.Cifrado.Desencriptar(r.usuario) }).ToList();
            
            foreach(var item in listamodificada)
            {
                comboSource.Add(item.Id,item.Usuario);
            }
            cmbUsuario.DataSource = new BindingSource(comboSource, null);
            cmbUsuario.DisplayMember = "Value";
            cmbUsuario.ValueMember = "Key";
            cmbUsuario.SelectedItem = null;
            cmbUsuario.SelectedText = "";
            Dictionary<int, string> comboSource2 = new Dictionary<int, string>();
            comboSource2.Add(1, "ALTO");
            comboSource2.Add(2, "MEDIO");
            comboSource2.Add(3, "BAJO");

            cmbCriticidad.DataSource = new BindingSource(comboSource2, null);
            cmbCriticidad.DisplayMember = "Value";
            cmbCriticidad.ValueMember = "Key";
            cmbCriticidad.SelectedItem = null;
            cmbCriticidad.SelectedText = "";

            DateTime fechaDesde = lista.Min(r => r.fecha);
            DateTime fechaHasta = DateTime.Today.Date;

            dtFechaDesde.Value = fechaDesde;
            dtFechaHasta.Value = fechaHasta;
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

        private void CargarGrilla(IEnumerable<dynamic> listaBitacora = null)
        {
            grillaBitacora.DataSource = null;
            if (listaBitacora == null)
            {
                lista = _bitacoraBll.ListarBitacora();
                grillaBitacora.DataSource = lista.Select(r => new
                {
                    ID = r.id,
                    Usuario = BLL.Cifrado.Desencriptar(r.usuario.usuario),
                    Descripcion = BLL.Cifrado.Desencriptar(r.descripcion),
                    Criticidad = r.criticidad == 1 ? "ALTO" : r.criticidad == 2 ? "MEDIO" : "BAJO",
                    Fecha = r.fecha
                }).ToList();
            }
            else
            {
                grillaBitacora.DataSource = listaBitacora;
            }
        }

        private void btnReestablecerDigitos_Click(object sender, EventArgs e)
        {
            var mensaje = BLL.DigitoVerificador.RecalcularDV(usuario);

            var opcion = MessageBox.Show(mensaje, "Reestablecer Integridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(opcion == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if(cmbUsuario.SelectedItem != null)
            {
                var usrSeleccionado = (KeyValuePair<int, string>)cmbUsuario.SelectedItem;
                var usuario = listaUsuarios.Find(r => r.id == usrSeleccionado.Key);
                if (cmbCriticidad.SelectedItem != null)
                {
                    var critSel = (KeyValuePair<int, string>)cmbCriticidad.SelectedItem;
                    var listaModif = lista.Where(r => r.usuario.id == usuario.id && r.criticidad == critSel.Key 
                    && r.fecha >= dtFechaDesde.Value && r.fecha <= dtFechaHasta.Value).Select(r => new
                    {
                        ID = r.id,
                        Usuario = BLL.Cifrado.Desencriptar(r.usuario.usuario),
                        Descripcion = BLL.Cifrado.Desencriptar(r.descripcion),
                        Criticidad = r.criticidad == 1 ? "ALTO" : r.criticidad == 2 ? "MEDIO" : "BAJO",
                        Fecha = r.fecha
                    }).ToList();
                    CargarGrilla(listaModif);
                }
                else
                {
                    var listaModif = lista.Where(r => r.usuario.id == usuario.id && r.fecha >= dtFechaDesde.Value 
                    && r.fecha <= dtFechaHasta.Value).Select(r => new
                    {
                        ID = r.id,
                        Usuario = BLL.Cifrado.Desencriptar(r.usuario.usuario),
                        Descripcion = BLL.Cifrado.Desencriptar(r.descripcion),
                        Criticidad = r.criticidad == 1 ? "ALTO" : r.criticidad == 2 ? "MEDIO" : "BAJO",
                        Fecha = r.fecha
                    }).ToList();
                    CargarGrilla(listaModif);
                }
            }
        }
    }
}
