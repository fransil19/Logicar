namespace UI
{
    partial class Logicar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIdiomas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCambiarPass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministrarEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministrarFamilias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRestaurar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdquirirVehiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAltaDeVehiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVenderVehiculo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReporteDeVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministrarClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSesion,
            this.mnuAdministrarEmpleados,
            this.mnuAdministrarFamilias,
            this.mnuRespaldo,
            this.mnuBitacora,
            this.mnuCompras,
            this.mnuVentas,
            this.mnuReportes,
            this.mnuAdministrarClientes});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(834, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuSesion
            // 
            this.mnuSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLogin,
            this.tsmiLogout,
            this.tsmiIdiomas,
            this.tsmiCambiarPass});
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Size = new System.Drawing.Size(53, 20);
            this.mnuSesion.Text = "Sesion";
            // 
            // tsmiLogin
            // 
            this.tsmiLogin.Name = "tsmiLogin";
            this.tsmiLogin.Size = new System.Drawing.Size(182, 22);
            this.tsmiLogin.Text = "Iniciar Sesion";
            this.tsmiLogin.Click += new System.EventHandler(this.tsmiLogin_Click);
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(182, 22);
            this.tsmiLogout.Text = "Cerrar Sesion";
            this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // tsmiIdiomas
            // 
            this.tsmiIdiomas.Name = "tsmiIdiomas";
            this.tsmiIdiomas.Size = new System.Drawing.Size(182, 22);
            this.tsmiIdiomas.Text = "Idiomas";
            // 
            // tsmiCambiarPass
            // 
            this.tsmiCambiarPass.Name = "tsmiCambiarPass";
            this.tsmiCambiarPass.Size = new System.Drawing.Size(182, 22);
            this.tsmiCambiarPass.Tag = "CambiarPass";
            this.tsmiCambiarPass.Text = "Cambiar Contraseña";
            this.tsmiCambiarPass.Click += new System.EventHandler(this.tsmiCambiarPass_Click);
            // 
            // mnuAdministrarEmpleados
            // 
            this.mnuAdministrarEmpleados.Name = "mnuAdministrarEmpleados";
            this.mnuAdministrarEmpleados.Size = new System.Drawing.Size(142, 20);
            this.mnuAdministrarEmpleados.Tag = "AdministrarEmpleados";
            this.mnuAdministrarEmpleados.Text = "Administrar Empleados";
            this.mnuAdministrarEmpleados.Click += new System.EventHandler(this.mnuAdministrarEmpleados_Click);
            // 
            // mnuAdministrarFamilias
            // 
            this.mnuAdministrarFamilias.Name = "mnuAdministrarFamilias";
            this.mnuAdministrarFamilias.Size = new System.Drawing.Size(127, 20);
            this.mnuAdministrarFamilias.Tag = "AdministrarFamilias";
            this.mnuAdministrarFamilias.Text = "Administrar Familias";
            this.mnuAdministrarFamilias.Click += new System.EventHandler(this.mnuAdministrarFamilias_Click);
            // 
            // mnuRespaldo
            // 
            this.mnuRespaldo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBackup,
            this.tsmiRestaurar});
            this.mnuRespaldo.Name = "mnuRespaldo";
            this.mnuRespaldo.Size = new System.Drawing.Size(67, 20);
            this.mnuRespaldo.Text = "Respaldo";
            // 
            // tsmiBackup
            // 
            this.tsmiBackup.Name = "tsmiBackup";
            this.tsmiBackup.Size = new System.Drawing.Size(123, 22);
            this.tsmiBackup.Tag = "Backup";
            this.tsmiBackup.Text = "Backup";
            this.tsmiBackup.Click += new System.EventHandler(this.tsmiBackup_Click);
            // 
            // tsmiRestaurar
            // 
            this.tsmiRestaurar.Name = "tsmiRestaurar";
            this.tsmiRestaurar.Size = new System.Drawing.Size(123, 22);
            this.tsmiRestaurar.Tag = "Restaurar";
            this.tsmiRestaurar.Text = "Restaurar";
            this.tsmiRestaurar.Click += new System.EventHandler(this.tsmiRestaurar_Click);
            // 
            // mnuBitacora
            // 
            this.mnuBitacora.Name = "mnuBitacora";
            this.mnuBitacora.Size = new System.Drawing.Size(62, 20);
            this.mnuBitacora.Tag = "Bitacora";
            this.mnuBitacora.Text = "Bitacora";
            this.mnuBitacora.Click += new System.EventHandler(this.mnuBitacora_Click);
            // 
            // mnuCompras
            // 
            this.mnuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdquirirVehiculo,
            this.tsmiAltaDeVehiculo});
            this.mnuCompras.Name = "mnuCompras";
            this.mnuCompras.Size = new System.Drawing.Size(67, 20);
            this.mnuCompras.Text = "Compras";
            // 
            // tsmiAdquirirVehiculo
            // 
            this.tsmiAdquirirVehiculo.Name = "tsmiAdquirirVehiculo";
            this.tsmiAdquirirVehiculo.Size = new System.Drawing.Size(180, 22);
            this.tsmiAdquirirVehiculo.Tag = "AdquirirVehiculo";
            this.tsmiAdquirirVehiculo.Text = "Adquirir Vehiculo";
            this.tsmiAdquirirVehiculo.Click += new System.EventHandler(this.tsmiAdquirirVehiculo_Click);
            // 
            // tsmiAltaDeVehiculo
            // 
            this.tsmiAltaDeVehiculo.Name = "tsmiAltaDeVehiculo";
            this.tsmiAltaDeVehiculo.Size = new System.Drawing.Size(180, 22);
            this.tsmiAltaDeVehiculo.Tag = "AltaVehiculo";
            this.tsmiAltaDeVehiculo.Text = "Alta de Vehiculo";
            this.tsmiAltaDeVehiculo.Click += new System.EventHandler(this.tsmiAltaDeVehiculo_Click);
            // 
            // mnuVentas
            // 
            this.mnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVenderVehiculo});
            this.mnuVentas.Name = "mnuVentas";
            this.mnuVentas.Size = new System.Drawing.Size(53, 20);
            this.mnuVentas.Text = "Ventas";
            // 
            // tsmiVenderVehiculo
            // 
            this.tsmiVenderVehiculo.Name = "tsmiVenderVehiculo";
            this.tsmiVenderVehiculo.Size = new System.Drawing.Size(180, 22);
            this.tsmiVenderVehiculo.Tag = "VenderVehiculo";
            this.tsmiVenderVehiculo.Text = "Vender Vehiculo";
            this.tsmiVenderVehiculo.Click += new System.EventHandler(this.tsmiVenderVehiculo_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReporteDeVentas});
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(65, 20);
            this.mnuReportes.Text = "Reportes";
            // 
            // tsmiReporteDeVentas
            // 
            this.tsmiReporteDeVentas.Name = "tsmiReporteDeVentas";
            this.tsmiReporteDeVentas.Size = new System.Drawing.Size(180, 22);
            this.tsmiReporteDeVentas.Tag = "ReporteVentas";
            this.tsmiReporteDeVentas.Text = "Reporte de Ventas";
            this.tsmiReporteDeVentas.Click += new System.EventHandler(this.tsmiReporteDeVentas_Click);
            // 
            // mnuAdministrarClientes
            // 
            this.mnuAdministrarClientes.Name = "mnuAdministrarClientes";
            this.mnuAdministrarClientes.Size = new System.Drawing.Size(126, 20);
            this.mnuAdministrarClientes.Tag = "AdministarClientes";
            this.mnuAdministrarClientes.Text = "Administrar Clientes";
            this.mnuAdministrarClientes.Click += new System.EventHandler(this.mnuAdministrarClientes_Click);
            // 
            // Logicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Logicar";
            this.Text = "Logicar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logicar_FormClosing);
            this.Load += new System.EventHandler(this.Logicar_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministrarEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministrarFamilias;
        private System.Windows.Forms.ToolStripMenuItem mnuSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogin;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.ToolStripMenuItem tsmiIdiomas;
        private System.Windows.Forms.ToolStripMenuItem mnuRespaldo;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestaurar;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarPass;
        private System.Windows.Forms.ToolStripMenuItem mnuBitacora;
        private System.Windows.Forms.ToolStripMenuItem mnuCompras;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdquirirVehiculo;
        private System.Windows.Forms.ToolStripMenuItem tsmiAltaDeVehiculo;
        private System.Windows.Forms.ToolStripMenuItem mnuVentas;
        private System.Windows.Forms.ToolStripMenuItem tsmiVenderVehiculo;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem tsmiReporteDeVentas;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministrarClientes;
    }
}



