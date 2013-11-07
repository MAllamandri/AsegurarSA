using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Controllers
{
   [Authorize(Roles = "Gerente, Root" )]
    public class TipoServicioController : Controller
    {
        //
        // GET: /TipoServicio/
        private ITipoServicio _repository;

        public TipoServicioController(ITipoServicio repository)
        {
            this._repository = repository;
        }

        public ActionResult List()
        {
            return View(_repository.TipoServicio);

        }
        public ActionResult Create(TipoServicio tipoServicio = null)
        {
            return View(tipoServicio);
        }

        [HttpPost]
        public ActionResult Editar(TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveTipoServicio(tipoServicio);
                return RedirectToAction("List");
            }
            return RedirectToAction("Create", tipoServicio);
        }

        public ActionResult Modificar(int TipoServicioId = 0)
        {
            var tipoServicio = _repository.TipoServicio.FirstOrDefault(e => e.TipoServicioId == TipoServicioId);
            return RedirectToAction("Create", tipoServicio);
        }

        public ActionResult Delete(int tipoServicioId = 0)
        {
            var tipoServicio = _repository.TipoServicio.FirstOrDefault(e => e.TipoServicioId == tipoServicioId);
            _repository.DeleteTipoServicio(tipoServicio);
            return RedirectToAction("List");
        }


    }
}
