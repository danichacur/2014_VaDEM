namespace FrbaCommerce.Formularios.Facturar_Publicaciones
{
    partial class Facturar_Publicaciones_Listado
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
            this.dgFacturacion = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatosTarjeta = new System.Windows.Forms.TextBox();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFacturacion
            // 
            this.dgFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacturacion.Location = new System.Drawing.Point(40, 39);
            this.dgFacturacion.Name = "dgFacturacion";
            this.dgFacturacion.Size = new System.Drawing.Size(637, 305);
            this.dgFacturacion.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pagar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Numero de Tarjeta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Foma de Pago";
            // 
            // txtDatosTarjeta
            // 
            this.txtDatosTarjeta.Location = new System.Drawing.Point(784, 105);
            this.txtDatosTarjeta.Name = "txtDatosTarjeta";
            this.txtDatosTarjeta.Size = new System.Drawing.Size(121, 20);
            this.txtDatosTarjeta.TabIndex = 5;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(784, 67);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(121, 21);
            this.cmbFormaPago.TabIndex = 4;
            // 
            // Facturar_Publicaciones_Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 356);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDatosTarjeta);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgFacturacion);
            this.Name = "Facturar_Publicaciones_Listado";
            this.Text = "Facturar_Publicaciones_Listado";
            this.Load += new System.EventHandler(this.Facturar_Publicaciones_Listado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFacturacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatosTarjeta;
        private System.Windows.Forms.ComboBox cmbFormaPago;
    }
}