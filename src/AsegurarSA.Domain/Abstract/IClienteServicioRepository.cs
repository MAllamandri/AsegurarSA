using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IClienteServicioRepository
    {
        IEnumerable<ClienteServicio> ObtenerClientesPorServicio(int TipoServicioId, DateTime FechaInicio, DateTime FechaFin);

    }
}
