using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    [Table("Alarmas")]
    public class Alarma
    {
        public int  AlarmaId { get; set; }
        [DisplayName("Domicilio")]
        public string Direccion { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }

}
