using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{

    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
    }
}
