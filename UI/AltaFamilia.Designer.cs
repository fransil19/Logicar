namespace UI
{
    partial class AltaFamilia
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
            this.grpDatosDeFamilia = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAltaDeFamilia = new System.Windows.Forms.Label();
            this.grpAsignarPatentes = new System.Windows.Forms.GroupBox();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lboxPatNoAsig = new System.Windows.Forms.ListBox();
            this.lboxPatAsig = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpDatosDeFamilia.SuspendLayout();
            this.grpAsignarPatentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatosDeFamilia
            // 
            this.grpDatosDeFamilia.Controls.Add(this.lblNombre);
            this.grpDatosDeFamilia.Controls.Add(this.txtNombre);
            this.grpDatosDeFamilia.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosDeFamilia.Location = new System.Drawing.Point(41, 86);
            this.grpDatosDeFamilia.Name = "grpDatosDeFamilia";
            this.grpDatosDeFamilia.Size = new System.Drawing.Size(591, 56);
            this.grpDatosDeFamilia.TabIndex = 94;
            this.grpDatosDeFamilia.TabStop = false;
            this.grpDatosDeFamilia.Text = "Datos de Familia";
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
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.Location = new System.Drawing.Point(77, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(208, 20);
            this.txtNombre.TabIndex = 76;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(461, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 93;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAltaDeFamilia
            // 
            this.lblAltaDeFamilia.AutoSize = true;
            this.lblAltaDeFamilia.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltaDeFamilia.Location = new System.Drawing.Point(33, 28);
            this.lblAltaDeFamilia.Name = "lblAltaDeFamilia";
            this.lblAltaDeFamilia.Size = new System.Drawing.Size(228, 45);
            this.lblAltaDeFamilia.TabIndex = 92;
            this.lblAltaDeFamilia.Text = "Alta de Familia";
            // 
            // grpAsignarPatentes
            // 
            this.grpAsignarPatentes.Controls.Add(this.btnDesasignar);
            this.grpAsignarPatentes.Controls.Add(this.btnAsignar);
            this.grpAsignarPatentes.Controls.Add(this.lboxPatNoAsig);
            this.grpAsignarPatentes.Controls.Add(this.lboxPatAsig);
            this.grpAsignarPatentes.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.grpAsignarPatentes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpAsignarPatentes.Location = new System.Drawing.Point(41, 163);
            this.grpAsignarPatentes.Name = "grpAsignarPatentes";
            this.grpAsignarPatentes.Size = new System.Drawing.Size(591, 223);
            this.grpAsignarPatentes.TabIndex = 95;
            this.grpAsignarPatentes.TabStop = false;
            this.grpAsignarPatentes.Text = "Asignar Patentes";
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesasignar.Location = new System.Drawing.Point(226, 123);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(127, 37);
            this.btnDesasignar.TabIndex = 89;
            this.btnDesasignar.Text = "<-Desasignar";
            this.btnDesasignar.UseVisualStyleBackColor = true;
            this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.Location = new System.Drawing.Point(226, 62);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(127, 37);
            this.btnAsignar.TabIndex = 88;
            this.btnAsignar.Text = "Asignar->";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lboxPatNoAsig
            // 
            this.lboxPatNoAsig.FormattingEnabled = true;
            this.lboxPatNoAsig.ItemHeight = 22;
            this.lboxPatNoAsig.Location = new System.Drawing.Point(23, 33);
            this.lboxPatNoAsig.Name = "lboxPatNoAsig";
            this.lboxPatNoAsig.Size = new System.Drawing.Size(197, 180);
            this.lboxPatNoAsig.TabIndex = 87;
            this.lboxPatNoAsig.Tag = "";
            // 
            // lboxPatAsig
            // 
            this.lboxPatAsig.FormattingEnabled = true;
            this.lboxPatAsig.ItemHeight = 22;
            this.lboxPatAsig.Location = new System.Drawing.Point(359, 33);
            this.lboxPatAsig.Name = "lboxPatAsig";
            this.lboxPatAsig.Size = new System.Drawing.Size(211, 180);
            this.lboxPatAsig.TabIndex = 75;
            this.lboxPatAsig.Tag = "";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(350, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(282, 37);
            this.btnCancelar.TabIndex = 97;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(41, 400);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(285, 37);
            this.btnAceptar.TabIndex = 96;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // AltaFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.grpDatosDeFamilia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAltaDeFamilia);
            this.Controls.Add(this.grpAsignarPatentes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "AltaFamilia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AltaFamilia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltaFamilia_FormClosing);
            this.Load += new System.EventHandler(this.AltaFamilia_Load);
            this.grpDatosDeFamilia.ResumeLayout(false);
            this.grpDatosDeFamilia.PerformLayout();
            this.grpAsignarPatentes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatosDeFamilia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAltaDeFamilia;
        private System.Windows.Forms.GroupBox grpAsignarPatentes;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ListBox lboxPatNoAsig;
        private System.Windows.Forms.ListBox lboxPatAsig;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}