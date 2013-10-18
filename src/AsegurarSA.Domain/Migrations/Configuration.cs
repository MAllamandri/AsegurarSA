namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AsegurarSA.Domain.Entities;
    using AsegurarSA.Domain.Concrete;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Empleados.AddOrUpdate(
              p => p.Nombre,
                new Empleado { Nombre = "Pablo", Apellido = "Ibarra", FechaNacimiento = DateTime.Now,Telefono = "554564"},
                new Empleado { Nombre = "Maximiliano", Apellido = "Allamandri", FechaNacimiento = DateTime.Now, Telefono = "554564" },
                new Empleado { Nombre = "Marcos", Apellido = "Frund", FechaNacimiento = DateTime.Now, Telefono = "554564" },
                new Empleado { Nombre = "Ezequiel", Apellido = "Kuschnir", FechaNacimiento = DateTime.Now, Telefono = "554564" },
                new Empleado { Nombre = "Estefano", Apellido = "Veronesse", FechaNacimiento = DateTime.Now, Telefono = "554564" }
            );
            context.Clientes.AddOrUpdate(
                c => c.Nombre,
                    new Cliente { Nombre = "Lucas", Apellido = "Rodriguez", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "JJ 201"},
                    new Cliente { Nombre = "Diego", Apellido = "Veronesse", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "CC 201"},
                    new Cliente { Nombre = "Mariano", Apellido = "Ferrero", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "AA 201"},
                    new Cliente { Nombre = "Pedro", Apellido = "LaPrida", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "DD 201"},
                    new Cliente { Nombre = "Ignacio", Apellido = "Santos", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "EE 201"}
                );
            
        }
    }
}
