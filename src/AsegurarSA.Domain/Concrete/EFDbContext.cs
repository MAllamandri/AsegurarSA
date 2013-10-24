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
<<<<<<< HEAD
        public DbSet<TipoServicio> TipoServicios { get; set; }
=======
        public DbSet<Alarma> Alarmas { get; set; }
>>>>>>> 0e91e6f92b35d423b55dd1e67aadaf2f8b73d2c8
    }
}
