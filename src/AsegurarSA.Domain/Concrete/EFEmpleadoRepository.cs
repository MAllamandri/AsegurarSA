using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.UI.WebControls;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Entities;
using WebMatrix.WebData;

namespace AsegurarSA.Domain.Concrete
{
    public class EFEmpleadoRepository: IEmpleadoRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entities.Empleado> Empleados
        {
            get { return context.Empleados.Where(e => e.Eliminado == false); }
        }


        public void SaveEmpleado(Entities.Empleado empleado)
        {
            context.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Boolean CrearEmpleado(Empleado empleado, string rol)
        {
            try
            {
               // WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("EFDbContext", "Empleados", "EmpleadoId", "UserName", autoCreateTables: true);
                var roles = (SimpleRoleProvider)Roles.Provider;
                var membership = (SimpleMembershipProvider)Membership.Provider;
                if (membership.GetUser(empleado.UserName, false) == null)
                {
                    IDictionary<string, object> user =
                        new Dictionary<string, object>();
                    user.Add("Nombre", empleado.Nombre);
                    user.Add("Apellido", empleado.Apellido);
                    user.Add("FechaNacimiento", empleado.FechaNacimiento);
                    user.Add("Telefono", empleado.Telefono);
                    user.Add("Eliminado", "False");
                    user.Add("Style", "Grey");

                    var e = new MembershipCreateStatus();
                    membership.CreateUserAndAccount(empleado.UserName, empleado.Password, false, user);

                    if (!roles.GetRolesForUser(empleado.UserName).Contains(rol))
                    {
                        roles.AddUsersToRoles(new[] { empleado.UserName }, new[] {rol});
                    }

                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public void DeleteEmpleado(Entities.Empleado empleado)
        {
            if (empleado != null)
            {
                empleado.Eliminado = true;
                context.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }


        public string[] ObtenerEmpleadosPorRol(string Rol)
        {
            return Roles.GetUsersInRole(Rol);
        }

        public IEnumerable<Empleado> ObtenerEmpleadoPorUsername(string[] usernames)
        {
            List<Empleado> lista = new List<Empleado>();
            foreach (var u in usernames)
            {
                Empleado e = (Empleado)context.Empleados.AsEnumerable().First(em => em.UserName == u);
                if (e.Eliminado != true)
                {
                    lista.Add(e);   
                }
            }
            return lista;
        }

        public void SaveStyle(Empleado empleado, string style)
        {
            empleado.Style = style;
            context.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
