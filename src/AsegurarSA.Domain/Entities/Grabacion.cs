using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    public class Grabacion
    {
        public int GrabacionId { get; set; }
        public string PathGrabacion { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
