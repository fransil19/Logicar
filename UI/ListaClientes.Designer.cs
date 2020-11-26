namespace UI
{
    partial class ListaClientes
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
            this.lblListaClientes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpClienteElegido = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtClienteSel = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grillaCliente = new System.Windows.Forms.DataGridView();
            this.grpClienteElegido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListaClientes
            // 
            this.lblListaClientes.AutoSize = true;
            this.lblListaClientes.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaClientes.Location = new System.Drawing.Point(27, 25);
            this.lblListaClientes.Name = "lblListaClientes";
            this.lblListaClientes.Size = new System.Drawing.Size(202, 45);
            this.lblListaClientes.TabIndex = 96;
            this.lblListaClientes.Text = "Lista Clientes";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(544, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 95;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpClienteElegido
            // 
            this.grpClienteElegido.Controls.Add(this.btnAgregar);
            this.grpClienteElegido.Controls.Add(this.lblCliente);
            this.grpClienteElegido.Controls.Add(this.txtClienteSel);
            this.grpClienteElegido.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClienteElegido.Location = new System.Drawing.Point(35, 83);
            this.grpClienteElegido.Name = "grpClienteElegido";
            this.grpClienteElegido.Size = new System.Drawing.Size(694, 56);
            this.grpClienteElegido.TabIndex = 103;
            this.grpClienteElegido.TabStop = false;
            this.grpClienteElegido.Text = "Cliente Elegido";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic);
            this.btnAgregar.Location = new System.Drawing.Point(545, 21);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(143, 24);
            this.btnAgregar.TabIndex = 92;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(20, 28);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 17);
            this.lblCliente.TabIndex = 74;
            this.lblCliente.Text = "Cliente";
            // 
            // txtClienteSel
            // 
            this.txtClienteSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtClienteSel.Location = new System.Drawing.Point(78, 25);
            this.txtClienteSel.Name = "txtClienteSel";
            this.txtClienteSel.Size = new System.Drawing.Size(208, 20);
            this.txtClienteSel.TabIndex = 76;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(35, 333);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(226, 37);
            this.btnModificar.TabIndex = 100;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(267, 333);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(229, 37);
            this.btnEliminar.TabIndex = 99;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(502, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(227, 37);
            this.btnCancelar.TabIndex = 98;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grillaCliente
            // 
            this.grillaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCliente.Location = new System.Drawing.Point(35, 145);
            this.grillaCliente.Name = "grillaCliente";
            this.grillaCliente.Size = new System.Drawing.Size(694, 170);
            this.grillaCliente.TabIndex = 97;
            this.grillaCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaCliente_CellContentClick);
            // 
            // ListaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 450);
            this.Controls.Add(this.lblListaClientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpClienteElegido);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grillaCliente);
            this.Name = "ListaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ListaClientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListaClientes_FormClosing);
            this.Load += new System.EventHandler(this.ListaClientes_Load);
            this.grpClienteElegido.ResumeLayout(false);
            this.grpClienteElegido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListaClientes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpClienteElegido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtClienteSel;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView grillaCliente;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
    }
}