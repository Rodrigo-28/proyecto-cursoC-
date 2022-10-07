using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using negocio;

namespace proyecto_curso
{
    public partial class detallePokemon : System.Web.UI.Page
    {
        public Pokemon Seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Id"] != null)
            {
                int id =int.Parse(Request.QueryString["Id"].ToString());
                List<Pokemon> temporal = (List<Pokemon>)Session["listaPokemon"];
                 Seleccionado = temporal.Find(x => x.Id == id);
                

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}