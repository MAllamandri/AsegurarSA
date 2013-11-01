using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface ITareaRepository
    {
        IQueryable<Tarea> Tareas { get; }
        void SaveTarea(Tarea tarea);
        void DeleteTarea(Tarea tarea);
    }
}
