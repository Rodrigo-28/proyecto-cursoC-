using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto_curso
{
    public partial class MenuLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPagina1_Click(object sender, EventArgs e)
        {
            Response.Redirect("pagina1Login.aspx");
        }

        protected void btnpagina2_Click(object sender, EventArgs e)
        {
            Response.Redirect("pagina2LoginAdmin.aspx");
        }
    }
}