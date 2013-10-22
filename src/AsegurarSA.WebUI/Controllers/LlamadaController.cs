using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace AsegurarSA.WebUI.Controllers
{
    public class LlamadaController : Controller
    {
        //
        // GET: /Llamada/

        public static void Llamada(string NumeroTelefono, string empresa)
        {
            MailMessage message = new MailMessage("asegurarsa.metodos@gmail.com", NumeroTelefono + empresa, "Alarma activada", "Su alarma esta sonando");
            SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");
            NetworkCredential nc = new NetworkCredential("asegurarsa.metodos@gmail.com", "metodosagiles");
            mySmtpClient.Credentials = nc;
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(message);
        }

    }
}
