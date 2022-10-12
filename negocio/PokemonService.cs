using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace negocio
{
    public class PokemonService
    {
        public List<Pokemon> listar(string id="")
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Numero,Nombre,P.Descripcion, UrlImagen,E.Descripcion AS TIPO,D.Descripcion AS DEBILIDAD,P.IdTipo,P.IdDebilidad, P.Id from POKEMONS P,ELEMENTOS E,ELEMENTOS D WHERE E.ID =P.IdTipo AND D.Id = P.IdDebilidad And p.activo=1 ";
                if (id != "")
                {
                    comando.CommandText += " and P.Id = " + id;
                };
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();



                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["descripcion"];

                    if (!(lector["UrlImagen"] is DBNull))
                        aux.urlImagen = (string)lector["UrlImagen"];


                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["TIPO"].ToString();
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["DEBILIDAD"].ToString();

                    lista.Add(aux);


                }


                conexion.Close();

                return lista;
            }
            catch (Exception e)
            {

                throw e;
            }


        }


        public List<Pokemon> listarConSp()
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // string consulta = "select Numero,Nombre,P.Descripcion, UrlImagen,E.Descripcion AS TIPO,D.Descripcion AS DEBILIDAD,P.IdTipo,P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E,ELEMENTOS D WHERE E.ID = P.IdTipo AND D.Id = P.IdDebilidad And p.activo = 1";



                //datos.setearConsulta(consulta);
                datos.setearProcedimiento("storeListar");

                datos.ejecutarLectura();
                while (datos.Lector.Read())

                {
                    Pokemon aux = new Pokemon();


                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];


                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.urlImagen = (string)datos.Lector["UrlImagen"];



                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["TIPO"].ToString();
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["DEBILIDAD"].ToString();

                    lista.Add(aux);


                }



                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"insert into POKEMONS(Numero,Nombre,Descripcion,Activo,IdTipo,IdDebilidad,UrlImagen) values({nuevo.Numero},'{nuevo.Nombre}','{nuevo.Descripcion}',1,@IdTipo,@IdDebilidad,@UrlImagen)");
                datos.seteraParametro("@IdTipo", nuevo.Tipo.Id);
                datos.seteraParametro("@IdDebilidad", nuevo.Debilidad.Id);
                datos.seteraParametro("@UrlImagen", nuevo.urlImagen);
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
        public void agregarConSp(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
          
            try
            {
                datos.setearProcedimiento("storeAltaPokemon");
                datos.seteraParametro("@numero", nuevo.Numero);
                datos.seteraParametro("@nombre", nuevo.Nombre);
                datos.seteraParametro("@desc", nuevo.Descripcion);

                datos.seteraParametro("@img", nuevo.urlImagen);
                datos.seteraParametro("@idTipo", nuevo.Tipo.Id);
                datos.seteraParametro("@idDebilidad", nuevo.Debilidad.Id);

                //datos.seteraParametro("@idEvolucion", null);
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

        public void modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero=@numero, Nombre=@nombre, Descripcion=@descripcion, UrlImagen=@urlImagen, IdTipo=@idTipo, IdDebilidad=@idDebilidad where  Id=@Id");
                datos.seteraParametro("@numero", poke.Numero);
                datos.seteraParametro("@nombre", poke.Nombre);
                datos.seteraParametro("@descripcion", poke.Descripcion);
                datos.seteraParametro("@urlImagen", poke.urlImagen);
                datos.seteraParametro("@idTipo", poke.Tipo.Id);
                datos.seteraParametro("@idDebilidad", poke.Debilidad.Id);
                datos.seteraParametro("@Id", poke.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from POKEMONS where id=@id");
                datos.seteraParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Activo=0 where id=@id");
                datos.seteraParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Numero,Nombre,P.Descripcion, UrlImagen,E.Descripcion AS TIPO,D.Descripcion AS DEBILIDAD,P.IdTipo,P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E,ELEMENTOS D WHERE E.ID = P.IdTipo AND D.Id = P.IdDebilidad And p.activo = 1 And ";

                if (campo == "Numero")
                {
                    if (filtro == "")
                    {
                        return lista;
                    }

                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;

                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += $"Nombre like '{filtro}%'";
                            break;
                        case "Termina con":
                            consulta += $"Nombre like '%{filtro}'";
                            break;

                        default:
                            consulta += $"Nombre like '%{filtro}%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += $"P.descripcion like '{filtro}%'";
                            break;
                        case "Termina con":
                            consulta += $"P.descripcion like '%{filtro}'";
                            break;

                        default:
                            consulta += $"P.descripcion like '%{filtro}%'";
                            break;
                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())

                {
                    Pokemon aux = new Pokemon();


                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];


                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.urlImagen = (string)datos.Lector["UrlImagen"];



                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["TIPO"].ToString();
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["DEBILIDAD"].ToString();

                    lista.Add(aux);


                }



                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

    }

}

