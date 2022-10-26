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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                traineeService traineeNuevo = new traineeService();
                EmailService emailService = new EmailService();
                user.Email = txtEmail.Text;
                user.Pass = TxtPassword.Text;
                user.Id = traineeNuevo.insertarNuevo(user);
                Session.Add("trainee", user);
                emailService.armarCorreo(txtEmail.Text, "bienvenida trainee", "hola te damos la bienvenida a la app");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }
    }
}