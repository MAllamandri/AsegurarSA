using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsegurarSA.WebUI.Models
{
    public class AccountModel
    {
        public class LoginViewModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}