using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace proyecto_curso
{
    public partial class EnviosEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmailService service = new EmailService();
            service.armarCorreo(txtEmail.Text, TxtAsunto.Text, TxtMensaje.Text);
            try
            {
                service.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                
            }
        }
    }
}