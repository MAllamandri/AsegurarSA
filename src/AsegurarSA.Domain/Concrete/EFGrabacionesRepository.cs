using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFGrabacionesRepository:IGrabacionesRepository
    {
        private EFDbContext context = new EFDbContext();
        public void SaveGrabaciones(Grabacion grabacion)
        {
            if (grabacion != null)
            {
                grabacion.Fecha = DateTime.Now;
                context.Entry(grabacion).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public IEnumerable<Grabacion> Grabaciones(int clienteId)
        {
            return context.Grabaciones.AsEnumerable().Where(g => g.ClienteId == clienteId);
        }
    }
}
