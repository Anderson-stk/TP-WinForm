namespace TP_WinForm {
    partial class frmMarcas {
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
            this.btnModificarMarcas = new System.Windows.Forms.Button();
            this.btnEliminarMarcas = new System.Windows.Forms.Button();
            this.btnAgregarMarcas = new System.Windows.Forms.Button();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificarMarcas
            // 
            this.btnModificarMarcas.Location = new System.Drawing.Point(168, 354);
            this.btnModificarMarcas.Name = "btnModificarMarcas";
            this.btnModificarMarcas.Size = new System.Drawing.Size(79, 31);
            this.btnModificarMarcas.TabIndex = 7;
            this.btnModificarMarcas.Text = "Modificar";
            this.btnModificarMarcas.UseVisualStyleBackColor = true;
            this.btnModificarMarcas.Click += new System.EventHandler(this.btnModificarMarcas_Click);
            // 
            // btnEliminarMarcas
            // 
            this.btnEliminarMarcas.Location = new System.Drawing.Point(277, 354);
            this.btnEliminarMarcas.Name = "btnEliminarMarcas";
            this.btnEliminarMarcas.Size = new System.Drawing.Size(79, 31);
            this.btnEliminarMarcas.TabIndex = 6;
            this.btnEliminarMarcas.Text = "Eliminar";
            this.btnEliminarMarcas.UseVisualStyleBackColor = true;
            this.btnEliminarMarcas.Click += new System.EventHandler(this.btnEliminarMarcas_Click);
            // 
            // btnAgregarMarcas
            // 
            this.btnAgregarMarcas.Location = new System.Drawing.Point(48, 354);
            this.btnAgregarMarcas.Name = "btnAgregarMarcas";
            this.btnAgregarMarcas.Size = new System.Drawing.Size(79, 31);
            this.btnAgregarMarcas.TabIndex = 5;
            this.btnAgregarMarcas.Text = "Agregar";
            this.btnAgregarMarcas.UseVisualStyleBackColor = true;
            this.btnAgregarMarcas.Click += new System.EventHandler(this.btnAgregarMarcas_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(48, 46);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.Size = new System.Drawing.Size(308, 249);
            this.dgvMarcas.TabIndex = 4;
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.btnModificarMarcas);
            this.Controls.Add(this.btnEliminarMarcas);
            this.Controls.Add(this.btnAgregarMarcas);
            this.Controls.Add(this.dgvMarcas);
            this.Name = "frmMarcas";
            this.Text = "frmMarcas";
            this.Load += new System.EventHandler(this.frmMarcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificarMarcas;
        private System.Windows.Forms.Button btnEliminarMarcas;
        private System.Windows.Forms.Button btnAgregarMarcas;
        private System.Windows.Forms.DataGridView dgvMarcas;
    }
}