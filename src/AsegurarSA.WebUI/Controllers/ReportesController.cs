using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
    [Authorize(Roles = "Gerente, Administrador")]
    public class ReportesController : Controller
    {
        //
        // GET: /Reportes/
        private IClienteRepository _repository;
        private IClienteServicioRepository _repository2 = new EFClienteServicioRepository();
        private ITipoServicio _repository3 = new EFTipoServicioRepository();
        private ITurnoRepository _repository4 = new EFTurnoRepository();
        private IEmpleadoRepository _repository5 = new EFEmpleadoRepository();
        private IEventoRepository _repository6 = new EFEventoRepository();

         public ReportesController(IClienteRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult ClientesPerdidos()
        {
            IEnumerable<Cliente> ListaPerdidos = _repository.ObtenerClientesPerdidos();
            return View(ListaPerdidos);
        }

        public ActionResult ClienteServicio()
        {
            IEnumerable<TipoServicio> lista = _repository3.TipoServicio;
            var list = new SelectList(lista, "TipoServicioId", "Nombre", "Nombre");
            ViewData["listaServicios"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult InformeClientesServicios(DateTime FechaInicio, DateTime FechaFin, int servicio)
        {
            IEnumerable<ClienteServicio> listaClienteServicios = _repository2.ObtenerClientesPorServicio(servicio,FechaInicio,FechaFin);
            ViewData["FechaI"] = FechaInicio.ToShortDateString();
            ViewData["FechaF"] = FechaFin.ToShortDateString();
            return View(listaClienteServicios);
        }


        public ActionResult EmpleadoHoras()
        {
            var listaEmpleados = _repository5.Empleados;
            var list = new SelectList(listaEmpleados, "EmpleadoId", "Nombre");
            ViewData["list"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult InformeEmpleadosHoras(DateTime fechaInicio, DateTime fechaFin, int empleado)
        {
            if (fechaInicio <= fechaFin)
            {
                IEnumerable<Turno> Turnos = _repository4.ObtenerTurnos(fechaInicio, fechaFin);
                Turnos = Turnos.Where(e => e.EmpleadoId == empleado && e.Franco == false);
                int cantidadHoras = Turnos.Count()*8;
                ViewData["horas"] = cantidadHoras;
                ViewData["fechaInicio"] = fechaInicio.ToShortDateString();
                ViewData["fechaFin"] = fechaFin.ToShortDateString();
                Empleado emp = (Empleado)_repository5.Empleados.AsEnumerable().Where(em => em.EmpleadoId == empleado).FirstOrDefault();
                return View(emp);
            }
            else
            {
                return RedirectToAction("EmpleadoHoras");
            }
        }

        public ActionResult Eventos()
        {
            return View();
        }

        public ActionResult InformeEventos(DateTime fechaInicio, DateTime fechaFin)
        {
            IEnumerable<Evento> eventos = _repository6.Eventos().AsEnumerable().Where(e => e.Fecha.Date >= fechaInicio && e.Fecha.Date <= fechaFin);
            return View(eventos);
        }


    }
}
