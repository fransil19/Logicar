namespace UI
{
    partial class AdquirirVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdquirirVehiculo));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtTipoVehiculo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblKilometraje = new System.Windows.Forms.Label();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnCalcularPrecios = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.cmbFormaAdquisicion = new System.Windows.Forms.ComboBox();
            this.lblFormaAdquisicion = new System.Windows.Forms.Label();
            this.lblTipoDeVehiculo = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblPatente = new System.Windows.Forms.Label();
            this.grpDatosDelVehiculo = new System.Windows.Forms.GroupBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.btnAdquirir = new System.Windows.Forms.Button();
            this.grpClienteElegido = new System.Windows.Forms.GroupBox();
            this.lblAdquirirVehiculo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.grpDatosDelVehiculo.SuspendLayout();
            this.grpClienteElegido.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBuscar.Location = new System.Drawing.Point(291, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 37);
            this.btnBuscar.TabIndex = 98;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtTipoVehiculo
            // 
            this.txtTipoVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTipoVehiculo.Location = new System.Drawing.Point(471, 41);
            this.txtTipoVehiculo.Name = "txtTipoVehiculo";
            this.txtTipoVehiculo.Size = new System.Drawing.Size(208, 20);
            this.txtTipoVehiculo.TabIndex = 93;
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMarca.Location = new System.Drawing.Point(77, 93);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(208, 20);
            this.txtMarca.TabIndex = 83;
            // 
            // lblKilometraje
            // 
            this.lblKilometraje.AutoSize = true;
            this.lblKilometraje.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKilometraje.Location = new System.Drawing.Point(365, 146);
            this.lblKilometraje.Name = "lblKilometraje";
            this.lblKilometraje.Size = new System.Drawing.Size(72, 17);
            this.lblKilometraje.TabIndex = 88;
            this.lblKilometraje.Text = "Kilometraje";
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtKilometraje.Location = new System.Drawing.Point(471, 143);
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(208, 20);
            this.txtKilometraje.TabIndex = 92;
            // 
            // txtPatente
            // 
            this.txtPatente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPatente.Location = new System.Drawing.Point(77, 41);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(208, 20);
            this.txtPatente.TabIndex = 78;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(364, 96);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(49, 17);
            this.lblModelo.TabIndex = 82;
            this.lblModelo.Text = "Modelo";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(20, 141);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(51, 17);
            this.lblVersion.TabIndex = 85;
            this.lblVersion.Text = "Version";
            // 
            // btnRechazar
            // 
            this.btnRechazar.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.Location = new System.Drawing.Point(398, 410);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(371, 30);
            this.btnRechazar.TabIndex = 117;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnCalcularPrecios
            // 
            this.btnCalcularPrecios.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularPrecios.Location = new System.Drawing.Point(6, 9);
            this.btnCalcularPrecios.Name = "btnCalcularPrecios";
            this.btnCalcularPrecios.Size = new System.Drawing.Size(223, 30);
            this.btnCalcularPrecios.TabIndex = 95;
            this.btnCalcularPrecios.Text = "Calcular Precios";
            this.btnCalcularPrecios.UseVisualStyleBackColor = true;
            this.btnCalcularPrecios.Click += new System.EventHandler(this.btnCalcularPrecios_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPrecioVenta);
            this.groupBox3.Controls.Add(this.lblPrecioVenta);
            this.groupBox3.Controls.Add(this.txtPrecioCompra);
            this.groupBox3.Controls.Add(this.lblPrecioCompra);
            this.groupBox3.Controls.Add(this.btnCalcularPrecios);
            this.groupBox3.Location = new System.Drawing.Point(31, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(738, 61);
            this.groupBox3.TabIndex = 113;
            this.groupBox3.TabStop = false;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Enabled = false;
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPrecioVenta.Location = new System.Drawing.Point(471, 36);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(208, 20);
            this.txtPrecioVenta.TabIndex = 102;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.Location = new System.Drawing.Point(360, 37);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(98, 17);
            this.lblPrecioVenta.TabIndex = 101;
            this.lblPrecioVenta.Text = "Precio  de Venta";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Enabled = false;
            this.txtPrecioCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPrecioCompra.Location = new System.Drawing.Point(471, 9);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(208, 20);
            this.txtPrecioCompra.TabIndex = 100;
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCompra.Location = new System.Drawing.Point(360, 10);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(105, 17);
            this.lblPrecioCompra.TabIndex = 99;
            this.lblPrecioCompra.Text = "Precio  de Compra";
            // 
            // cmbFormaAdquisicion
            // 
            this.cmbFormaAdquisicion.FormattingEnabled = true;
            this.cmbFormaAdquisicion.Location = new System.Drawing.Point(169, 303);
            this.cmbFormaAdquisicion.Name = "cmbFormaAdquisicion";
            this.cmbFormaAdquisicion.Size = new System.Drawing.Size(147, 21);
            this.cmbFormaAdquisicion.TabIndex = 116;
            this.cmbFormaAdquisicion.SelectedIndexChanged += new System.EventHandler(this.cmbFormaAdquisicion_SelectedIndexChanged);
            // 
            // lblFormaAdquisicion
            // 
            this.lblFormaAdquisicion.AutoSize = true;
            this.lblFormaAdquisicion.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaAdquisicion.Location = new System.Drawing.Point(37, 304);
            this.lblFormaAdquisicion.Name = "lblFormaAdquisicion";
            this.lblFormaAdquisicion.Size = new System.Drawing.Size(126, 17);
            this.lblFormaAdquisicion.TabIndex = 114;
            this.lblFormaAdquisicion.Text = "Forma de Adquisición";
            // 
            // lblTipoDeVehiculo
            // 
            this.lblTipoDeVehiculo.AutoSize = true;
            this.lblTipoDeVehiculo.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDeVehiculo.Location = new System.Drawing.Point(364, 44);
            this.lblTipoDeVehiculo.Name = "lblTipoDeVehiculo";
            this.lblTipoDeVehiculo.Size = new System.Drawing.Size(101, 17);
            this.lblTipoDeVehiculo.TabIndex = 79;
            this.lblTipoDeVehiculo.Text = "Tipo de Vehiculo";
            // 
            // txtVersion
            // 
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtVersion.Location = new System.Drawing.Point(77, 141);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(208, 20);
            this.txtVersion.TabIndex = 89;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(20, 96);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(42, 17);
            this.lblMarca.TabIndex = 81;
            this.lblMarca.Text = "Marca";
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtModelo.Location = new System.Drawing.Point(471, 93);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(208, 20);
            this.txtModelo.TabIndex = 84;
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatente.Location = new System.Drawing.Point(20, 44);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(51, 17);
            this.lblPatente.TabIndex = 76;
            this.lblPatente.Text = "Patente";
            // 
            // grpDatosDelVehiculo
            // 
            this.grpDatosDelVehiculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpDatosDelVehiculo.Controls.Add(this.btnBuscar);
            this.grpDatosDelVehiculo.Controls.Add(this.txtTipoVehiculo);
            this.grpDatosDelVehiculo.Controls.Add(this.txtMarca);
            this.grpDatosDelVehiculo.Controls.Add(this.lblKilometraje);
            this.grpDatosDelVehiculo.Controls.Add(this.txtKilometraje);
            this.grpDatosDelVehiculo.Controls.Add(this.txtPatente);
            this.grpDatosDelVehiculo.Controls.Add(this.lblModelo);
            this.grpDatosDelVehiculo.Controls.Add(this.lblVersion);
            this.grpDatosDelVehiculo.Controls.Add(this.lblTipoDeVehiculo);
            this.grpDatosDelVehiculo.Controls.Add(this.txtVersion);
            this.grpDatosDelVehiculo.Controls.Add(this.lblMarca);
            this.grpDatosDelVehiculo.Controls.Add(this.txtModelo);
            this.grpDatosDelVehiculo.Controls.Add(this.lblPatente);
            this.grpDatosDelVehiculo.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosDelVehiculo.Location = new System.Drawing.Point(31, 127);
            this.grpDatosDelVehiculo.Name = "grpDatosDelVehiculo";
            this.grpDatosDelVehiculo.Size = new System.Drawing.Size(738, 174);
            this.grpDatosDelVehiculo.TabIndex = 112;
            this.grpDatosDelVehiculo.TabStop = false;
            this.grpDatosDelVehiculo.Text = "Datos del Vehiculo";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.Location = new System.Drawing.Point(594, 22);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(138, 23);
            this.btnBuscarCliente.TabIndex = 99;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtApellido.Location = new System.Drawing.Point(368, 25);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(208, 20);
            this.txtApellido.TabIndex = 78;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.Location = new System.Drawing.Point(77, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(208, 20);
            this.txtNombre.TabIndex = 77;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(20, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 17);
            this.lblNombre.TabIndex = 74;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(307, 28);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(55, 17);
            this.lblApellido.TabIndex = 75;
            this.lblApellido.Text = "Apellido";
            // 
            // btnAdquirir
            // 
            this.btnAdquirir.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdquirir.Location = new System.Drawing.Point(31, 410);
            this.btnAdquirir.Name = "btnAdquirir";
            this.btnAdquirir.Size = new System.Drawing.Size(340, 30);
            this.btnAdquirir.TabIndex = 115;
            this.btnAdquirir.Text = "Adquirir";
            this.btnAdquirir.UseVisualStyleBackColor = true;
            this.btnAdquirir.Click += new System.EventHandler(this.btnAdquirir_Click);
            // 
            // grpClienteElegido
            // 
            this.grpClienteElegido.Controls.Add(this.btnBuscarCliente);
            this.grpClienteElegido.Controls.Add(this.txtApellido);
            this.grpClienteElegido.Controls.Add(this.txtNombre);
            this.grpClienteElegido.Controls.Add(this.lblNombre);
            this.grpClienteElegido.Controls.Add(this.lblApellido);
            this.grpClienteElegido.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClienteElegido.Location = new System.Drawing.Point(31, 73);
            this.grpClienteElegido.Name = "grpClienteElegido";
            this.grpClienteElegido.Size = new System.Drawing.Size(738, 48);
            this.grpClienteElegido.TabIndex = 111;
            this.grpClienteElegido.TabStop = false;
            this.grpClienteElegido.Text = "Cliente Elegido";
            // 
            // lblAdquirirVehiculo
            // 
            this.lblAdquirirVehiculo.AutoSize = true;
            this.lblAdquirirVehiculo.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdquirirVehiculo.Location = new System.Drawing.Point(23, 25);
            this.lblAdquirirVehiculo.Name = "lblAdquirirVehiculo";
            this.lblAdquirirVehiculo.Size = new System.Drawing.Size(255, 45);
            this.lblAdquirirVehiculo.TabIndex = 110;
            this.lblAdquirirVehiculo.Text = "Adquirir Vehículo";
            this.lblAdquirirVehiculo.Click += new System.EventHandler(this.lblAdquirirVehiculo_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(592, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 109;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdquirirVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmbFormaAdquisicion);
            this.Controls.Add(this.lblFormaAdquisicion);
            this.Controls.Add(this.grpDatosDelVehiculo);
            this.Controls.Add(this.btnAdquirir);
            this.Controls.Add(this.grpClienteElegido);
            this.Controls.Add(this.lblAdquirirVehiculo);
            this.Controls.Add(this.label7);
            this.Name = "AdquirirVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AdquirirVehiculo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdquirirVehiculo_FormClosing);
            this.Load += new System.EventHandler(this.AdquirirVehiculo_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpDatosDelVehiculo.ResumeLayout(false);
            this.grpDatosDelVehiculo.PerformLayout();
            this.grpClienteElegido.ResumeLayout(false);
            this.grpClienteElegido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtTipoVehiculo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblKilometraje;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnCalcularPrecios;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.ComboBox cmbFormaAdquisicion;
        private System.Windows.Forms.Label lblFormaAdquisicion;
        private System.Windows.Forms.Label lblTipoDeVehiculo;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.GroupBox grpDatosDelVehiculo;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Button btnAdquirir;
        private System.Windows.Forms.GroupBox grpClienteElegido;
        private System.Windows.Forms.Label lblAdquirirVehiculo;
        private System.Windows.Forms.Label label7;
    }
}