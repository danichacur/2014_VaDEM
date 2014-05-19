namespace FrbaCommerce.Formularios.Login
{
    partial class FormLogin
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
            this.btnUsuarioNuevo = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsuarioNuevo
            // 
            this.btnUsuarioNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuarioNuevo.Location = new System.Drawing.Point(135, 98);
            this.btnUsuarioNuevo.Name = "btnUsuarioNuevo";
            this.btnUsuarioNuevo.Size = new System.Drawing.Size(104, 23);
            this.btnUsuarioNuevo.TabIndex = 4;
            this.btnUsuarioNuevo.Text = "Nuevo Usuario";
            this.btnUsuarioNuevo.UseVisualStyleBackColor = true;
            this.btnUsuarioNuevo.Click += new System.EventHandler(this.btnUsuarioNuevo_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrar.Location = new System.Drawing.Point(25, 98);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(104, 23);
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 133);
            this.Controls.Add(this.btnUsuarioNuevo);
            this.Controls.Add(this.btnEntrar);
            this.Name = "FormLogin";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsuarioNuevo;
        private System.Windows.Forms.Button btnEntrar;
    }
}