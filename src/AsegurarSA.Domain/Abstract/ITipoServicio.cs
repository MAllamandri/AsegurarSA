using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface ITipoServicio
    {
        IQueryable<TipoServicio> TipoServicio { get; }
        void SaveTipoServicio(TipoServicio tipoServicio);
        void DeleteTipoServicio(TipoServicio tipoServicio);
    }
}
