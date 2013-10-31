using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface ITurnoRepository
    {
        IQueryable<Turno> Turnos { get; }
        void SaveTurno(Turno turno);
        IEnumerable<Turno> ObtenerListaTurnos();
        IEnumerable<Turno> ObtenerTurnos(DateTime fechaInicio, DateTime fechaTope);
        List<Turno> ManejadorTurnos(DateTime FechaDia);
    }
}
