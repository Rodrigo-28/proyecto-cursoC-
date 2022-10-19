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
    }
}
