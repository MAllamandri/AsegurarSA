namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AsegurarSA.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<AsegurarSA.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AsegurarSA.Domain.Concrete.EFDbContext";
        }

        protected override void Seed(AsegurarSA.Domain.Concrete.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Empleados.AddOrUpdate(
              p => p.Nombre,
                new Empleado { Nombre = "Andrew Peters" },
                new Empleado { Nombre = "Andrew Peters" },
                new Empleado { Nombre = "Andrew Peters" }
            );
            
        }
    }
}
