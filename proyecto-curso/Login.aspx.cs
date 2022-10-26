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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            traineeService service = new traineeService();
            try
            {
                trainee.Email = txtEmail.Text;
                trainee.Pass = TxtPassword.Text;
               // service.Login(trainee);
                if (service.Login(trainee)){
                    Session.Add("trainee", trainee);
                    Response.Redirect("miPerfil.aspx",false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("Error.aspx");


                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }
    }
}