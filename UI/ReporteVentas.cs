using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace UI
{
    public partial class ReporteVentas : Form, Services.IIdiomaObserver
    {
        BLL.Venta _ventaBll;
        List<BE.Usuario> listaUsuarios;
        BLL.Usuario _usuarioBll;
        List<BE.Venta> lista;
        public ReporteVentas()
        {
            _ventaBll = new BLL.Venta();
            _usuarioBll = new BLL.Usuario();
            InitializeComponent();
            Traducir();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {
            Services.SessionManager.SuscribirObservador(this);
            CargarGrilla();
            listaUsuarios = _usuarioBll.GetAll();
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            var listamodificada = listaUsuarios.Select(r => new { Id = r.id, Usuario = BLL.Cifrado.Desencriptar(r.usuario) }).ToList();

            foreach (var item in listamodificada)
            {
                comboSource.Add(item.Id, item.Usuario);
            }
            cmbUsuario.DataSource = new BindingSource(comboSource, null);
            cmbUsuario.DisplayMember = "Value";
            cmbUsuario.ValueMember = "Key";
            cmbUsuario.SelectedItem = null;
            cmbUsuario.SelectedText = "";

            DateTime fechaDesde = lista.Min(r => r.Fecha);
            DateTime fechaHasta = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            dtFechaDesde.Value = fechaDesde;
            dtFechaHasta.Value = fechaHasta;
        }

        private void CargarGrilla(IEnumerable<dynamic> listaReporte = null)
        {
            grillaReporte.DataSource = null;
            if (listaReporte == null)
            {
                lista = _ventaBll.ListarVentas();
                grillaReporte.DataSource = lista.Select(r => new
                {
                    ID = r.Id,
                    Usuario = BLL.Cifrado.Desencriptar(r.Empleado.usuario.usuario),
                    Cliente = $"{r.Cliente.Nombre} {r.Cliente.Apellido}",
                    Vehiculo = BLL.Cifrado.Desencriptar(r.Vehiculo.Patente),
                    Precio = r.Precio,
                    Fecha = r.Fecha
                }).ToList();
            }
            else
            {
                grillaReporte.DataSource = listaReporte;
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedItem != null)
            {
                var usrSeleccionado = (KeyValuePair<int, string>)cmbUsuario.SelectedItem;
                var usuario = listaUsuarios.Find(r => r.id == usrSeleccionado.Key);

                var listaModif = lista.Where(r => r.Empleado.usuario.id == usuario.id && r.Fecha >= dtFechaDesde.Value.AddHours(00).AddMinutes(00).AddSeconds(00)
                && r.Fecha <= dtFechaHasta.Value.AddHours(23).AddMinutes(59).AddSeconds(59)).Select(r => new
                {
                    ID = r.Id,
                    Usuario = BLL.Cifrado.Desencriptar(r.Empleado.usuario.usuario),
                    Cliente = $"{r.Cliente.Nombre} {r.Cliente.Apellido}",
                    Vehiculo = BLL.Cifrado.Desencriptar(r.Vehiculo.Patente),
                    Precio = r.Precio,
                    Fecha = r.Fecha
                }).ToList();
                CargarGrilla(listaModif);
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

            if (lblReporteDeVentas.Name != null && traducciones.ContainsKey(lblReporteDeVentas.Name.ToString()))
                this.lblReporteDeVentas.Text = traducciones[lblReporteDeVentas.Name.ToString()].Texto;

            if (grpReporte.Name != null && traducciones.ContainsKey(grpReporte.Name.ToString()))
                this.grpReporte.Text = traducciones[grpReporte.Name.ToString()].Texto;


            if (lblUsuario.Name != null && traducciones.ContainsKey(lblUsuario.Name.ToString()))
                this.lblUsuario.Text = traducciones[lblUsuario.Name.ToString()].Texto;


            if (lblFechaDesde.Name != null && traducciones.ContainsKey(lblFechaDesde.Name.ToString()))
                this.lblFechaDesde.Text = traducciones[lblFechaDesde.Name.ToString()].Texto;

            if (lblFechaHasta.Name != null && traducciones.ContainsKey(lblFechaHasta.Name.ToString()))
                this.lblFechaHasta.Text = traducciones[lblFechaHasta.Name.ToString()].Texto;

            if (btnRefrescar.Name != null && traducciones.ContainsKey(btnRefrescar.Name.ToString()))
                this.btnRefrescar.Text = traducciones[btnRefrescar.Name.ToString()].Texto;

            if (btnCancelar.Name != null && traducciones.ContainsKey(btnCancelar.Name.ToString()))
                this.btnCancelar.Text = traducciones[btnCancelar.Name.ToString()].Texto;
        }

        private void ReporteVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Services.SessionManager.DesuscribirObservador(this);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string fileName = "ReporteVentas.pdf";
            string titulo = "Reporte de Ventas";
            string paragraph = $"Ventas realizadas desde la fecha {dtFechaDesde.Value} hasta {dtFechaHasta.Value}";
            try
            {
                if (grillaReporte.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (.pdf)|.pdf";
                    sfd.FileName = fileName;
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            File.Delete(sfd.FileName);
                        }
                        if (!fileError)
                        {
                            PdfPTable pdfTable = new PdfPTable(grillaReporte.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in grillaReporte.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in grillaReporte.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);

                                pdfDoc.Open();

                                //Titulo y parrafo.
                                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 26);
                                titleFont.IsUnderlined();

                                iTextSharp.text.Font regularFont = FontFactory.GetFont("Arial", 15);

                                Paragraph title = new Paragraph(titulo, titleFont);
                                title.Alignment = Element.ALIGN_CENTER;
                                pdfDoc.Add(title);

                                pdfDoc.Add(new Chunk("\n"));

                                Paragraph text = new Paragraph(paragraph, regularFont);
                                pdfDoc.Add(text);

                                pdfDoc.Add(new Chunk("\n"));

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Exportacion realizada con exito.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    throw new Exception("No hay registros para exportar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
