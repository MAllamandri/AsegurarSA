using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using  System.Web.Http.Routing;

namespace AsegurarSA.WebUI.Controllers
{
    public class LlamadaController : ApiController
    {
        public int Get(int alarmaId)
        {
            //"543492521512", "@sms.movistar.net.ar"
            //@alertas.personal.com.ar    @sms.ctimovil.com.ar
            MailMessage message = new MailMessage("asegurarsa.metodos@gmail.com", "543404538247@alertas.personal.com.ar", "Alarma activada", "Su alarma esta sonando");
            SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");
            NetworkCredential nc = new NetworkCredential("asegurarsa.metodos@gmail.com", "metodosagiles");
            mySmtpClient.Credentials = nc;
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(message);
            return alarmaId;

        }
    }
}

