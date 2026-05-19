namespace TP_WinForm {
    partial class frmAgregarCategoria {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.btnAceptarCategoria = new System.Windows.Forms.Button();
            this.btnCancelarCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion:";
            // 
            // txtDescripcionCategoria
            // 
            this.txtDescripcionCategoria.Location = new System.Drawing.Point(123, 90);
            this.txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            this.txtDescripcionCategoria.Size = new System.Drawing.Size(136, 20);
            this.txtDescripcionCategoria.TabIndex = 1;
            // 
            // btnAceptarCategoria
            // 
            this.btnAceptarCategoria.Location = new System.Drawing.Point(88, 190);
            this.btnAceptarCategoria.Name = "btnAceptarCategoria";
            this.btnAceptarCategoria.Size = new System.Drawing.Size(98, 48);
            this.btnAceptarCategoria.TabIndex = 2;
            this.btnAceptarCategoria.Text = "Aceptar";
            this.btnAceptarCategoria.UseVisualStyleBackColor = true;
            this.btnAceptarCategoria.Click += new System.EventHandler(this.btnAceptarCategoria_Click);
            // 
            // btnCancelarCategoria
            // 
            this.btnCancelarCategoria.Location = new System.Drawing.Point(214, 190);
            this.btnCancelarCategoria.Name = "btnCancelarCategoria";
            this.btnCancelarCategoria.Size = new System.Drawing.Size(98, 48);
            this.btnCancelarCategoria.TabIndex = 3;
            this.btnCancelarCategoria.Text = "Cancelar";
            this.btnCancelarCategoria.UseVisualStyleBackColor = true;
            this.btnCancelarCategoria.Click += new System.EventHandler(this.btnCancelarCategoria_Click);
            // 
            // frmAgregarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 311);
            this.Controls.Add(this.btnCancelarCategoria);
            this.Controls.Add(this.btnAceptarCategoria);
            this.Controls.Add(this.txtDescripcionCategoria);
            this.Controls.Add(this.label1);
            this.Name = "frmAgregarCategoria";
            this.Text = "frmAgregarCategoria";
            this.Load += new System.EventHandler(this.frmAgregarCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcionCategoria;
        private System.Windows.Forms.Button btnAceptarCategoria;
        private System.Windows.Forms.Button btnCancelarCategoria;
    }
}