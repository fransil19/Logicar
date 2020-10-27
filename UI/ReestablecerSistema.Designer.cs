namespace UI
{
    partial class ReestablecerSistema
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
            this.grpBitacora = new System.Windows.Forms.GroupBox();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dtFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.cmbCriticidad = new System.Windows.Forms.ComboBox();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblCriticidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.grillaBitacora = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblReestablecerSistema = new System.Windows.Forms.Label();
            this.btnReestablecerDigitos = new System.Windows.Forms.Button();
            this.btnRestaurarBase = new System.Windows.Forms.Button();
            this.grpBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBitacora
            // 
            this.grpBitacora.Controls.Add(this.btnRefrescar);
            this.grpBitacora.Controls.Add(this.dtFechaHasta);
            this.grpBitacora.Controls.Add(this.lblFechaHasta);
            this.grpBitacora.Controls.Add(this.dtFechaDesde);
            this.grpBitacora.Controls.Add(this.lblFechaDesde);
            this.grpBitacora.Controls.Add(this.cmbCriticidad);
            this.grpBitacora.Controls.Add(this.cmbUsuario);
            this.grpBitacora.Controls.Add(this.lblCriticidad);
            this.grpBitacora.Controls.Add(this.lblUsuario);
            this.grpBitacora.Controls.Add(this.grillaBitacora);
            this.grpBitacora.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBitacora.Location = new System.Drawing.Point(39, 99);
            this.grpBitacora.Name = "grpBitacora";
            this.grpBitacora.Size = new System.Drawing.Size(694, 276);
            this.grpBitacora.TabIndex = 108;
            this.grpBitacora.TabStop = false;
            this.grpBitacora.Text = "Bitácora";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.Location = new System.Drawing.Point(593, 21);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(95, 64);
            this.btnRefrescar.TabIndex = 106;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dtFechaHasta
            // 
            this.dtFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtFechaHasta.Location = new System.Drawing.Point(393, 60);
            this.dtFechaHasta.Name = "dtFechaHasta";
            this.dtFechaHasta.Size = new System.Drawing.Size(194, 20);
            this.dtFechaHasta.TabIndex = 112;
            this.dtFechaHasta.Value = new System.DateTime(2020, 7, 15, 10, 56, 18, 0);
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(310, 63);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(76, 17);
            this.lblFechaHasta.TabIndex = 111;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // dtFechaDesde
            // 
            this.dtFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtFechaDesde.Location = new System.Drawing.Point(91, 60);
            this.dtFechaDesde.Name = "dtFechaDesde";
            this.dtFechaDesde.Size = new System.Drawing.Size(194, 20);
            this.dtFechaDesde.TabIndex = 110;
            this.dtFechaDesde.Value = new System.DateTime(2020, 7, 15, 10, 56, 18, 0);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(6, 63);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(79, 17);
            this.lblFechaDesde.TabIndex = 109;
            this.lblFechaDesde.Text = "Fecha Desde";
            // 
            // cmbCriticidad
            // 
            this.cmbCriticidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbCriticidad.FormattingEnabled = true;
            this.cmbCriticidad.Location = new System.Drawing.Point(393, 21);
            this.cmbCriticidad.Name = "cmbCriticidad";
            this.cmbCriticidad.Size = new System.Drawing.Size(194, 21);
            this.cmbCriticidad.TabIndex = 108;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(91, 21);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(194, 21);
            this.cmbUsuario.TabIndex = 107;
            // 
            // lblCriticidad
            // 
            this.lblCriticidad.AutoSize = true;
            this.lblCriticidad.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriticidad.Location = new System.Drawing.Point(310, 25);
            this.lblCriticidad.Name = "lblCriticidad";
            this.lblCriticidad.Size = new System.Drawing.Size(63, 17);
            this.lblCriticidad.TabIndex = 105;
            this.lblCriticidad.Text = "Criticidad";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(6, 25);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(52, 17);
            this.lblUsuario.TabIndex = 103;
            this.lblUsuario.Text = "Usuario";
            // 
            // grillaBitacora
            // 
            this.grillaBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBitacora.Location = new System.Drawing.Point(6, 95);
            this.grillaBitacora.Name = "grillaBitacora";
            this.grillaBitacora.Size = new System.Drawing.Size(682, 175);
            this.grillaBitacora.TabIndex = 102;
            this.grillaBitacora.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaBitacora_CellContentClick);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(548, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 107;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReestablecerSistema
            // 
            this.lblReestablecerSistema.AutoSize = true;
            this.lblReestablecerSistema.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReestablecerSistema.Location = new System.Drawing.Point(31, 37);
            this.lblReestablecerSistema.Name = "lblReestablecerSistema";
            this.lblReestablecerSistema.Size = new System.Drawing.Size(293, 45);
            this.lblReestablecerSistema.TabIndex = 106;
            this.lblReestablecerSistema.Text = "Reestablecer Sistema";
            // 
            // btnReestablecerDigitos
            // 
            this.btnReestablecerDigitos.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReestablecerDigitos.Location = new System.Drawing.Point(377, 390);
            this.btnReestablecerDigitos.Name = "btnReestablecerDigitos";
            this.btnReestablecerDigitos.Size = new System.Drawing.Size(356, 37);
            this.btnReestablecerDigitos.TabIndex = 110;
            this.btnReestablecerDigitos.Text = "Recalcular Digitos";
            this.btnReestablecerDigitos.UseVisualStyleBackColor = true;
            this.btnReestablecerDigitos.Click += new System.EventHandler(this.btnReestablecerDigitos_Click);
            // 
            // btnRestaurarBase
            // 
            this.btnRestaurarBase.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurarBase.Location = new System.Drawing.Point(39, 390);
            this.btnRestaurarBase.Name = "btnRestaurarBase";
            this.btnRestaurarBase.Size = new System.Drawing.Size(332, 37);
            this.btnRestaurarBase.TabIndex = 109;
            this.btnRestaurarBase.Text = "Restaurar Base";
            this.btnRestaurarBase.UseVisualStyleBackColor = true;
            this.btnRestaurarBase.Click += new System.EventHandler(this.btnRestaurarBase_Click);
            // 
            // ReestablecerSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.grpBitacora);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblReestablecerSistema);
            this.Controls.Add(this.btnReestablecerDigitos);
            this.Controls.Add(this.btnRestaurarBase);
            this.Name = "ReestablecerSistema";
            this.Text = "ReestablecerSistema";
            this.Load += new System.EventHandler(this.ReestablecerSistema_Load);
            this.grpBitacora.ResumeLayout(false);
            this.grpBitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBitacora;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DateTimePicker dtFechaHasta;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.ComboBox cmbCriticidad;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblCriticidad;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DataGridView grillaBitacora;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblReestablecerSistema;
        private System.Windows.Forms.Button btnReestablecerDigitos;
        private System.Windows.Forms.Button btnRestaurarBase;
    }
}