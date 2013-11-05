using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IGrabacionesRepository
    {
        IEnumerable<Grabacion> Grabaciones(int clienteId); 
        void SaveGrabaciones(Grabacion grabacion);
    }
}
