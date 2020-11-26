namespace UI
{
    partial class AsignarFamilias
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
            this.grpDatosUsuario = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblAFamUsuario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpAsignarFamilias = new System.Windows.Forms.GroupBox();
            this.lblFamiliasAsignadas = new System.Windows.Forms.Label();
            this.lblFamiliasDisponibles = new System.Windows.Forms.Label();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lboxFamDisponibles = new System.Windows.Forms.ListBox();
            this.lboxFamAsignadas = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpDatosUsuario.SuspendLayout();
            this.grpAsignarFamilias.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatosUsuario
            // 
            this.grpDatosUsuario.Controls.Add(this.lblUsuario);
            this.grpDatosUsuario.Controls.Add(this.txtUsuario);
            this.grpDatosUsuario.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosUsuario.Location = new System.Drawing.Point(48, 88);
            this.grpDatosUsuario.Name = "grpDatosUsuario";
            this.grpDatosUsuario.Size = new System.Drawing.Size(591, 56);
            this.grpDatosUsuario.TabIndex = 96;
            this.grpDatosUsuario.TabStop = false;
            this.grpDatosUsuario.Text = "Datos del Usuario";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(20, 28);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(52, 17);
            this.lblUsuario.TabIndex = 74;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuario.Location = new System.Drawing.Point(77, 30);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(208, 20);
            this.txtUsuario.TabIndex = 76;
            // 
            // lblAFamUsuario
            // 
            this.lblAFamUsuario.AutoSize = true;
            this.lblAFamUsuario.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAFamUsuario.Location = new System.Drawing.Point(40, 26);
            this.lblAFamUsuario.Name = "lblAFamUsuario";
            this.lblAFamUsuario.Size = new System.Drawing.Size(385, 45);
            this.lblAFamUsuario.TabIndex = 94;
            this.lblAFamUsuario.Text = "Asignar Familias a Usuario";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(454, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 99;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAsignarFamilias
            // 
            this.grpAsignarFamilias.Controls.Add(this.lblFamiliasAsignadas);
            this.grpAsignarFamilias.Controls.Add(this.lblFamiliasDisponibles);
            this.grpAsignarFamilias.Controls.Add(this.btnDesasignar);
            this.grpAsignarFamilias.Controls.Add(this.btnAsignar);
            this.grpAsignarFamilias.Controls.Add(this.lboxFamDisponibles);
            this.grpAsignarFamilias.Controls.Add(this.lboxFamAsignadas);
            this.grpAsignarFamilias.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.grpAsignarFamilias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpAsignarFamilias.Location = new System.Drawing.Point(48, 150);
            this.grpAsignarFamilias.Name = "grpAsignarFamilias";
            this.grpAsignarFamilias.Size = new System.Drawing.Size(591, 223);
            this.grpAsignarFamilias.TabIndex = 95;
            this.grpAsignarFamilias.TabStop = false;
            this.grpAsignarFamilias.Text = "Asignar Familias";
            // 
            // lblFamiliasAsignadas
            // 
            this.lblFamiliasAsignadas.AutoSize = true;
            this.lblFamiliasAsignadas.Location = new System.Drawing.Point(355, 30);
            this.lblFamiliasAsignadas.Name = "lblFamiliasAsignadas";
            this.lblFamiliasAsignadas.Size = new System.Drawing.Size(144, 22);
            this.lblFamiliasAsignadas.TabIndex = 91;
            this.lblFamiliasAsignadas.Text = "Familias Asignadas";
            // 
            // lblFamiliasDisponibles
            // 
            this.lblFamiliasDisponibles.AutoSize = true;
            this.lblFamiliasDisponibles.Location = new System.Drawing.Point(21, 30);
            this.lblFamiliasDisponibles.Name = "lblFamiliasDisponibles";
            this.lblFamiliasDisponibles.Size = new System.Drawing.Size(154, 22);
            this.lblFamiliasDisponibles.TabIndex = 90;
            this.lblFamiliasDisponibles.Text = "Familias Disponibles";
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
            // lboxFamDisponibles
            // 
            this.lboxFamDisponibles.FormattingEnabled = true;
            this.lboxFamDisponibles.ItemHeight = 22;
            this.lboxFamDisponibles.Location = new System.Drawing.Point(23, 55);
            this.lboxFamDisponibles.Name = "lboxFamDisponibles";
            this.lboxFamDisponibles.Size = new System.Drawing.Size(197, 158);
            this.lboxFamDisponibles.TabIndex = 87;
            this.lboxFamDisponibles.Tag = "";
            // 
            // lboxFamAsignadas
            // 
            this.lboxFamAsignadas.FormattingEnabled = true;
            this.lboxFamAsignadas.ItemHeight = 22;
            this.lboxFamAsignadas.Location = new System.Drawing.Point(359, 55);
            this.lboxFamAsignadas.Name = "lboxFamAsignadas";
            this.lboxFamAsignadas.Size = new System.Drawing.Size(211, 158);
            this.lboxFamAsignadas.TabIndex = 75;
            this.lboxFamAsignadas.Tag = "";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(357, 401);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(282, 37);
            this.btnCancelar.TabIndex = 98;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(48, 401);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(285, 37);
            this.btnAceptar.TabIndex = 97;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // AsignarFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.grpDatosUsuario);
            this.Controls.Add(this.lblAFamUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpAsignarFamilias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "AsignarFamilias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AsignarFamilias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsignarFamilias_FormClosing);
            this.Load += new System.EventHandler(this.AsignarFamilias_Load);
            this.grpDatosUsuario.ResumeLayout(false);
            this.grpDatosUsuario.PerformLayout();
            this.grpAsignarFamilias.ResumeLayout(false);
            this.grpAsignarFamilias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatosUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblAFamUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpAsignarFamilias;
        private System.Windows.Forms.Label lblFamiliasAsignadas;
        private System.Windows.Forms.Label lblFamiliasDisponibles;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ListBox lboxFamDisponibles;
        private System.Windows.Forms.ListBox lboxFamAsignadas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}