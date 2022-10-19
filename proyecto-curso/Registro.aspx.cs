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
                user.Email = txtEmail.Text;
                user.Pass = TxtPassword.Text;
                int id = traineeNuevo.insertarNuevo(user);



            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }
    }
}