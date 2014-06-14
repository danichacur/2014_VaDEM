namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    partial class Calificar
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
            this.txtDescripPublic = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreVendedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPuntaje = new System.Windows.Forms.ComboBox();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.txtTotalAbonado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDescripPublic
            // 
            this.txtDescripPublic.Enabled = false;
            this.txtDescripPublic.Location = new System.Drawing.Point(168, 12);
            this.txtDescripPublic.Name = "txtDescripPublic";
            this.txtDescripPublic.Size = new System.Drawing.Size(156, 60);
            this.txtDescripPublic.TabIndex = 0;
            this.txtDescripPublic.Text = "";
            this.txtDescripPublic.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción de la Publicación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Vendedor";
            // 
            // txtNombreVendedor
            // 
            this.txtNombreVendedor.Enabled = false;
            this.txtNombreVendedor.Location = new System.Drawing.Point(168, 121);
            this.txtNombreVendedor.Name = "txtNombreVendedor";
            this.txtNombreVendedor.Size = new System.Drawing.Size(156, 20);
            this.txtNombreVendedor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Calificación";
            // 
            // cboPuntaje
            // 
            this.cboPuntaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntaje.FormattingEnabled = true;
            this.cboPuntaje.Location = new System.Drawing.Point(168, 206);
            this.cboPuntaje.Name = "cboPuntaje";
            this.cboPuntaje.Size = new System.Drawing.Size(100, 21);
            this.cboPuntaje.TabIndex = 6;
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(248, 254);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(75, 23);
            this.btnCalificar.TabIndex = 7;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            // 
            // txtTotalAbonado
            // 
            this.txtTotalAbonado.Enabled = false;
            this.txtTotalAbonado.Location = new System.Drawing.Point(168, 168);
            this.txtTotalAbonado.Name = "txtTotalAbonado";
            this.txtTotalAbonado.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAbonado.TabIndex = 8;
            // 
            // Calificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 289);
            this.Controls.Add(this.txtTotalAbonado);
            this.Controls.Add(this.btnCalificar);
            this.Controls.Add(this.cboPuntaje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreVendedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripPublic);
            this.Name = "Calificar";
            this.Text = "Calificar";
            this.Load += new System.EventHandler(this.Calificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDescripPublic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreVendedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPuntaje;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.TextBox txtTotalAbonado;
    }
}