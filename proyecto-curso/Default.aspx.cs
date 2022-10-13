using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using Dominio;

namespace proyecto_curso
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        public Pokemon pokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonService servicio = new PokemonService();
            ListaPokemon = servicio.listarConSp();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaPokemon;
                repRepetidor.DataBind();

            }
            if(Session["listaPokemon"] == null)
            {
                PokemonService aux = new PokemonService();
                Session.Add("listaPokemon", aux.listarConSp());
            }

        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            int valor = int.Parse(((Button)sender).CommandArgument);
            List<Pokemon> aux = new List<Pokemon>();

        }
    }
}