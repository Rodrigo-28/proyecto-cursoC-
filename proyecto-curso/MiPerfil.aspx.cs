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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // pregunto si no hay una session activa..
            // este metodo lo uso una sola vez en al master page..
            //if (!Seguridad.sessionActiva(Session["trainee"]))
            //{
            //    Response.Redirect("Login.aspx", false);
            //}
            try
            {
            if (!IsPostBack)
            {
                if (Seguridad.sessionActiva(Session["trainee"]))
                {
                    Trainee user = (Trainee)Session["trainee"];
                    txtEmail.Text = user.Email;
                    txtEmail.ReadOnly = true;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }
            }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                traineeService service = new traineeService();
                //escribir img
                Trainee user = (Trainee)Session["trainee"];
                //escribir img si se cargo algo
                if (txtImage.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImage.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                service.actualizar(user);


                // para buscar controles en la Masterpage
                Image img = (Image)Master.FindControl("imgAvatar");
                //leer img
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());

            }
        }
    }
}