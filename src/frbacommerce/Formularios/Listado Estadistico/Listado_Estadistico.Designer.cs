namespace FrbaCommerce.Formularios.Listado_Estadistico
{
    partial class Listado_Estadistico
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
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.lblTipoEstadistica = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.cboTrimestre = new System.Windows.Forms.ComboBox();
            this.cboTipoEstadistica = new System.Windows.Forms.ComboBox();
            this.btnGnerarListado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(26, 30);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 0;
            this.lblAnio.Text = "Año";
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Location = new System.Drawing.Point(26, 64);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(50, 13);
            this.lblTrimestre.TabIndex = 1;
            this.lblTrimestre.Text = "Trimestre";
            // 
            // lblTipoEstadistica
            // 
            this.lblTipoEstadistica.AutoSize = true;
            this.lblTipoEstadistica.Location = new System.Drawing.Point(26, 96);
            this.lblTipoEstadistica.Name = "lblTipoEstadistica";
            this.lblTipoEstadistica.Size = new System.Drawing.Size(84, 13);
            this.lblTipoEstadistica.TabIndex = 2;
            this.lblTipoEstadistica.Text = "Tipo Estadística";
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(123, 22);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(101, 21);
            this.cboAnio.TabIndex = 3;
            // 
            // cboTrimestre
            // 
            this.cboTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrimestre.FormattingEnabled = true;
            this.cboTrimestre.Location = new System.Drawing.Point(123, 56);
            this.cboTrimestre.Name = "cboTrimestre";
            this.cboTrimestre.Size = new System.Drawing.Size(100, 21);
            this.cboTrimestre.TabIndex = 4;
            // 
            // cboTipoEstadistica
            // 
            this.cboTipoEstadistica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEstadistica.FormattingEnabled = true;
            this.cboTipoEstadistica.Location = new System.Drawing.Point(123, 88);
            this.cboTipoEstadistica.Name = "cboTipoEstadistica";
            this.cboTipoEstadistica.Size = new System.Drawing.Size(205, 21);
            this.cboTipoEstadistica.TabIndex = 5;
            // 
            // btnGnerarListado
            // 
            this.btnGnerarListado.Location = new System.Drawing.Point(228, 133);
            this.btnGnerarListado.Name = "btnGnerarListado";
            this.btnGnerarListado.Size = new System.Drawing.Size(100, 29);
            this.btnGnerarListado.TabIndex = 6;
            this.btnGnerarListado.Text = "Generar Listado";
            this.btnGnerarListado.UseVisualStyleBackColor = true;
            // 
            // Listado_Estadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 311);
            this.Controls.Add(this.btnGnerarListado);
            this.Controls.Add(this.cboTipoEstadistica);
            this.Controls.Add(this.cboTrimestre);
            this.Controls.Add(this.cboAnio);
            this.Controls.Add(this.lblTipoEstadistica);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.lblAnio);
            this.Name = "Listado_Estadistico";
            this.Text = "Listados Estadisticos";
            this.Load += new System.EventHandler(this.Listado_Estadistico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.Label lblTipoEstadistica;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.ComboBox cboTrimestre;
        private System.Windows.Forms.ComboBox cboTipoEstadistica;
        private System.Windows.Forms.Button btnGnerarListado;

    }
}