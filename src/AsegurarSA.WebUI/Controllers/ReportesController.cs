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
    public class ReportesController : Controller
    {
        //
        // GET: /Reportes/
         private IClienteRepository _repository;
        private IClienteServicioRepository _repository2 = new EFClienteServicioRepository();
        private ITipoServicio _repository3 = new EFTipoServicioRepository();

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
    }
}
