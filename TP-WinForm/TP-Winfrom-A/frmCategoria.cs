using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TP_Winfrom_A {
    public partial class frmCategoria : Form {

        private List<Categoria> listaCategorias;
        private CategoriaNegocio negocio = new CategoriaNegocio();

        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }

        void cargar() {

            try
            {
                listaCategorias = negocio.listar();
                dgvCategoria.DataSource = null;
                dgvCategoria.DataSource = listaCategorias;

                if (dgvCategoria.Columns["Id"] != null)
                    dgvCategoria.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow != null)
            {
                Categoria seleccionada = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                txtDescripcion.Text = seleccionada.Descripcion;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("Por favor, ingrese una descripción.");
                return;
            }

            try
            {
                negocio.agregar(desc);
                MessageBox.Show("Categoria agregada exitosamente.");
                txtDescripcion.Clear();
                cargar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al agregar: " + ex.Message);
            }


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow == null) return;

            string desc = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("Por favor, ingrese una descripción válida.");
                return;
            }
            try
            {
                Categoria seleccionada = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                seleccionada.Descripcion = desc;

                negocio.modificar(seleccionada);
                MessageBox.Show("Categoría modificada exitosamente.");
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.CurrentRow == null) return;
            try
            {
                Categoria seleccionada = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show($"¿De verdad desea eliminar la categoría '{seleccionada.Descripcion}'?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (respuesta == DialogResult.Yes)
                {
                    negocio.eliminar(seleccionada.Id);
                    MessageBox.Show("Categoría eliminada exitosamente.");
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar la categoría porque tiene artículos asociados en el catálogo.");
            }


        }
    }
}
