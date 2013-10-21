

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AsegurarSA.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AsegurarSA.Domain.Entities;
    using AsegurarSA.Domain.Concrete;
    using WebMatrix.WebData;
    using System.Web.Security;
    using System.Web;

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
             //   new Empleado { UserName = "pibarra", Nombre = "Pablo", Apellido = "Ibarra", FechaNacimiento = DateTime.Now,Telefono = "554564"},
                new Empleado { UserName = "mallamandri", Nombre = "Maximiliano", Apellido = "Allamandri", FechaNacimiento = DateTime.Now, Telefono = "554564" },
                new Empleado { UserName = "mfrund", Nombre = "Marcos", Apellido = "Frund", FechaNacimiento = DateTime.Now, Telefono = "554564" },
                new Empleado { UserName = "ekuschnir", Nombre = "Ezequiel", Apellido = "Kuschnir", FechaNacimiento = DateTime.Now, Telefono = "554564" },
                new Empleado { UserName = "everonesse", Nombre = "Estefano", Apellido = "Veronesse", FechaNacimiento = DateTime.Now, Telefono = "554564" }
            );
            context.Clientes.AddOrUpdate(
                c => c.Nombre,
                    new Cliente { Nombre = "Lucas", Apellido = "Rodriguez", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "JJ 201"},
                    new Cliente { Nombre = "Diego", Apellido = "Veronesse", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "CC 201"},
                    new Cliente { Nombre = "Mariano", Apellido = "Ferrero", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "AA 201"},
                    new Cliente { Nombre = "Pedro", Apellido = "LaPrida", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "DD 201"},
                    new Cliente { Nombre = "Ignacio", Apellido = "Santos", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "EE 201"}
                );

            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("EFDbContext",
   "Empleados", "EmpleadoId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("pibarra", false) == null)
            {
                IDictionary<string, object> openWith =
                    new Dictionary<string, object>();
                openWith.Add("Nombre","Pablo");
                openWith.Add("Apellido", "Ibarra");
                openWith.Add("FechaNacimiento", DateTime.Now);
                openWith.Add("Telefono","565758");

                var e = new MembershipCreateStatus();
                membership.CreateUserAndAccount("pibarra", "admin", false, openWith);
                    // new { Nombre = "Pablo" });//("pibarra", "admin",null,null,null,true,null,out e);
            }
            if (!roles.GetRolesForUser("pibarra").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "pibarra" }, new[] { "admin" });
            }
            //if (membership.GetUser("joe", false) == null)
            //{
            // //   membership.CreateUserAndAccount("joe", "test");
            //}

            
        }
    }
}
