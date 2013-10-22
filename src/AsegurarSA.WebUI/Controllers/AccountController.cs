using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.WebUI.Models;
using WebMatrix.WebData;

namespace AsegurarSA.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel.LoginViewModel login)
        {
            bool success = WebSecurity.Login(login.UserName, login.Password);
            if (success)
            {
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)
                {
                    return Json( new  { result= true, returnUrl = '/' });
                }
                else
                {
                    return Json(new { result = true, returnUrl = returnUrl });
                }
            }
            return Json(new { result = false });
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login");
        }


    }
}
