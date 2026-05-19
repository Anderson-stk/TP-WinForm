using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm {
    public partial class frmAgregarArticulo : Form {

        private Articulo articulo = null;
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                List<Marca> listaMarcas = marcaNegocio.listar();
                List<Marca> marcasUnicas = new List<Marca>();

                foreach (Marca marca in listaMarcas)
                {
                    if (!marcasUnicas.Any(m=> m.Id == marca.Id)) { 
                        
                        marcasUnicas.Add(marca);
                    }
                }

                cboMarcas.DataSource = marcasUnicas;
                cboMarcas.ValueMember = "Id";
                cboMarcas.DisplayMember = "Descripcion";



                List<Categoria> listaCategorias = categoriaNegocio.listar();
                List<Categoria> categoriaUnicas = new List<Categoria>();

                foreach (Categoria categoria in listaCategorias)
                {
                    if (!categoriaUnicas.Any(c => c.Id == categoria.Id))
                    {
                        categoriaUnicas.Add(categoria);
                    }
                }

                cboCategoria.DataSource = categoriaUnicas;
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null && articulo.Id != 0) {

                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    if(articulo.Marca != null)
                        cboMarcas.SelectedValue = articulo.Marca.Id;
                    if(articulo.Categoria != null)
                        cboCategoria.SelectedValue = articulo.Categoria.Id;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnAceptarArticulo_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();

            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) {
                MessageBox.Show("El codigo es Obligatorio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es Obligatorio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La Descripcion es Obligatoria");
                return;
            }

            if(cboMarcas.SelectedItem == null) {
                MessageBox.Show("Debe seleccionar una marca");
                return;
            }

            if (cboCategoria.SelectedItem == null){
                MessageBox.Show("Debe seleccionar una categoria");
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0) {
                MessageBox.Show("El precio tiene que ser un numero positivo");
                return;
            }

            string url = txtUrlImagen.Text.Trim();
            if (!string.IsNullOrEmpty(url) && !(url.StartsWith("http://") || url.StartsWith("https://")))
            {
                MessageBox.Show("La URL de la imagen debe comenzar con http:// o https://");
                return;
            }


            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = precio;

                articulo.Marca = (Marca)cboMarcas.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;


                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }

                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                Close();
            }


        }

        private void btnCancelarArticulo_Click(object sender, EventArgs e)
        {
            Close();
        }


        public frmAgregarArticulo(Articulo existente) : this()
        {
            articulo = existente;
            Text = "Modificar Artículo";
        }
    }
}
