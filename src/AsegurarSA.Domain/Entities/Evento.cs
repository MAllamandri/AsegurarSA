using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Descripcion { get; set; }
    }
}
