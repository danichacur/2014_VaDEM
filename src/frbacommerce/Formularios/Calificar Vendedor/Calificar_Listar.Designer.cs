﻿namespace FrbaCommerce.Formularios.Calificar_Vendedor
{
    partial class Calificar_Listar
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
            this.ctrlABM1.Location = new System.Drawing.Point(13, 49);
            this.ctrlABM1.Name = "ctrlABM1";
            this.ctrlABM1.Size = new System.Drawing.Size(881, 412);
            this.ctrlABM1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Listado de Pendientes de Calificar";
            // 
            // Calificar_Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 432);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlABM1);
            this.Name = "Calificar_Listar";
            this.Text = "Calificar_Listar";
            this.Load += new System.EventHandler(this.Calificar_Listar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrbaCommerce.Componentes_Comunes.ctrlABM ctrlABM1;
        private System.Windows.Forms.Label label1;
    }
}