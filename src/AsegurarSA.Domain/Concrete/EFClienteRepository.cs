using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFClienteRepository: IClienteRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Entities.Cliente> Cliente
        {
            get { return context.Clientes.Where(c => c.Eliminado != true); }
        }

        public void SaveCliente(Cliente cliente)
        {
            if (cliente.ClienteId != 0)
            {
                context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.Clientes.Add(cliente);
                context.Entry(cliente).State = System.Data.Entity.EntityState.Added;
            }
            context.SaveChanges();
        }

        public void DeleteCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Eliminado = true;
                context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Cliente ObtenerCliente(int idCliente)
        {
            if (idCliente != 0)
            {
                Cliente cliente = context.Clientes.Where(c => c.ClienteId == idCliente && c.Eliminado != true).FirstOrDefault();
                return cliente;
            }
            return null;
        }

    }
}
