using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AsegurarSA.Domain.Entities
{
    [Table("TipoServicios")]
    public class TipoServicio
    {
        [Key]
        public  int TipoServicioId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Costo { get; set; }
        public Boolean Eliminado { get; set; }
    }
}
