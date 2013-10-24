using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
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
            var alarmas = _repository.ListaAlarmaCliente(clienteId);
            return View(alarmas);
        }
    }
}
