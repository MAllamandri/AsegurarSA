using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AsegurarSA.Domain.Entities;

namespace WebApiAsegurarSA.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public Cliente Get()
        {
            return new Cliente { Nombre = "Maxi", Telefono1 = "3404538247",Apellido = "Allamandri", ClienteId = 1, Domicilio = "Rivadavia", Telefono2 = "003493503", Eliminado = false};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}