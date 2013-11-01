using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Cliente { get; }
        Cliente ObtenerCliente(int idCliente);
        void SaveCliente(Cliente cliente);
        void DeleteCliente(Cliente cliente);
        IEnumerable<Cliente> ObtenerClientesPerdidos();
    }
}
