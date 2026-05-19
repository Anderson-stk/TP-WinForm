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


        private void Form1_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();

            dgvArticulo.DataSource = listaArticulos;
            listaImagenes = negocio.getImagenes(listaArticulos[0].Id);
            cargarImagen(listaImagenes[0].ImagenUrl);


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



        }
    }
}
