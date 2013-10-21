using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsegurarSA.Domain.Entities;
using AsegurarSA.Domain.Concrete;
using WebMatrix.WebData;

namespace AsegurarSA
{
    public static class WebSecurity 
    {
        public static Empleado GetUser(string username)
        {
            var context = new EFDbContext();
            return context.Empleados.Where(u => u.) (u => u.UserName == username).SingleOrDefault();
        }

        public static Empleado GetCurrentUser()
        {
            return GetUser(CurrentUserName);
        }

        public static void CreateUser(Empleado user)
        {
            Empleado dbUser = GetUser(user.UserName);
            if (dbUser != null)
                throw new Exception("User with that username already exists.");
            UnitOfWork uow = new UnitOfWork();
            uow.EmpleadoRepository.Insert(user);
            uow.Save();
        }

        public static void Register()
        {
            Database.SetInitializer<SecurityContext>(new InitSecurityDb());
            SecurityContext context = new SecurityContext();
            context.Database.Initialize(true);
            if (!WebMatrix.WebData.WebSecurity.Initialized)
                WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                    "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }

        public static bool Login(string userName, string password, bool persistCookie = false)
        {
            return WebMatrix.WebData.WebSecurity.Login(userName, password, persistCookie);
        }

        public static bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return WebMatrix.WebData.WebSecurity.ChangePassword(userName, oldPassword, newPassword);
        }

        public static bool ConfirmAccount(string accountConfirmationToken)
        {
            return WebMatrix.WebData.WebSecurity.ConfirmAccount(accountConfirmationToken);
        }

        public static void CreateAccount(string userName, string password, bool requireConfirmationToken = false)
        {
            WebMatrix.WebData.WebSecurity.CreateAccount(userName, password, requireConfirmationToken);
        }

        public static string CreateUserAndAccount(string userName, string password, string email, bool requireConfirmationToken = false)
        {
            return WebMatrix.WebData.WebSecurity.CreateUserAndAccount(userName, password, new { Email = email }, requireConfirmationToken);
        }

        public static int GetUserId(string userName)
        {
            return WebMatrix.WebData.WebSecurity.GetUserId(userName);
        }

        public static void Logout()
        {
            WebMatrix.WebData.WebSecurity.Logout();
        }

        public static bool IsAuthenticated { get { return WebMatrix.WebData.WebSecurity.IsAuthenticated; } }

        public static string CurrentUserName { get { return WebMatrix.WebData.WebSecurity.CurrentUserName; } }
    }
}
