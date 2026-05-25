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
    public partial class frmMarca : Form {

        private List<Marca> listaMarcas;
        private MarcaNegocio negocio = new MarcaNegocio();
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar() {

            try
            {
                listaMarcas = negocio.listar();
                dgvMarca.DataSource = null;
                dgvMarca.DataSource = listaMarcas;

                if (dgvMarca.Columns["Id"] != null)
                    dgvMarca.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarca.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarca.CurrentRow.DataBoundItem;
                txtDescripcion.Text = seleccionada.Descripcion;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(desc)) {

                MessageBox.Show("Por favor, ingrese una descripción.");
                return;
            }

            try
            {
                negocio.agregar(desc);
                MessageBox.Show("Marca agregada Exitosamente");
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
            if (dgvMarca.CurrentRow == null) return;
            string desc = txtDescripcion.Text.Trim();
            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("Por favor, ingrese una descripción válida.");
                return;
            }
            try
            {
                Marca seleccionada = (Marca)dgvMarca.CurrentRow.DataBoundItem;
                seleccionada.Descripcion = desc;
                negocio.modificar(seleccionada);
                MessageBox.Show("Marca modificada exitosamente.");
                cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarca.CurrentRow == null) return;
            try
            {
                Marca seleccionada = (Marca)dgvMarca.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show($"¿De verdad desea eliminar la marca '{seleccionada.Descripcion}'?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    negocio.eliminar(seleccionada.Id);
                    MessageBox.Show("Marca eliminada exitosamente.");
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar la marca porque tiene artículos asociados en el catálogo.");
            }


        }
    }
}
