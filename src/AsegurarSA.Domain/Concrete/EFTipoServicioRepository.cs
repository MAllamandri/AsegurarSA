using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFTipoServicioRepository: ITipoServicio
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.TipoServicio> TipoServicio
        {
            get { return context.TipoServicios.Where(t=> t.Eliminado == false); }
        }

        public void SaveTipoServicio(TipoServicio servicio)
        {
            if (servicio.TipoId != 0)
            {
                context.Entry(servicio).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.TipoServicios.Add(servicio);
                context.Entry(servicio).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void DeleteTipoServicio(TipoServicio servicio)
        {
            if (servicio != null)
            {
                servicio.Eliminado = true;
                context.Entry(servicio).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

    }
}
