namespace FrbaCommerce.Formularios.Generar_Publicacion
{
    partial class Publicacion_Alta
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
            this.ctrlAltaModificacion1.Location = new System.Drawing.Point(24, 12);
            this.ctrlAltaModificacion1.Name = "ctrlAltaModificacion1";
            this.ctrlAltaModificacion1.Size = new System.Drawing.Size(759, 586);
            this.ctrlAltaModificacion1.TabIndex = 24;
            // 
            // Publicacion_Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 598);
            this.Controls.Add(this.ctrlAltaModificacion1);
            this.Name = "Publicacion_Alta";
            this.Text = "Publicacion_Alta";
            this.Load += new System.EventHandler(this.Publicacion_Alta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FrbaCommerce.Componentes_Comunes.ctrlAltaModificacion ctrlAltaModificacion1;

    }
}