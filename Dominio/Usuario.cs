using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
        public enum TipoUsuarios
        {
            NORMAL=1,
            ADMIN=2
        }
     public class Usuario
    {
        public Usuario (string user,string pass, bool admin)
        {
            this.User = user;
            this.Pass = pass;
            this.TipoUsuarios = admin ? TipoUsuarios.ADMIN : TipoUsuarios.NORMAL;
        }
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public TipoUsuarios TipoUsuarios { get; set; }
    }
}
