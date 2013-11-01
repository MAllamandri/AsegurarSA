using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFTareaRepository:ITareaRepository
    {
        EFDbContext context = new EFDbContext();

        public IQueryable<Tarea> Tareas
        {
            get { return context.Tareas.Where(t => t.Resuelta == false); }
        }

        public void SaveTarea(Entities.Tarea tarea)
        {
            if (tarea.TareaId != 0)
            {
                context.Entry(tarea).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.Tareas.Add(tarea);
                context.Entry(tarea).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void DeleteTarea(Tarea tarea)
        {
            context.Entry(tarea).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

    }
}
