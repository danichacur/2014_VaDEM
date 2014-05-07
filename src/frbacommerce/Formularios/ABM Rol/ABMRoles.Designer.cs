namespace FrbaCommerce.ABM_Rol
{
    partial class ABM_Rol
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlABM1
            // 
            this.ctrlABM1.Location = new System.Drawing.Point(0, 50);
            this.ctrlABM1.Name = "ctrlABM1";
            this.ctrlABM1.Size = new System.Drawing.Size(407, 371);
            this.ctrlABM1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "AMB DE ROLES";
            // 
            // ABM_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlABM1);
            this.Name = "ABM_Rol";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ABM_Rol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrbaCommerce.Componentes_Comunes.ctrlABM ctrlABM1;
        private System.Windows.Forms.Label label1;
    }
}