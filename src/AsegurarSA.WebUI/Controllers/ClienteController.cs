using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/
        private IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            this._repository = repository;
        }


        public ActionResult List()
        {
            return View(_repository.Cliente);
        }

        public ActionResult Create(Cliente cliente = null)
        {
           return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente, int empresa = 3)
        {
           // var e = empresa == 3 ? "Movistar" : empresa == 2 ? "Personal" : empresa == 1 ? "Claro" : "Movistar";
            cliente.EmpresaId = empresa;
            if (ModelState.IsValid)
            {
                _repository.SaveCliente(cliente);
                return RedirectToAction("List");
            }
            return RedirectToAction("Create", cliente);
        }


        public ActionResult Delete(int clienteId=0)
        {
            var cliente = _repository.Cliente.FirstOrDefault(e => e.ClienteId == clienteId);
            _repository.DeleteCliente(cliente);
            return RedirectToAction("List");
        }

        public ActionResult Modificar(int clienteId = 0)
        {
            var cliente = _repository.Cliente.FirstOrDefault(e => e.ClienteId == clienteId);
            return RedirectToAction("Create", cliente);
        }
    }
}
