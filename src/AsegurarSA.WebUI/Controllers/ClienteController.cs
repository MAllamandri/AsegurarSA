using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;
using AsegurarSA.Domain.Migrations;

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

    }
}
