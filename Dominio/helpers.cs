using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public static class helpers
    {
        public static bool UsuarioIsAdmin2(object session)
        {
            if (session != null && ((Dominio.Usuario)session).TipoUsuarios == Dominio.TipoUsuarios.ADMIN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
