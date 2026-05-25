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
    public partial class Form1 : Form {

        private List<Articulo> listaArticulos;
        private int indiceImagen = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();

            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
            cboCampo.Items.Add("Precio");
            cboCampo.SelectedIndex = 0;

        }

        private void cargar() {

            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listar();

                dgvArticulo.DataSource = null;
                dgvArticulo.DataSource = listaArticulos;

                ocultarColumnas();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void cargarImagen(string imagen) {

            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulo.Load("https://i0.wp.com/impactify.io/wp-content/uploads/2024/05/placeholder-1.png?ssl=1");
            }
        
        
        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                object seleccionado = dgvArticulo.CurrentRow.DataBoundItem;
                if (seleccionado is Articulo)
                {
                    Articulo art = (Articulo)seleccionado;
                    //cargarImagen(art.UrlImagen);

                    indiceImagen = 0;
                    mostrarImagen(art);
                }
                else
                {
                    pbxArticulo.Image = null;
                }
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaArticulo alta = new AltaArticulo();
            alta.ShowDialog();

            cargar();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (dgvArticulo.CurrentRow != null)
            {

                Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

                AltaArticulo modificar = new AltaArticulo(seleccionado);
                modificar.ShowDialog();

                cargar();

            }
            else {

                MessageBox.Show("Por favor, seleccione un articulo para modificar.");

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (dgvArticulo.CurrentRow != null) { 
                    
                    Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

                    DialogResult respuesta = MessageBox.Show(
                        $"¿De verdad querés eliminar el artículo {seleccionado.Nombre}?",
                        "Eliminando Artículo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {

                        negocio.eliminar(seleccionado.Id);
                        MessageBox.Show("Articulo Eliminado Exitosamente.");

                        cargar();

                    }

                    else {

                        MessageBox.Show("Seleccione un articulo para eliminar");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar:" + ex.Message);
            }


        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtroRapido = txtFiltroRapido.Text;

            if (filtroRapido.Length >= 3)
            {

                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtroRapido.ToUpper()) || x.Codigo.ToUpper().Contains(filtroRapido.ToUpper()));

            }
            else {

                listaFiltrada = listaArticulos;
            
            }

            dgvArticulo.DataSource = null;
            dgvArticulo.DataSource = listaFiltrada;
            ocultarColumnas();


        }

        private void ocultarColumnas() {

            if (dgvArticulo.Columns["UrlImagen"] != null)
                dgvArticulo.Columns["UrlImagen"].Visible = false;
            //if (dgvArticulo.Columns["Id"] != null)
              //  dgvArticulo.Columns["Id"].Visible = false;

        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            frmMarca marca = new frmMarca();
            marca.ShowDialog();

            cargar();


        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria categoria = new frmCategoria();
            categoria.ShowDialog();

            cargar();

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {

                Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                frmDetalleArticulo detalle = new frmDetalleArticulo(seleccionado);
                detalle.ShowDialog();

            }
            else {

                MessageBox.Show("Por favor, seleccione un artículo para ver su detalle.");
            }


        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            cboCriterio.Items.Clear();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            cboCriterio.SelectedIndex = 0;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text.Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    MessageBox.Show("Por favor, ingrese un texto o número para filtrar.");
                    return;
                }

                if (campo == "Precio")
                {
                    if (!decimal.TryParse(filtro, out decimal precio))
                    {
                        MessageBox.Show("Para filtrar por Precio, debe ingresar solo números.");
                        return;
                    }
                }

                List<Articulo> listaFiltrada = negocio.filtrar(campo, criterio, filtro);

                dgvArticulo.DataSource = null;
                dgvArticulo.DataSource = listaFiltrada;

                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroAvanzado.Clear();
            cargar();
        }


        private void mostrarImagen(Articulo art)
        {
            if (art.Imagenes != null && art.Imagenes.Count > 0)
            {
                
                cargarImagen(art.Imagenes[indiceImagen]);
            }
            else
            {
                
                pbxArticulo.Image = null;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                Articulo art = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

                if (art.Imagenes != null && art.Imagenes.Count > 0)
                {
                    indiceImagen++;

                    if (indiceImagen >= art.Imagenes.Count)
                    {
                        indiceImagen = 0;
                    }

                    mostrarImagen(art);
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                Articulo art = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

                if (art.Imagenes != null && art.Imagenes.Count > 0)
                {
                    indiceImagen--;

                    if (indiceImagen < 0)
                    {
                        indiceImagen = art.Imagenes.Count - 1;
                    }

                    mostrarImagen(art);
                }
            }
        }
    }
}
