using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
    [Authorize    ]
    public class EmpleadosController : Controller
    {
        // GET: /Empleados/
        private IEmpleadoRepository _repository;
        public EmpleadosController(IEmpleadoRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult List()
        {
            return View(_repository.Empleados);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveEmpleado(empleado);
                return RedirectToAction("List");
            }
            return View(empleado);
        }
    }
}
