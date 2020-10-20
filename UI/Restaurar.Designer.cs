namespace UI
{
    partial class Restaurar
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
            this.lblRestaurarBase = new System.Windows.Forms.Label();
            this.grpRestaurar = new System.Windows.Forms.GroupBox();
            this.btnOrigen = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grpRestaurar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRestaurarBase
            // 
            this.lblRestaurarBase.AutoSize = true;
            this.lblRestaurarBase.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestaurarBase.Location = new System.Drawing.Point(37, 36);
            this.lblRestaurarBase.Name = "lblRestaurarBase";
            this.lblRestaurarBase.Size = new System.Drawing.Size(221, 45);
            this.lblRestaurarBase.TabIndex = 115;
            this.lblRestaurarBase.Text = "Restaurar Base";
            // 
            // grpRestaurar
            // 
            this.grpRestaurar.Controls.Add(this.btnOrigen);
            this.grpRestaurar.Controls.Add(this.txtDestino);
            this.grpRestaurar.Controls.Add(this.lblOrigen);
            this.grpRestaurar.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic);
            this.grpRestaurar.Location = new System.Drawing.Point(36, 94);
            this.grpRestaurar.Name = "grpRestaurar";
            this.grpRestaurar.Size = new System.Drawing.Size(598, 109);
            this.grpRestaurar.TabIndex = 114;
            this.grpRestaurar.TabStop = false;
            this.grpRestaurar.Text = "Restaurar";
            // 
            // btnOrigen
            // 
            this.btnOrigen.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic);
            this.btnOrigen.Location = new System.Drawing.Point(549, 48);
            this.btnOrigen.Name = "btnOrigen";
            this.btnOrigen.Size = new System.Drawing.Size(29, 30);
            this.btnOrigen.TabIndex = 110;
            this.btnOrigen.Text = "...";
            this.btnOrigen.UseVisualStyleBackColor = true;
            // 
            // txtDestino
            // 
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDestino.Location = new System.Drawing.Point(64, 52);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(468, 20);
            this.txtDestino.TabIndex = 109;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(6, 55);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(45, 17);
            this.lblOrigen.TabIndex = 103;
            this.lblOrigen.Text = "Origen";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(332, 228);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(302, 37);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.Location = new System.Drawing.Point(36, 228);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(290, 37);
            this.btnRestaurar.TabIndex = 116;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(449, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 69);
            this.label7.TabIndex = 113;
            this.label7.Text = "Logicar";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Restaurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 286);
            this.Controls.Add(this.lblRestaurarBase);
            this.Controls.Add(this.grpRestaurar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.label7);
            this.Name = "Restaurar";
            this.Text = "Restaurar";
            this.grpRestaurar.ResumeLayout(false);
            this.grpRestaurar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRestaurarBase;
        private System.Windows.Forms.GroupBox grpRestaurar;
        private System.Windows.Forms.Button btnOrigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Label label7;
    }
}