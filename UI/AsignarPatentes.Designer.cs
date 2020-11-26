namespace UI
{
    partial class AsignarPatentes
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
            this.label7 = new System.Windows.Forms.Label();
            this.grpDatosUsuario = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblAPatUsuario = new System.Windows.Forms.Label();
            this.grpAsignarPatentes = new System.Windows.Forms.GroupBox();
            this.lblPatAsignadas = new System.Windows.Forms.Label();
            this.lblPatDisponibles = new System.Windows.Forms.Label();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lboxPatDisponibles = new System.Windows.Forms.ListBox();
            this.lboxPatAsignadas = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpDatosUsuario.SuspendLayout();
            this.grpAsignarPatentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(454, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 105;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpDatosUsuario
            // 
            this.grpDatosUsuario.Controls.Add(this.lblUsuario);
            this.grpDatosUsuario.Controls.Add(this.txtUsuario);
            this.grpDatosUsuario.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatosUsuario.Location = new System.Drawing.Point(48, 88);
            this.grpDatosUsuario.Name = "grpDatosUsuario";
            this.grpDatosUsuario.Size = new System.Drawing.Size(591, 56);
            this.grpDatosUsuario.TabIndex = 102;
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
            // lblAPatUsuario
            // 
            this.lblAPatUsuario.AutoSize = true;
            this.lblAPatUsuario.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPatUsuario.Location = new System.Drawing.Point(40, 26);
            this.lblAPatUsuario.Name = "lblAPatUsuario";
            this.lblAPatUsuario.Size = new System.Drawing.Size(385, 45);
            this.lblAPatUsuario.TabIndex = 100;
            this.lblAPatUsuario.Text = "Asignar Patentes a Usuario";
            // 
            // grpAsignarPatentes
            // 
            this.grpAsignarPatentes.Controls.Add(this.lblPatAsignadas);
            this.grpAsignarPatentes.Controls.Add(this.lblPatDisponibles);
            this.grpAsignarPatentes.Controls.Add(this.btnDesasignar);
            this.grpAsignarPatentes.Controls.Add(this.btnAsignar);
            this.grpAsignarPatentes.Controls.Add(this.lboxPatDisponibles);
            this.grpAsignarPatentes.Controls.Add(this.lboxPatAsignadas);
            this.grpAsignarPatentes.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.grpAsignarPatentes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpAsignarPatentes.Location = new System.Drawing.Point(48, 150);
            this.grpAsignarPatentes.Name = "grpAsignarPatentes";
            this.grpAsignarPatentes.Size = new System.Drawing.Size(591, 223);
            this.grpAsignarPatentes.TabIndex = 101;
            this.grpAsignarPatentes.TabStop = false;
            this.grpAsignarPatentes.Text = "Asignar Patentes";
            // 
            // lblPatAsignadas
            // 
            this.lblPatAsignadas.AutoSize = true;
            this.lblPatAsignadas.Location = new System.Drawing.Point(355, 30);
            this.lblPatAsignadas.Name = "lblPatAsignadas";
            this.lblPatAsignadas.Size = new System.Drawing.Size(143, 22);
            this.lblPatAsignadas.TabIndex = 91;
            this.lblPatAsignadas.Text = "Patentes Asignadas";
            // 
            // lblPatDisponibles
            // 
            this.lblPatDisponibles.AutoSize = true;
            this.lblPatDisponibles.Location = new System.Drawing.Point(21, 30);
            this.lblPatDisponibles.Name = "lblPatDisponibles";
            this.lblPatDisponibles.Size = new System.Drawing.Size(153, 22);
            this.lblPatDisponibles.TabIndex = 90;
            this.lblPatDisponibles.Text = "Patentes Disponibles";
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
            // lboxPatDisponibles
            // 
            this.lboxPatDisponibles.FormattingEnabled = true;
            this.lboxPatDisponibles.ItemHeight = 22;
            this.lboxPatDisponibles.Location = new System.Drawing.Point(23, 55);
            this.lboxPatDisponibles.Name = "lboxPatDisponibles";
            this.lboxPatDisponibles.Size = new System.Drawing.Size(197, 158);
            this.lboxPatDisponibles.TabIndex = 87;
            this.lboxPatDisponibles.Tag = "";
            // 
            // lboxPatAsignadas
            // 
            this.lboxPatAsignadas.FormattingEnabled = true;
            this.lboxPatAsignadas.ItemHeight = 22;
            this.lboxPatAsignadas.Location = new System.Drawing.Point(359, 55);
            this.lboxPatAsignadas.Name = "lboxPatAsignadas";
            this.lboxPatAsignadas.Size = new System.Drawing.Size(211, 158);
            this.lboxPatAsignadas.TabIndex = 75;
            this.lboxPatAsignadas.Tag = "";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(357, 401);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(282, 37);
            this.btnCancelar.TabIndex = 104;
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
            this.btnAceptar.TabIndex = 103;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // AsignarPatentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpDatosUsuario);
            this.Controls.Add(this.lblAPatUsuario);
            this.Controls.Add(this.grpAsignarPatentes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "AsignarPatentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AsignarPatentes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsignarPatentes_FormClosing);
            this.Load += new System.EventHandler(this.AsignarPatentes_Load);
            this.grpDatosUsuario.ResumeLayout(false);
            this.grpDatosUsuario.PerformLayout();
            this.grpAsignarPatentes.ResumeLayout(false);
            this.grpAsignarPatentes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpDatosUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblAPatUsuario;
        private System.Windows.Forms.GroupBox grpAsignarPatentes;
        private System.Windows.Forms.Label lblPatAsignadas;
        private System.Windows.Forms.Label lblPatDisponibles;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ListBox lboxPatDisponibles;
        private System.Windows.Forms.ListBox lboxPatAsignadas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}