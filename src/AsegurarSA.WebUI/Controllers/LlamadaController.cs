using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using  System.Web.Http.Routing;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;
using AsegurarSA.Domain.Entities;
using Microsoft.Ajax.Utilities;

namespace AsegurarSA.WebUI.Controllers
{
    public class LlamadaController : ApiController
    {
        public string Get(int alarmaId)
        {
            var repository = new EFClienteRepository();
            var context = new EFAlarmaRepositry();
            var eventoRepository = new EFEventoRepository();
            if (alarmaId != 0)
            {
                Alarma alarma = context.BuscarAlarma(alarmaId);
                Cliente cliente = repository.ObtenerCliente(alarma.ClienteId);
                Evento evento = new Evento();
                evento.ClienteId = cliente.ClienteId;
                evento.Fecha = DateTime.Now;
                evento.Descripcion = "Su alarma de la direccion: " + alarma.Direccion + " esta sonando, por favor verifique";
                string carrier = "";
                switch (cliente.EmpresaId)
                {
                    case 1:
                        carrier = "@sms.ctimovil.com.ar";
                        break;
                    case 2:
                        carrier = "@alertas.personal.com.ar";
                        break;
                    case 3:
                        carrier = "@sms.movistar.net.ar";
                        break;
                }
                eventoRepository.SaveEvento(evento);
                MailMessage message = new MailMessage("asegurarsa.metodos@gmail.com", cliente.Telefono1+carrier, "Alarma activada", evento.Descripcion);
                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");
                NetworkCredential nc = new NetworkCredential("asegurarsa.metodos@gmail.com", "metodosagiles");
                mySmtpClient.Credentials = nc;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(message);
                return "El mensaje ha sido enviando con exito";
            }
            return "Mensaje no enviando, consulte su proveedor de servicios";
        }
    }
}

