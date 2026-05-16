using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForm {
    public class CategoriaNegocio {
        public List<Categoria> listar() {

            var lista = new List<Categoria>();
            var datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) {

                    var aux = new Categoria
                    {
                        Id = (int)datos.Lector["Id"],
                        Descripcion = (string)datos.Lector["Descripcion"]
                    };
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error listando categorías.", ex);
            }
            finally
            { 
                datos.cerrarConexion();
            }
            
            

        
        }



    }
}
