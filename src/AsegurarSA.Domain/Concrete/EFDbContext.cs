﻿using System;
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
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<TipoServicio> TipoServicios { get; set; }
        public DbSet<Alarma> Alarmas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Turno> Turnos { get; set; } 
        public DbSet<Tarea> Tareas { get; set; } 
        public DbSet<ClienteServicio> ClientesServicios { get; set; }
        public DbSet<Comisaria> Comisarias { get; set; }
        public DbSet<Grabacion> Grabaciones { get; set; }

    }
}
