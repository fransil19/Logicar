namespace UI
{
    partial class ListaEmpleados
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnAsignarFam = new System.Windows.Forms.Button();
            this.btnAsignarPat = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grillaEmpleado = new System.Windows.Forms.DataGridView();
            this.lblListaUsuarios = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuarioSel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpleado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(382, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(344, 37);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(32, 403);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(344, 37);
            this.btnAceptar.TabIndex = 92;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnAsignarFam
            // 
            this.btnAsignarFam.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarFam.Location = new System.Drawing.Point(32, 333);
            this.btnAsignarFam.Name = "btnAsignarFam";
            this.btnAsignarFam.Size = new System.Drawing.Size(226, 37);
            this.btnAsignarFam.TabIndex = 91;
            this.btnAsignarFam.Text = "Asignar Familias";
            this.btnAsignarFam.UseVisualStyleBackColor = true;
            // 
            // btnAsignarPat
            // 
            this.btnAsignarPat.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPat.Location = new System.Drawing.Point(264, 333);
            this.btnAsignarPat.Name = "btnAsignarPat";
            this.btnAsignarPat.Size = new System.Drawing.Size(229, 37);
            this.btnAsignarPat.TabIndex = 90;
            this.btnAsignarPat.Text = "Asignar Patentes";
            this.btnAsignarPat.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(499, 333);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(227, 37);
            this.btnEliminar.TabIndex = 89;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // grillaEmpleado
            // 
            this.grillaEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEmpleado.Location = new System.Drawing.Point(32, 145);
            this.grillaEmpleado.Name = "grillaEmpleado";
            this.grillaEmpleado.Size = new System.Drawing.Size(694, 170);
            this.grillaEmpleado.TabIndex = 88;
            this.grillaEmpleado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaEmpleado_CellContentClick);
            // 
            // lblListaUsuarios
            // 
            this.lblListaUsuarios.AutoSize = true;
            this.lblListaUsuarios.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaUsuarios.Location = new System.Drawing.Point(24, 25);
            this.lblListaUsuarios.Name = "lblListaUsuarios";
            this.lblListaUsuarios.Size = new System.Drawing.Size(217, 45);
            this.lblListaUsuarios.TabIndex = 87;
            this.lblListaUsuarios.Text = "Lista Usuarios";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(541, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 86;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 74;
            this.label1.Text = "Usuario";
            // 
            // txtUsuarioSel
            // 
            this.txtUsuarioSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUsuarioSel.Location = new System.Drawing.Point(77, 30);
            this.txtUsuarioSel.Name = "txtUsuarioSel";
            this.txtUsuarioSel.Size = new System.Drawing.Size(208, 20);
            this.txtUsuarioSel.TabIndex = 76;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsuarioSel);
            this.groupBox1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 56);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario Elegido";
            // 
            // ListaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnAsignarFam);
            this.Controls.Add(this.btnAsignarPat);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.grillaEmpleado);
            this.Controls.Add(this.lblListaUsuarios);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListaEmpleados";
            this.Text = "ListaEmpleados";
            this.Load += new System.EventHandler(this.ListaEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaEmpleado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnAsignarFam;
        private System.Windows.Forms.Button btnAsignarPat;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView grillaEmpleado;
        private System.Windows.Forms.Label lblListaUsuarios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuarioSel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}