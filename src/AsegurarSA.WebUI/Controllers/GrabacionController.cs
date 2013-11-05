using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
    public class GrabacionController : Controller
    {
        //
        // GET: /Grabacion/
        private IClienteRepository _repository = new EFClienteRepository();
        private IGrabacionesRepository _repository2 = new EFGrabacionesRepository();
        
        public ActionResult Upload()
        {
            IEnumerable<Cliente> clientes = _repository.Cliente;
            var listClientes = new SelectList(clientes, "ClienteId", "Nombre");
            ViewData["listClientes"] = listClientes;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(int cliente)
        {
            Grabacion grabacion = new Grabacion();
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                postedFile.SaveAs(Server.MapPath("~/Content/Grabaciones/") + Path.GetFileName(postedFile.FileName));

                grabacion.ClienteId = cliente;
                grabacion.PathGrabacion = postedFile.FileName;
                _repository2.SaveGrabaciones(grabacion);
            }

            return RedirectToAction("Upload");
        }

        public ActionResult Grabaciones(int clienteId)
        {
            IEnumerable<Grabacion> Grabaciones = _repository2.Grabaciones(clienteId);
            Cliente cliente = _repository.ObtenerCliente(clienteId);
            ViewData["cliente"] = cliente.Nombre + " " + cliente.Apellido;
            return View(Grabaciones);
        }

        public ActionResult Reproducir(string nombre)
        {
            ViewData["path"] = "/Content/Grabaciones/"+ nombre;
            return View();
        }
    }
}
