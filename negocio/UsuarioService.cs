using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using acceso_datos;
namespace negocio
{
     public class UsuarioService
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos2 datos = new AccesoDatos2();
            try
            {
                datos.setearQuery("select id, TipoUser from USUARIO where usuario=@user AND pass=@pass");
                datos.agregarParametro("@user", usuario.User);
                datos.agregarParametro("@pass", usuario.Pass);
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuarios = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuarios.ADMIN : TipoUsuarios.NORMAL;
                    return true;
                }
                return false;

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

    }
}
