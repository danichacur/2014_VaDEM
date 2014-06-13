namespace FrbaCommerce.Formularios.Abm_Empresa
{
    partial class Empresa_Agregar
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
            this.ctrlAltaModificacion1 = new FrbaCommerce.Componentes_Comunes.ctrlAltaModificacion();
            this.SuspendLayout();
            // 
            // ctrlAltaModificacion1
            // 
            this.ctrlAltaModificacion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAltaModificacion1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAltaModificacion1.Name = "ctrlAltaModificacion1";
            this.ctrlAltaModificacion1.Size = new System.Drawing.Size(352, 97);
            this.ctrlAltaModificacion1.TabIndex = 0;
            // 
            // Empresa_Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 97);
            this.Controls.Add(this.ctrlAltaModificacion1);
            this.Name = "Empresa_Agregar";
            this.Text = "Empresa_Agregar";
            this.Load += new System.EventHandler(this.Empresa_Agregar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FrbaCommerce.Componentes_Comunes.ctrlAltaModificacion ctrlAltaModificacion1;
    }
}