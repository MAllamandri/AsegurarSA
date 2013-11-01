using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsegurarSA.Domain.Entities;

namespace AsegurarSA.WebUI.Models
{
    public class TareaViewModel
    {
        public class TareaModel
        {
            public TipoTarea Tipo
            {
                get;
                set;
            }

            public static class Enum
            {
                public static IEnumerable<TipoTarea> GetItems<TipoTarea>()
                {
                    return System.Enum.GetValues(typeof(TipoTarea)).Cast<TipoTarea>();
                }
            }
        }
    }
}