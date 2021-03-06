﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;
using WebMatrix.WebData;

namespace AsegurarSA.WebUI.Controllers
{
    [Authorize(Roles = "Administrador, Root")]
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
            var empleado = _repository.Empleados.FirstOrDefault(e => e.EmpleadoId == EmpleadoId);
            return RedirectToAction("Create",empleado);
        }


        public ActionResult CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearEmpleado(Empleado empleado, int rol=3)
        {
            var srol = rol== 4 ? "Empleado Monitoreo": rol == 3 ? "Empleado Tecnico" : rol == 2 ? "Gerente" : rol == 1 ? "Administrador" : "Root";
             if (_repository.CrearEmpleado(empleado,srol))
            {
              //  _repository.CrearEmpleado(empleado);
                return RedirectToAction("List");
           }
            return View(empleado);
        }
        public ActionResult Delete(int EmpleadoId = 0)
        {
            var empleado = _repository.Empleados.FirstOrDefault(e => e.EmpleadoId == EmpleadoId);
            _repository.DeleteEmpleado(empleado);
            return RedirectToAction("List");
        }

        [HttpPost]
        public JsonResult SetearStyle(string sty)
        {
            Empleado emp = _repository.Empleados.AsEnumerable().First(e => e.EmpleadoId == WebSecurity.CurrentUserId);
            _repository.SaveStyle(emp, sty);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
