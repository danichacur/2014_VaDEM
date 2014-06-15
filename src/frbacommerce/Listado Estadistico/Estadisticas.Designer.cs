namespace FrbaCommerce.Formularios.Listado_Estadistico
{
    partial class Estadisticas
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.cboTrimestre = new System.Windows.Forms.ComboBox();
            this.lblTipoListado = new System.Windows.Forms.Label();
            this.cboTipoListado = new System.Windows.Forms.ComboBox();
            this.lblTipoVisibilidad = new System.Windows.Forms.Label();
            this.cboVisibilidad = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.lblMes = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(370, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(107, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Listados Estadísticos";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(40, 63);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 13);
            this.lblAnio.TabIndex = 1;
            this.lblAnio.Text = "Año:";
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(114, 63);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(71, 21);
            this.cboAnio.TabIndex = 2;
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Location = new System.Drawing.Point(201, 63);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(53, 13);
            this.lblTrimestre.TabIndex = 3;
            this.lblTrimestre.Text = "Trimestre:";
            // 
            // cboTrimestre
            // 
            this.cboTrimestre.FormattingEnabled = true;
            this.cboTrimestre.Location = new System.Drawing.Point(260, 63);
            this.cboTrimestre.Name = "cboTrimestre";
            this.cboTrimestre.Size = new System.Drawing.Size(127, 21);
            this.cboTrimestre.TabIndex = 4;
            // 
            // lblTipoListado
            // 
            this.lblTipoListado.AutoSize = true;
            this.lblTipoListado.Location = new System.Drawing.Point(40, 100);
            this.lblTipoListado.Name = "lblTipoListado";
            this.lblTipoListado.Size = new System.Drawing.Size(68, 13);
            this.lblTipoListado.TabIndex = 5;
            this.lblTipoListado.Text = "Tipo Listado:";
            // 
            // cboTipoListado
            // 
            this.cboTipoListado.FormattingEnabled = true;
            this.cboTipoListado.Location = new System.Drawing.Point(114, 100);
            this.cboTipoListado.Name = "cboTipoListado";
            this.cboTipoListado.Size = new System.Drawing.Size(273, 21);
            this.cboTipoListado.TabIndex = 6;
            // 
            // lblTipoVisibilidad
            // 
            this.lblTipoVisibilidad.AutoSize = true;
            this.lblTipoVisibilidad.Location = new System.Drawing.Point(393, 100);
            this.lblTipoVisibilidad.Name = "lblTipoVisibilidad";
            this.lblTipoVisibilidad.Size = new System.Drawing.Size(56, 13);
            this.lblTipoVisibilidad.TabIndex = 7;
            this.lblTipoVisibilidad.Text = "Visibilidad:";
            // 
            // cboVisibilidad
            // 
            this.cboVisibilidad.FormattingEnabled = true;
            this.cboVisibilidad.Location = new System.Drawing.Point(455, 100);
            this.cboVisibilidad.Name = "cboVisibilidad";
            this.cboVisibilidad.Size = new System.Drawing.Size(142, 21);
            this.cboVisibilidad.TabIndex = 8;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(43, 127);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 11;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(40, 162);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.Size = new System.Drawing.Size(827, 237);
            this.dgvListado.TabIndex = 12;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(612, 100);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(30, 13);
            this.lblMes.TabIndex = 9;
            this.lblMes.Text = "Mes:";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(648, 100);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(90, 21);
            this.cboMes.TabIndex = 10;
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 425);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cboVisibilidad);
            this.Controls.Add(this.lblTipoVisibilidad);
            this.Controls.Add(this.cboTipoListado);
            this.Controls.Add(this.lblTipoListado);
            this.Controls.Add(this.cboTrimestre);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.cboAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.ComboBox cboTrimestre;
        private System.Windows.Forms.Label lblTipoListado;
        private System.Windows.Forms.ComboBox cboTipoListado;
        private System.Windows.Forms.Label lblTipoVisibilidad;
        private System.Windows.Forms.ComboBox cboVisibilidad;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cboMes;
    }
}