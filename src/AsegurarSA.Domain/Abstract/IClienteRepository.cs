﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.Domain.Abstract
{
    public interface IClienteRepository
    {
        IQueryable<Cliente> Cliente { get; }
        void SaveCliente(Cliente cliente);
        void DeleteCliente(Cliente cliente);
    }
}