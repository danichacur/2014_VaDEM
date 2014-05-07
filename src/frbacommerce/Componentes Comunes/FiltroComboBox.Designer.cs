namespace FrbaCommerce.Componentes_Comunes
{
    partial class FiltroComboBox
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblFiltro
            // 
            this.lblFiltro.Location = new System.Drawing.Point(3, 0);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(100, 18);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "label1";
            // 
            // cboFiltro
            // 
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Location = new System.Drawing.Point(72, 0);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(121, 21);
            this.cboFiltro.TabIndex = 2;
            // 
            // FiltroComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Name = "FiltroComboBox";
            this.Size = new System.Drawing.Size(195, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
    }
}
