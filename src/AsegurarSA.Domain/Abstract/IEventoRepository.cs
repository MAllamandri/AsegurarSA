using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IEventoRepository
    {
        IEnumerable<Evento> ObtenerEventos(int idCliente);
        void SaveEvento(Evento evento);
    }
}
