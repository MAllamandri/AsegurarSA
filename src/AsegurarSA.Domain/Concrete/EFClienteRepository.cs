using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFClienteRepository: IClienteRepository
    {
        private EFDbContext context = new EFDbContext();
        private IAlarmaRepository contexto = new EFAlarmaRepositry();
        private IClienteServicioRepository context2 = new EFClienteServicioRepository();

        public IEnumerable<Entities.Cliente> Cliente
        {
            get { return context.Clientes.Where(c => c.Eliminado != true); }
        }

        public void SaveCliente(Cliente cliente)
        {
            if (cliente.ClienteId != 0)
            {
                var cs = (ClienteServicio)context.ClientesServicios.First(s => s.ClienteId == cliente.ClienteId && s.FechaBaja == null);
                if (cs.TipoServicioId != cliente.TipoServicioId)
                {
                    BajaClienteServicio(cs);
                    AltaClienteServicio(cliente);
                }

                context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                context.Clientes.Add(cliente);
                context.Entry(cliente).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
                AltaClienteServicio(cliente);
            }
        }

        public void DeleteCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                EFAlarmaRepositry alarma = new EFAlarmaRepositry();
                IQueryable<Alarma> listaAlarmasCliente = contexto.ListaAlarmaCliente(cliente.ClienteId);
                foreach (var alarma1 in listaAlarmasCliente)
                {
                    alarma.DeleteAlarma(alarma1);
                }
                var cs = (ClienteServicio)context.ClientesServicios.First(s => s.TipoServicioId == cliente.TipoServicioId && s.FechaBaja == null);
                BajaClienteServicio(cs);
                cliente.Eliminado = true;
                context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
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

        public IEnumerable<Cliente> ObtenerClientesPerdidos()
        {
            return context.Clientes.Where(c => c.Eliminado == true);
        }

        internal  void AltaClienteServicio(Cliente cliente)
        {
            ClienteServicio cs = new ClienteServicio();
            cs.ClienteId = cliente.ClienteId;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            DateTime fecha;
            if (DateTime.TryParse(DateTime.Now.Date.ToShortDateString(), culture, DateTimeStyles.None,
                out fecha))
                cs.FechaAlta = fecha;
            cs.TipoServicioId = cliente.TipoServicioId;
            cs.FechaBaja = null;
            context.ClientesServicios.Add(cs);
            context.Entry(cs).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        internal void BajaClienteServicio(ClienteServicio cs)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
            DateTime fecha;
            if (DateTime.TryParse(DateTime.Now.Date.ToShortDateString(), culture, DateTimeStyles.None,
                out fecha))
                cs.FechaBaja = fecha;
            context.Entry(cs).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
