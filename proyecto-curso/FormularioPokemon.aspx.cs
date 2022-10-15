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
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //configuracion inicial de la pantalla
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();
                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }
                //configuracion si estamos modificando.. voy a la basade de dato
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id != "" && !IsPostBack)
                {
                    PokemonService service = new PokemonService();
                    // List<Pokemon> lista = service.listar(id);
                    //Pokemon seleccionado = lista[0];
                    Pokemon seleccionado = (service.listar(id))[0];
                    //guardo obj seleccionado  en la session
                    Session.Add("pokeSeleccionado", seleccionado);
                    //pre cargar todos los campos..
                    txtId.Text = id;
                    TxtNombre.Text = seleccionado.Nombre;
                    TxtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.urlImagen;
                    TxtNumero.Text = seleccionado.Numero.ToString();

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    //configuraciones acciones
                    if (!seleccionado.Activo)
                    {
                        btnInactivar.Text = "Reactivar";
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion pantalla error
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonService service = new PokemonService();
                nuevo.Numero = int.Parse(TxtNumero.Text);
                nuevo.Nombre = TxtNombre.Text;
                nuevo.Descripcion = TxtDescripcion.Text;
                nuevo.urlImagen = txtImagenUrl.Text;

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);
                    
                if(Request.QueryString["id"] != null)
                {
                    // le tengo q mandar el id con el nuevo obj
                    nuevo.Id = int.Parse(txtId.Text);
                    service.modificarSp(nuevo);
                }
                else
                {
                service.agregarConSp(nuevo);

                }

                Response.Redirect("PokemonLista.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    //prueba
                    //falta armar el strore Procedures
                    PokemonService service = new PokemonService();
                    service.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("PokemonLista.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonService service = new PokemonService();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];
                // si no niego la condiccion de (seleccionado.activo) le voy a mandar el mismo estado del obj
                // negando le mando el estatado opuesto al q trae
                service.eliminarLogico(seleccionado.Id, !(seleccionado.Activo));
                Response.Redirect("PokemonLista.aspx");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}