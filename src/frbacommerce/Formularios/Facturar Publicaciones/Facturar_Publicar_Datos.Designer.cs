namespace FrbaCommerce.Formularios.Facturar_Publicaciones
{
    partial class Facturar_Publicar_Datos
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
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.txtDatosTarjeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(113, 27);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(121, 21);
            this.cmbFormaPago.TabIndex = 0;
            // 
            // txtDatosTarjeta
            // 
            this.txtDatosTarjeta.Location = new System.Drawing.Point(113, 65);
            this.txtDatosTarjeta.Name = "txtDatosTarjeta";
            this.txtDatosTarjeta.Size = new System.Drawing.Size(121, 20);
            this.txtDatosTarjeta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Foma de Pago";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero de Tarjeta";
            // 
            // Facturar_Publicar_Datos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDatosTarjeta);
            this.Controls.Add(this.cmbFormaPago);
            this.Name = "Facturar_Publicar_Datos";
            this.Text = "Facturar_Publicar_Datos";
            this.Load += new System.EventHandler(this.Facturar_Publicar_Datos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.TextBox txtDatosTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}