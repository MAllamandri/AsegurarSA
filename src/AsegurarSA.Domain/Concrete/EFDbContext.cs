using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsegurarSA.Domain.Entities;
using System.Data.Entity;

namespace AsegurarSA.Domain.Concrete
{
    class EFDbContext: DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoServicio> TipoServicios { get; set; }
        public DbSet<Alarma> Alarmas { get; set; }
        public DbSet<Evento> Eventos { get; set; }

    }
}
