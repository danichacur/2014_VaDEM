namespace FrbaCommerce.Componentes_Comunes
{
    partial class FiltroDgvCheck
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblFiltro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv.Location = new System.Drawing.Point(74, 0);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(218, 142);
            this.dgv.TabIndex = 2;
            // 
            // check
            // 
            this.check.Frozen = true;
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.Width = 30;
            // 
            // lblFiltro
            // 
            this.lblFiltro.Location = new System.Drawing.Point(3, 0);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(75, 18);
            this.lblFiltro.TabIndex = 1;
            this.lblFiltro.Text = "label1";
            // 
            // FiltroDgvCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblFiltro);
            this.Name = "FiltroDgvCheck";
            this.Size = new System.Drawing.Size(292, 142);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
    }
}
