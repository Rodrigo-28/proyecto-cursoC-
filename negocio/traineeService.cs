using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace negocio
{
    public class traineeService
    {
        public int insertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.seteraParametro("@email", nuevo.Email);
                datos.seteraParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScala();
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
        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, email, pass,admin,imagenPerfil,nombre,apellido,fechaNacimiento from USERS where email=@email and pass=@pass");
                datos.seteraParametro("@email", trainee.Email);
                datos.seteraParametro("@pass", trainee.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["nombre"] is DBNull))
                    {
                        trainee.Nombre = (string)datos.Lector["nombre"];

                    }
                    if (!(datos.Lector["nombre"] is DBNull))
                    {
                        trainee.Apellido = (string)datos.Lector["apellido"];

                    }

                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                    {
                        trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];

                    }
                    if(!(datos.Lector["fechaNacimiento"] is DBNull))
                    {
                        trainee.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());
                    }
                    return true;
                }
                return false;
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

        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update USERS set imagenPerfil = @imagen,apellido=@apellido,nombre=@nombre,fechaNacimiento=@fechaNacimiento where Id=@id");
                datos.seteraParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : "");
                datos.seteraParametro("@apellido", user.Apellido);
                datos.seteraParametro("@fechaNacimiento", user.FechaNacimiento);
                datos.seteraParametro("@nombre", user.Nombre);

                datos.seteraParametro("@id", user.Id);
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
    }
}
