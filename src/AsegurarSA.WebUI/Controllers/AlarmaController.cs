using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;
using AsegurarSA.WebUI.Models;
using Newtonsoft.Json;

namespace AsegurarSA.WebUI.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AlarmaController : Controller
    {
        private IAlarmaRepository _repository;
        private IClienteRepository _clienterepository;

        public AlarmaController(IAlarmaRepository repository, IClienteRepository clienteRepository)
        {
            this._repository = repository;
            this._clienterepository = clienteRepository;
        }

        public ActionResult CrearAlarma(int clienteId=0)
        {
            var alarma = new Alarma()
            {
                ClienteId = clienteId,
                Cliente = _clienterepository.Cliente.FirstOrDefault(c => c.ClienteId == clienteId)
            };
            return View(alarma);
        }

        public ActionResult ListaAlarmaCliente(int clienteId)
        {
            var model = new AlarmaViewModel.AlarmaView()
            {
                listaAlarmas = _repository.ListaAlarmaCliente(clienteId),
                cliente = _clienterepository.Cliente.FirstOrDefault(c => c.ClienteId == clienteId)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveAlarma(Alarma alarma)
        {

            _repository.SaveAlarma(alarma);
            return RedirectToAction("ListaAlarmaCliente", "Alarma", new {clienteId = alarma.ClienteId});
        }

        public ActionResult DeleteAlarma(int AlarmaId=0)
        {
            Alarma alarma = _repository.BuscarAlarma(AlarmaId);
            _repository.DeleteAlarma(alarma);
            return RedirectToAction("ListaAlarmaCliente", "Alarma", new { clienteId = alarma.ClienteId });
        }

        public ActionResult GetAlamasCliente(int clienteId)
        {
            return Json(_repository.ListaAlarmaCliente(clienteId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetComisarias()
        {

            return Json(_repository.GetComisarias(), JsonRequestBehavior.AllowGet);
        }

    }
}
