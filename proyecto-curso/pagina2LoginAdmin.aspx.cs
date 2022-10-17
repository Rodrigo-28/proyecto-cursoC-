using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace proyecto_curso
{
    public partial class pagina2LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!helpers.UsuarioIsAdmin2(Session["usuario"]))
            {
                Session.Add("Error", "no tienes permiso para ingresar a esta pantalla.necesitas nivel admin.");
                Response.Redirect("Error.aspx", false);
            }
            

        }
    }
}