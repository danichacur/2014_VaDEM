namespace FrbaCommerce.Formularios.Comprar_Ofertar
{
    partial class Comprar_Ofertar_Ofertar
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
            this.lblVen = new System.Windows.Forms.Label();
            this.lblOferta = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblOfertaActual = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnOfertar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVen
            // 
            this.lblVen.AutoSize = true;
            this.lblVen.Location = new System.Drawing.Point(45, 23);
            this.lblVen.Name = "lblVen";
            this.lblVen.Size = new System.Drawing.Size(56, 13);
            this.lblVen.TabIndex = 0;
            this.lblVen.Text = "Vendedor:";
            // 
            // lblOferta
            // 
            this.lblOferta.AutoSize = true;
            this.lblOferta.Location = new System.Drawing.Point(45, 51);
            this.lblOferta.Name = "lblOferta";
            this.lblOferta.Size = new System.Drawing.Size(72, 13);
            this.lblOferta.TabIndex = 1;
            this.lblOferta.Text = "Oferta Actual:";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(107, 23);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblVendedor.TabIndex = 2;
            // 
            // lblOfertaActual
            // 
            this.lblOfertaActual.AutoSize = true;
            this.lblOfertaActual.Location = new System.Drawing.Point(124, 51);
            this.lblOfertaActual.Name = "lblOfertaActual";
            this.lblOfertaActual.Size = new System.Drawing.Size(0, 13);
            this.lblOfertaActual.TabIndex = 3;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(80, 110);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(154, 110);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 5;
            this.txtMonto.KeyPress += this.txtMonto_KeyPress;
            // 
            // btnOfertar
            // 
            this.btnOfertar.Location = new System.Drawing.Point(260, 110);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(75, 23);
            this.btnOfertar.TabIndex = 6;
            this.btnOfertar.Text = "Ofertar";
            this.btnOfertar.UseVisualStyleBackColor = true;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // 
            // Comprar_Ofertar_Ofertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 230);
            this.Controls.Add(this.btnOfertar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblOfertaActual);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblOferta);
            this.Controls.Add(this.lblVen);
            this.Name = "Comprar_Ofertar_Ofertar";
            this.Text = "Comprar_Ofertar_Ofertar";
            this.Load += new System.EventHandler(this.Comprar_Ofertar_Ofertar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVen;
        private System.Windows.Forms.Label lblOferta;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblOfertaActual;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnOfertar;
    }
}