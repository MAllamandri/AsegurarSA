using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AsegurarSA.Domain.Entities
{
    public class Empleado
    {

        public int EmpleadoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }

        [Required]
        [Display(Name="Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public Boolean Eliminado { get; set; }
    }
}
