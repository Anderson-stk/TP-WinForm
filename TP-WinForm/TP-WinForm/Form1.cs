using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm {
    public partial class Form1 : Form {

        private List<Articulo> listaArticulos;
        private List<Imagen> listaImagenes;
        private int indiceActual =0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ocultarColumnas()
        {
            dgvArticulo.Columns["Id"].Visible = true;
            dgvArticulo.Columns["UrlImagen"].Visible = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            cargar();

            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Codigo");

            /* ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();

            dgvArticulo.DataSource = listaArticulos;
            listaImagenes = negocio.getImagenes(listaArticulos[0].Id);
            cargarImagen(listaImagenes[0].ImagenUrl);
           */

        }

        private void cargar()
        {
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

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
            listaImagenes = negocio.getImagenes(seleccionado.Id);
            cargarImagen(listaImagenes[0].ImagenUrl);



        }


        private void cargarImagen(string imagen) {

            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulo.Load("https://media.istockphoto.com/id/1147544807/es/vector/no-imagen-en-miniatura-gr%C3%A1fico-vectorial.jpg?s=612x612&w=0&k=20&c=Bb7KlSXJXh3oSDlyFjIaCiB9llfXsgS7mHFZs6qUgVk=");
            }
        
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            indiceActual++;
            if (listaImagenes.Count == 0) return;


            if (indiceActual >= listaImagenes.Count) { 
                indiceActual = 0;

            }

            cargarImagen(listaImagenes[indiceActual].ImagenUrl);


        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

            if (listaImagenes.Count == 0) return;
            
            indiceActual--;
            if (indiceActual < 0)
            {
                indiceActual = listaImagenes.Count - 1;
            }

            cargarImagen(listaImagenes[indiceActual].ImagenUrl);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo alta = new frmAgregarArticulo();
            alta.ShowDialog();
            cargar();

        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;

            if (dgvArticulo.CurrentRow != null)
            {

                seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;
                frmAgregarArticulo modificar = new frmAgregarArticulo(seleccionado);
                modificar.ShowDialog();

                cargar();
            }
            else
            {

                MessageBox.Show("Por favor, seleccione un artículo para modificar.");
            }



        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias agregar = new frmCategorias();
            agregar.ShowDialog();
            cargar();
        }

        private void btnMenuMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas agregar = new frmMarcas();
            agregar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulo.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un artículo para eliminar.");
                    return;
                }

                Articulo seleccionado = (Articulo)dgvArticulo.CurrentRow.DataBoundItem;

                var resp = MessageBox.Show(
                    "¿Eliminar físicamente el artículo seleccionado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp == DialogResult.Yes)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarFisico(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un campo para filtrar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un criterio para filtrar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Por favor, introduce un número para filtrar");
                    return true;
                }
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo números para usar el filtro");
                    return true;
                }

            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvArticulo.DataSource = negocio.filtrar(campo, criterio, filtro);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Nombre")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Clear();
            cargar();
            ocultarColumnas();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 2)
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulo.DataSource = null;
            dgvArticulo.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void cboCampo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un artículo primero.");
                return;
            }
            Articulo seleccionado = dgvArticulo.CurrentRow.DataBoundItem as Articulo;

            if (seleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el artículo seleccionado.");
                return;
            }

            frmDetallesArticulos agregar = new frmDetallesArticulos(seleccionado, listaImagenes);
            agregar.ShowDialog(this);
            cargar();
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvArticulo.Rows[e.RowIndex];
                int idArticulo = Convert.ToInt32(fila.Cells["id"].Value);
                if (idArticulo != null)
                {
                    ArticuloNegocio artNegocio = new ArticuloNegocio();
                    listaImagenes = artNegocio.getImagenes(idArticulo);
                    indiceActual = 0;
                    mostrarImagenActual();

                }
            }
        }
        // mostrar imagen actual , borrar funcion.
        private void mostrarImagenActual()
        {
            if (listaImagenes != null && listaImagenes.Count > 0)
            {
                try
                {
                    pbxArticulo.Load(listaImagenes[indiceActual].ImagenUrl);
                }

                catch (Exception ex)
                {
                    pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                }
            }
            else
            {
                pbxArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
    }
}
