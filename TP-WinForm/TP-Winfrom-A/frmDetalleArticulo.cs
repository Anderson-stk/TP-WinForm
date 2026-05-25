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
    public partial class frmDetalleArticulo : Form {

        private Articulo articulo;
        private int indiceImagen = 0;
        public frmDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Detalle del Articulo - " + articulo.Nombre;
        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString("C");
                txtMarca.Text = articulo.Marca.Descripcion;
                txtCategoria.Text = articulo.Categoria.Descripcion;

                indiceImagen = 0;
                cargarImagen(articulo.UrlImagen);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar detalles: " + ex.Message);
            }


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarImagen(string imagen) {

            try
            {
                pbxImagenDetalle.Load(imagen);
            }
            catch (Exception)
            {

                pbxImagenDetalle.Image = null;
            }


        }

        private void mostrarImagen()
        {
            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                cargarImagen(articulo.Imagenes[indiceImagen]);
            }
            else
            {
                pbxImagenDetalle.Image = null;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                indiceImagen++;

                if (indiceImagen >= articulo.Imagenes.Count)
                {
                    indiceImagen = 0;
                }

                mostrarImagen();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                indiceImagen--;

                if (indiceImagen < 0)
                {
                    indiceImagen = articulo.Imagenes.Count - 1;
                }

                mostrarImagen();
            }
        }
    }
}
