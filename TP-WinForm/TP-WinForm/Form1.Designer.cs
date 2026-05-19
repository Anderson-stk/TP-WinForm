namespace TP_WinForm {
    partial class Form1 {
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
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnMenuMarcas = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Location = new System.Drawing.Point(24, 93);
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.Size = new System.Drawing.Size(754, 324);
            this.dgvArticulo.TabIndex = 0;
            this.dgvArticulo.SelectionChanged += new System.EventHandler(this.dgvArticulo_SelectionChanged);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(784, 93);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(333, 324);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 1;
            this.pbxArticulo.TabStop = false;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(21, 66);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(69, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Filtro Rapido:";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(96, 63);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(308, 20);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(848, 423);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(81, 38);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(994, 423);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(80, 38);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(24, 423);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 38);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(182, 423);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(119, 38);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(338, 423);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 38);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Campo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Criterio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtro";
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(370, 486);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(140, 20);
            this.txtFiltroAvanzado.TabIndex = 12;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(542, 474);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(93, 43);
            this.btnFiltro.TabIndex = 13;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(477, 45);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(119, 38);
            this.btnCategorias.TabIndex = 14;
            this.btnCategorias.Text = "Menu Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnMenuMarcas
            // 
            this.btnMenuMarcas.Location = new System.Drawing.Point(638, 45);
            this.btnMenuMarcas.Name = "btnMenuMarcas";
            this.btnMenuMarcas.Size = new System.Drawing.Size(119, 38);
            this.btnMenuMarcas.TabIndex = 15;
            this.btnMenuMarcas.Text = "Menu Marcas";
            this.btnMenuMarcas.UseVisualStyleBackColor = true;
            this.btnMenuMarcas.Click += new System.EventHandler(this.btnMenuMarcas_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.Location = new System.Drawing.Point(659, 423);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(119, 38);
            this.btnDetalles.TabIndex = 16;
            this.btnDetalles.Text = "Ver Detalles";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(659, 479);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 38);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cboCampo
            // 
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(67, 485);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(96, 21);
            this.cboCampo.TabIndex = 18;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(214, 485);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(96, 21);
            this.cboCriterio.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 533);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnMenuMarcas);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.dgvArticulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Label label;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnMenuMarcas;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
    }
}

