using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    [Table("Turnos")]
    public class Turno
    {
        // Tipo turno ---> 1:mañana 2:tarde 3:noche
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TurnoId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaDia { get; set; }
        public int Dia { get; set; }
        public int Semana { get; set; }
        public int TipoTurno { get; set; }
        public Boolean Franco { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
