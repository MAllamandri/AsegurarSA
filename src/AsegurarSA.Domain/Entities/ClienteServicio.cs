using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    public class ClienteServicio
    {
        [Key]
        public int ServicioClienteId { get; set; }
        public int TipoServicioId { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual TipoServicio Servicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set;}
        [DataType(DataType.Date)]
        public DateTime? FechaBaja { get; set; }
    }
}
