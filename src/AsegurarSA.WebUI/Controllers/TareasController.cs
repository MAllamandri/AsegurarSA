using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class TareasController : Controller
    {
        //
        // GET: /Tareas/
        private ITareaRepository _repository;
        private IEmpleadoRepository _repository2 = new EFEmpleadoRepository();
        private IClienteRepository _repository3 = new EFClienteRepository();

        public TareasController(ITareaRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult List()
        {
            return View(_repository.Tareas);
        }

        public ActionResult Create(Tarea Tarea = null)
        {
            if(Tarea.TareaId != 0)
            {
              Tarea = _repository.Tareas.AsEnumerable().First(t => t.TareaId == Tarea.TareaId);
            }
            var lista = _repository2.ObtenerEmpleadosPorRol("Empleado Tecnico");
            IEnumerable<Empleado> listaEmpleados = _repository2.ObtenerEmpleadoPorUsername(lista);
            IEnumerable<Cliente> clientes = _repository3.Cliente;
            var list = new SelectList(listaEmpleados, "EmpleadoId", "Nombre", Tarea.EmpleadoId);
            var listClientes = new SelectList(clientes, "ClienteId", "Nombre", Tarea.ClienteId);
            ViewData["listaEmpleados"] = list;
            ViewData["listaClientes"] = listClientes;
            
            return View(Tarea);
        }

        [HttpPost]
        public ActionResult Create(Tarea tarea, int empleado, int cliente)
        {
            tarea.EmpleadoId = empleado;
            tarea.ClienteId = cliente;
            _repository.SaveTarea(tarea);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int TareaId)
        {
            Tarea t = _repository.Tareas.First(tar => tar.TareaId == TareaId);
            _repository.DeleteTarea(t);
            return RedirectToAction("List");
        }

        public ActionResult Resolver(int TareaId)
        {
            Tarea tarea = _repository.Tareas.First(t => t.TareaId == TareaId);
            tarea.Resuelta = true;
            _repository.SaveTarea(tarea);
            return RedirectToAction("List");
        }
    }
}
