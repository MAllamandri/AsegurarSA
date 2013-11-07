using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;
using AsegurarSA.Domain.Entities;
using Ninject.Infrastructure.Introspection;

namespace AsegurarSA.WebUI.Controllers
{
    [Authorize(Roles = "Administrador, Root")]
    public class TurnoController : Controller
    {
        //
        // GET: /Turno/
         private ITurnoRepository _repository;

         public TurnoController(ITurnoRepository repository)
        {
            this._repository = repository;
        }
        
        public ActionResult Index()
        {
            var ultimoTurno = _repository.Turnos.AsEnumerable().Last();
            ViewData["ultimo"] = ultimoTurno.FechaDia.ToShortDateString();
            return View();
        }

        public ActionResult OriginarTurnos(DateTime  FechaTope)
        {
            List<Turno> lista = _repository.ManejadorTurnos(FechaTope);
            return RedirectToAction("Index");
        }


        public ActionResult ObtenerInformeTurnos()
        {
            return View();
        }


        public ActionResult ObtenerTurnos(DateTime FechaInicio, DateTime FechaTope)
        {
            IEnumerable<Turno> Turnos = _repository.ObtenerTurnos(FechaInicio,FechaTope);
            return View(Turnos);
        }
    }
}
