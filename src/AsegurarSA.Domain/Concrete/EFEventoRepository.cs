using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFEventoRepository:IEventoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.Evento> ObtenerEventos(int IdCliente)
        {
            return context.Eventos.Where(e => e.ClienteId == IdCliente);
        }

        public void SaveEvento(Evento evento)
        {
            if (evento.EventoId != 0)
            {
                context.Entry(evento).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.Eventos.Add(evento);
                context.Entry(evento).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }
    }
}
