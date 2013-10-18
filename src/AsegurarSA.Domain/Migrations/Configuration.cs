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
            
        }
    }
}
