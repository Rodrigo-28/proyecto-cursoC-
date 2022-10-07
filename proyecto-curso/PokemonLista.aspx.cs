using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace proyecto_curso
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonService servicie = new PokemonService();
            dgvpokemon.DataSource = servicie.listarConSp();
            dgvpokemon.DataBind();
        }

        protected void dgvpokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvpokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);

        }

    

        protected void dgvpokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvpokemon.PageIndex = e.NewPageIndex;
            dgvpokemon.DataBind();

        }
    }
}