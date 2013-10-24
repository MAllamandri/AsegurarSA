using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsegurarSA.Domain.Entities;
using Microsoft.Ajax.Utilities;

namespace AsegurarSA.WebUI.Models
{
    public class AlarmaViewModel
    {
        public class AlarmaView
        {
            public IEnumerable<Alarma> listaAlarmas { get; set; }
            public Cliente cliente { get; set; }

        }
    }
}