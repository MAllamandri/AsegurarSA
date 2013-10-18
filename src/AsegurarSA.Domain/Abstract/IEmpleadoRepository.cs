using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IEmpleadoRepository
    {
        IQueryable<Empleado> Empleados { get; }
        void SaveEmpleado(Empleado empleado);
        void DeleteEmpleado(Empleado empleado);
    }
}
