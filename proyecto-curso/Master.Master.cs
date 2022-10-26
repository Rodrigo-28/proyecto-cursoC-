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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // esto me va validar todas las pantallas..tego q exceptuar las pantalla q no quiero q me valide

            imgAvatar.ImageUrl = "https://image.shutterstock.com/image-vector/user-icon-trendy-flat-style-260nw-418179865.jpg";

            if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
            {
                if (!Seguridad.sessionActiva(Session["trainee"]))
                {
                    Response.Redirect("Login.aspx", false);

                }
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {

                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }

                }

            }




        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}