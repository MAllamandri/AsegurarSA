using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;

namespace AsegurarSA.Domain.Concrete
{
    public class EFEmpleadoRepository: IEmpleadoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entities.Empleado> Empleados
        {
            get { return context.Empleados.Where(e => e.Eliminado == false); }
        }


        public void SaveEmpleado(Entities.Empleado empleado)
        {
            if (empleado.EmpleadoId != 0)
            {
                context.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.Empleados.Add(empleado);
                context.Entry(empleado).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void DeleteEmpleado(Entities.Empleado empleado)
        {
            if (empleado != null)
            {
                empleado.Eliminado = true;
                context.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
