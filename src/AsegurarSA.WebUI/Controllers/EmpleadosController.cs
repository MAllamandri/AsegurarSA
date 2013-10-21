using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
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
       
        
        public ActionResult Create(Empleado empleado=null)
        {
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveEmpleado(empleado);
                return RedirectToAction("List");
            }
            return RedirectToAction("Create", empleado);
        }

        public ActionResult Modificar(int EmpleadoId=0)
        {
            Empleado empleado = _repository.Empleados.Where(e => e.EmpleadoId == EmpleadoId).FirstOrDefault();
            return RedirectToAction("Create",empleado);
        }

        public ActionResult Delete(int EmpleadoId = 0)
        {
            Empleado empleado = _repository.Empleados.Where(e => e.EmpleadoId == EmpleadoId).FirstOrDefault();
            _repository.DeleteEmpleado(empleado);
            return RedirectToAction("List");
        }
    }
}
