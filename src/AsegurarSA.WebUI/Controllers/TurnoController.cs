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
    public class TurnoController : Controller
    {
        //
        // GET: /Turno/
         private ITurnoRepository _repository;
         private IClienteRepository _clienterepository;

         public TurnoController(ITurnoRepository repository, IClienteRepository clienteRepository)
        {
            this._repository = repository;
            this._clienterepository = clienteRepository;
        }
        
        public ActionResult Index()
        {
            EFTurnoRepository context = new EFTurnoRepository();
            IEnumerable<Turno> lista = context.ObtenerListaTurnos();
            ViewBag.UltimoTurno = lista.ElementAt(0).FechaDia;
            return View();
        }

        public ActionResult OriginarTurnos(DateTime  FechaTope)
        {
            EFTurnoRepository context = new EFTurnoRepository();
            List<Turno> lista = context.ManejadorTurnos(FechaTope);
          
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
