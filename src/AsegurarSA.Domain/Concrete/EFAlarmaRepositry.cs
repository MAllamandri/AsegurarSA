using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFAlarmaRepositry: IAlarmaRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Alarma> ListaAlarmaCliente(int idCliente)
        {
            return context.Alarmas.Where(a => a.ClienteId == idCliente && a.FechaBaja == null);
        }

        public Alarma BuscarAlarma(int idAlarma)
        {
            return context.Alarmas.FirstOrDefault(a => a.AlarmaId == idAlarma && a.FechaBaja == null);
        }

        public void SaveAlarma(Alarma alarma)
        {
            if (alarma.AlarmaId != 0)
            {
                context.Entry(alarma).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.Alarmas.Add(alarma);
                context.Entry(alarma).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void DeleteAlarma(Alarma alarma)
        {
            if (alarma != null)
            {
                alarma.FechaBaja = DateTime.Now;
                context.Entry(alarma).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
