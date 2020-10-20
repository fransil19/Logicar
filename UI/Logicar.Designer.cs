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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuAdministrarEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministrarFamilias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdministrarEmpleados,
            this.mnuAdministrarFamilias,
            this.mnuSesion});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mnuAdministrarEmpleados
            // 
            this.mnuAdministrarEmpleados.Name = "mnuAdministrarEmpleados";
            this.mnuAdministrarEmpleados.Size = new System.Drawing.Size(142, 20);
            this.mnuAdministrarEmpleados.Text = "Administrar Empleados";
            this.mnuAdministrarEmpleados.Click += new System.EventHandler(this.mnuAdministrarEmpleados_Click);
            // 
            // mnuAdministrarFamilias
            // 
            this.mnuAdministrarFamilias.Name = "mnuAdministrarFamilias";
            this.mnuAdministrarFamilias.Size = new System.Drawing.Size(127, 20);
            this.mnuAdministrarFamilias.Text = "Administrar Familias";
            this.mnuAdministrarFamilias.Click += new System.EventHandler(this.mnuAdministrarFamilias_Click);
            // 
            // mnuSesion
            // 
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Size = new System.Drawing.Size(53, 20);
            this.mnuSesion.Text = "Sesion";
            // 
            // Logicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Logicar";
            this.Text = "Logicar";
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
    }
}



