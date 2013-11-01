using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
    public class ReportesController : Controller
    {
        //
        // GET: /Reportes/
         private IClienteRepository _repository;

         public ReportesController(IClienteRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult ClientesPerdidos()
        {
            IEnumerable<Cliente> ListaPerdidos = _repository.ObtenerClientesPerdidos();
            return View(ListaPerdidos);
        }

    }
}
