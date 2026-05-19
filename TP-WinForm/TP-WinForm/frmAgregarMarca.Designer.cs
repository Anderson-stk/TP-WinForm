namespace TP_WinForm {
    partial class frmAgregarMarca {
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
            this.txtDescripcionMarca = new System.Windows.Forms.TextBox();
            this.btnAceptarMarca = new System.Windows.Forms.Button();
            this.btnCancelarMarca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion:";
            // 
            // txtDescripcionMarca
            // 
            this.txtDescripcionMarca.Location = new System.Drawing.Point(128, 137);
            this.txtDescripcionMarca.Name = "txtDescripcionMarca";
            this.txtDescripcionMarca.Size = new System.Drawing.Size(142, 20);
            this.txtDescripcionMarca.TabIndex = 1;
            // 
            // btnAceptarMarca
            // 
            this.btnAceptarMarca.Location = new System.Drawing.Point(59, 204);
            this.btnAceptarMarca.Name = "btnAceptarMarca";
            this.btnAceptarMarca.Size = new System.Drawing.Size(96, 40);
            this.btnAceptarMarca.TabIndex = 2;
            this.btnAceptarMarca.Text = "Aceptar";
            this.btnAceptarMarca.UseVisualStyleBackColor = true;
            this.btnAceptarMarca.Click += new System.EventHandler(this.btnAceptarMarca_Click);
            // 
            // btnCancelarMarca
            // 
            this.btnCancelarMarca.Location = new System.Drawing.Point(174, 204);
            this.btnCancelarMarca.Name = "btnCancelarMarca";
            this.btnCancelarMarca.Size = new System.Drawing.Size(96, 40);
            this.btnCancelarMarca.TabIndex = 3;
            this.btnCancelarMarca.Text = "Cancelar";
            this.btnCancelarMarca.UseVisualStyleBackColor = true;
            this.btnCancelarMarca.Click += new System.EventHandler(this.btnCancelarMarca_Click);
            // 
            // frmAgregarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 362);
            this.Controls.Add(this.btnCancelarMarca);
            this.Controls.Add(this.btnAceptarMarca);
            this.Controls.Add(this.txtDescripcionMarca);
            this.Controls.Add(this.label1);
            this.Name = "frmAgregarMarca";
            this.Text = "frmAgregarMarca";
            this.Load += new System.EventHandler(this.frmAgregarMarca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcionMarca;
        private System.Windows.Forms.Button btnAceptarMarca;
        private System.Windows.Forms.Button btnCancelarMarca;
    }
}