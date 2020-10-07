namespace UI
{
    partial class ListarFamilias
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
            this.grpFamiliaElegida = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblListaDeFamilias = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.btnModificarFamilia = new System.Windows.Forms.Button();
            this.btnEliminarFamilia = new System.Windows.Forms.Button();
            this.grillaFamilias = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.grpFamiliaElegida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaFamilias)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFamiliaElegida
            // 
            this.grpFamiliaElegida.Controls.Add(this.lblNombre);
            this.grpFamiliaElegida.Controls.Add(this.txtNombre);
            this.grpFamiliaElegida.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFamiliaElegida.Location = new System.Drawing.Point(44, 83);
            this.grpFamiliaElegida.Name = "grpFamiliaElegida";
            this.grpFamiliaElegida.Size = new System.Drawing.Size(694, 56);
            this.grpFamiliaElegida.TabIndex = 104;
            this.grpFamiliaElegida.TabStop = false;
            this.grpFamiliaElegida.Text = "Familia Elegida";
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
            this.txtNombre.Location = new System.Drawing.Point(77, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(208, 20);
            this.txtNombre.TabIndex = 76;
            // 
            // lblListaDeFamilias
            // 
            this.lblListaDeFamilias.AutoSize = true;
            this.lblListaDeFamilias.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaDeFamilias.Location = new System.Drawing.Point(36, 25);
            this.lblListaDeFamilias.Name = "lblListaDeFamilias";
            this.lblListaDeFamilias.Size = new System.Drawing.Size(250, 45);
            this.lblListaDeFamilias.TabIndex = 97;
            this.lblListaDeFamilias.Text = "Lista de Familias";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(394, 403);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(344, 37);
            this.btnCancelar.TabIndex = 103;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(44, 403);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(344, 37);
            this.btnAceptar.TabIndex = 102;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarFamilia.Location = new System.Drawing.Point(44, 333);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.Size = new System.Drawing.Size(230, 37);
            this.btnAgregarFamilia.TabIndex = 101;
            this.btnAgregarFamilia.Text = "Agregar Familia";
            this.btnAgregarFamilia.UseVisualStyleBackColor = true;
            this.btnAgregarFamilia.Click += new System.EventHandler(this.btnAgregarFamilia_Click);
            // 
            // btnModificarFamilia
            // 
            this.btnModificarFamilia.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarFamilia.Location = new System.Drawing.Point(280, 333);
            this.btnModificarFamilia.Name = "btnModificarFamilia";
            this.btnModificarFamilia.Size = new System.Drawing.Size(217, 37);
            this.btnModificarFamilia.TabIndex = 100;
            this.btnModificarFamilia.Text = "Modificar Familia";
            this.btnModificarFamilia.UseVisualStyleBackColor = true;
            this.btnModificarFamilia.Click += new System.EventHandler(this.btnModificarFamilia_Click);
            // 
            // btnEliminarFamilia
            // 
            this.btnEliminarFamilia.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFamilia.Location = new System.Drawing.Point(503, 333);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(235, 37);
            this.btnEliminarFamilia.TabIndex = 99;
            this.btnEliminarFamilia.Text = "Eliminar Familia";
            this.btnEliminarFamilia.UseVisualStyleBackColor = true;
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);
            // 
            // grillaFamilias
            // 
            this.grillaFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaFamilias.Location = new System.Drawing.Point(44, 145);
            this.grillaFamilias.MultiSelect = false;
            this.grillaFamilias.Name = "grillaFamilias";
            this.grillaFamilias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaFamilias.Size = new System.Drawing.Size(694, 170);
            this.grillaFamilias.TabIndex = 98;
            this.grillaFamilias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaFamilias_CellContentClick);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(553, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 96;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ListarFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.grpFamiliaElegida);
            this.Controls.Add(this.lblListaDeFamilias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnAgregarFamilia);
            this.Controls.Add(this.btnModificarFamilia);
            this.Controls.Add(this.btnEliminarFamilia);
            this.Controls.Add(this.grillaFamilias);
            this.Controls.Add(this.label7);
            this.Name = "ListarFamilias";
            this.Text = "ListarFamilias";
            this.Load += new System.EventHandler(this.ListarFamilias_Load);
            this.grpFamiliaElegida.ResumeLayout(false);
            this.grpFamiliaElegida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaFamilias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFamiliaElegida;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblListaDeFamilias;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnAgregarFamilia;
        private System.Windows.Forms.Button btnModificarFamilia;
        private System.Windows.Forms.Button btnEliminarFamilia;
        private System.Windows.Forms.DataGridView grillaFamilias;
        private System.Windows.Forms.Label label7;
    }
}