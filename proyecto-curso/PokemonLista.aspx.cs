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
    public partial class PokemonLista : System.Web.UI.Page

    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "se requiere permisos de admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx", false);
            }
            FiltroAvanzado = chkAvanzado.Checked;

            if (!IsPostBack)
            {
                PokemonService servicie = new PokemonService();
                Session.Add("listaPokemon", servicie.listarConSp());
                dgvpokemon.DataSource = Session["listaPokemon"];
                dgvpokemon.DataBind();

            }
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

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemon"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(Txtfiltro.Text.ToUpper()));
            dgvpokemon.DataSource = listaFiltrada;
            dgvpokemon.DataBind();

        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            Txtfiltro.Enabled = !FiltroAvanzado;

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Numero")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");

            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                PokemonService service = new PokemonService();
                dgvpokemon.DataSource = service.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString()
                    );
                dgvpokemon.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            PokemonService service = new PokemonService();
            dgvpokemon.DataSource = service.listarConSp();
            dgvpokemon.DataBind();
            chkAvanzado.Checked = !chkAvanzado.Checked;
            FiltroAvanzado = chkAvanzado.Checked;





        }
    }
}