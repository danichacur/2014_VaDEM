namespace FrbaCommerce.Formularios.Abm_Empresa
{
    partial class Empresa_Listar
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
            this.ctrlABM1 = new FrbaCommerce.Componentes_Comunes.ctrlABM();
            this.SuspendLayout();
            // 
            // ctrlABM1
            // 
            this.ctrlABM1.Location = new System.Drawing.Point(44, 61);
            this.ctrlABM1.Name = "ctrlABM1";
            this.ctrlABM1.Size = new System.Drawing.Size(881, 412);
            this.ctrlABM1.TabIndex = 0;
            // 
            // Empresa_Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 702);
            this.Controls.Add(this.ctrlABM1);
            this.Name = "Empresa_Listar";
            this.Text = "Empresa_Listar";
            this.Load += new System.EventHandler(this.Empresa_Listar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FrbaCommerce.Componentes_Comunes.ctrlABM ctrlABM1;
    }
}