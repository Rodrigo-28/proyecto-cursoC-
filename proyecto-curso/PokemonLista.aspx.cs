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
    }
}