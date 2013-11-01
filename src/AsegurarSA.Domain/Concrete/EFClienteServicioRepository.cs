using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Concrete
{
    public class EFClienteServicioRepository:IClienteServicioRepository
    {

        EFDbContext context = new EFDbContext();

        public IEnumerable<ClienteServicio> ObtenerClientesPorServicio(int TipoServicioId, DateTime FechaInicio, DateTime FechaFin)
        {
            return
                context.ClientesServicios.Where(
                    cs =>
                        (cs.TipoServicioId == TipoServicioId) &&
                        ((cs.FechaAlta <= FechaInicio && cs.FechaBaja >= FechaFin) ||
                            (cs.FechaAlta >= FechaInicio && cs.FechaAlta <= FechaFin) ||
                            (cs.FechaBaja >= FechaInicio && cs.FechaBaja <= FechaFin)));
        }
    }
}
