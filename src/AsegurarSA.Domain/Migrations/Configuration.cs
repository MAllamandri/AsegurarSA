

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
                new Empleado { UserName = "mallamandri", Nombre = "Maximiliano", Apellido = "Allamandri", FechaNacimiento = DateTime.Now, Telefono = "554564",Eliminado = false},
                new Empleado { UserName = "mfrund", Nombre = "Marcos", Apellido = "Frund", FechaNacimiento = DateTime.Now, Telefono = "554564", Eliminado = false },
                new Empleado { UserName = "ekuschnir", Nombre = "Ezequiel", Apellido = "Kuschnir", FechaNacimiento = DateTime.Now, Telefono = "554564", Eliminado = false },
                new Empleado { UserName = "everonesse", Nombre = "Estefano", Apellido = "Veronesse", FechaNacimiento = DateTime.Now, Telefono = "554564", Eliminado = false }
            );
            context.Clientes.AddOrUpdate(
                c => c.Nombre,
                    new Cliente { Nombre = "Lucas", Apellido = "Rodriguez", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "JJ 201", EmpresaId = 1},
                    new Cliente { Nombre = "Diego", Apellido = "Veronesse", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "CC 201", EmpresaId = 2 },
                    new Cliente { Nombre = "Mariano", Apellido = "Ferrero", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "AA 201", EmpresaId =3 },
                    new Cliente { Nombre = "Pedro", Apellido = "LaPrida", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "DD 201", EmpresaId =3 },
                    new Cliente { Nombre = "Ignacio", Apellido = "Santos", Telefono1 = "554564", Telefono2 = "554564", Domicilio = "EE 201", EmpresaId = 1 }
                );

            context.Empresas.AddOrUpdate(
                e => e.EmpresaId,
                    new Empresa { Descripcion = "Claro"},
                    new Empresa { Descripcion = "Personal"},
                    new Empresa { Descripcion = "Movistar"});

            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("EFDbContext",
   "Empleados", "EmpleadoId", "UserName", autoCreateTables: true);
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Root");
                roles.CreateRole("Administrador");
                roles.CreateRole("Gerente");
                roles.CreateRole("Empleado");
            }
            if (membership.GetUser("pibarra", false) == null)
            {
                IDictionary<string, object> user =
                    new Dictionary<string, object>();
                user.Add("Nombre","Pablo");
                user.Add("Apellido", "Ibarra");
                user.Add("FechaNacimiento", DateTime.Now);
                user.Add("Telefono","565758");
                user.Add("Eliminado", "false");
                var e = new MembershipCreateStatus();
                membership.CreateUserAndAccount("pibarra", "admin", false, user);
                    // new { Nombre = "Pablo" });//("pibarra", "admin",null,null,null,true,null,out e);
            }
            if (!roles.GetRolesForUser("pibarra").Contains("root"))
            {
                roles.AddUsersToRoles(new[] { "pibarra" }, new[] { "root" });
            }
            //if (membership.GetUser("joe", false) == null)
            //{
            // //   membership.CreateUserAndAccount("joe", "test");
            //}

            
        }
    }
}
