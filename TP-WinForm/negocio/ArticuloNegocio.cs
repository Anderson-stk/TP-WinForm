using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio {
    public class ArticuloNegocio {

        public List<Articulo> listar() {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdCategoria, C.Descripcion AS Categoria, A.IdMarca, M.Descripcion AS Marca,(SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS UrlImagen FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id ORDER BY A.Id");
                //datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdCategoria, C.Descripcion AS Categoria, A.IdMarca, M.Descripcion AS Marca FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id ORDER BY A.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) {

                    Articulo aux = new Articulo();
                    
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio"))))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Imagenes = obtenerImagenes(aux.Id);

                    if (aux.Imagenes.Count > 0)
                        aux.UrlImagen = aux.Imagenes[0];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }


        public void agregar(Articulo nuevo) {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @idMarca, @idCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();

                datos.cerrarConexion();



                datos = new AccesoDatos();
                datos.setearConsulta("SELECT TOP 1 Id FROM ARTICULOS ORDER BY Id DESC");
                datos.ejecutarLectura();

                int idArticulo = -1;

                if (datos.Lector.Read()) {

                    idArticulo = (int)datos.Lector["Id"];
                
                }

                datos.cerrarConexion();

                if (idArticulo != -1 && !string.IsNullOrEmpty(nuevo.UrlImagen)) {
                    
                    datos = new AccesoDatos();
                    datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)");
                    datos.setearParametro("@idArticulo", idArticulo);
                    datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                    datos.ejecutarAccion();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }

        
        }


        public void modificar(Articulo art) {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id");
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@id", art.Id);

                datos.ejecutarAccion();
                datos.cerrarConexion();


                datos = new AccesoDatos();
                datos.setearConsulta("IF EXISTS (SELECT * FROM IMAGENES WHERE IdArticulo = @idArticulo) " +
                             "UPDATE IMAGENES SET ImagenUrl = @imagenUrl WHERE IdArticulo = @idArticulo " +
                             "ELSE " +
                             "INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)");

                datos.setearParametro("@idArticulo", art.Id);
                datos.setearParametro("@imagenUrl", art.UrlImagen ?? (object)DBNull.Value);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        
        
        }


        public void eliminar(int id) {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @id; DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        
        }


        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.IdCategoria, C.Descripcion AS Categoria, A.IdMarca, M.Descripcion AS Marca, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS UrlImagen FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id WHERE ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > @filtro";
                            break;
                        case "Menor a":
                            consulta += "A.Precio < @filtro";
                            break;
                        default:
                            consulta += "A.Precio = @filtro";
                            break;
                    }
                    datos.setearParametro("@filtro", decimal.Parse(filtro));
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre LIKE @filtro";
                            datos.setearParametro("@filtro", filtro + "%");
                            break;
                        case "Termina con":
                            consulta += "A.Nombre LIKE @filtro";
                            datos.setearParametro("@filtro", "%" + filtro);
                            break;
                        default:
                            consulta += "A.Nombre LIKE @filtro";
                            datos.setearParametro("@filtro", "%" + filtro + "%");
                            break;
                    }
                }

                else
                {
                    string columna = (campo == "Marca") ? "M.Descripcion" : "C.Descripcion";
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += columna + " LIKE @filtro";
                            datos.setearParametro("@filtro", filtro + "%");
                            break;
                        case "Termina con":
                            consulta += columna + " LIKE @filtro";
                            datos.setearParametro("@filtro", "%" + filtro);
                            break;
                        default: 
                            consulta += columna + " LIKE @filtro";
                            datos.setearParametro("@filtro", "%" + filtro + "%");
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Precio"))))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


  
        private List<string> obtenerImagenes(int idArticulo)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo");
                datos.setearParametro("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add((string)datos.Lector["ImagenUrl"]);
                }

                return lista;
            }
            catch (Exception)
            {
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
