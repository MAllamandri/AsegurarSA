﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AsegurarSA.Domain.Entities
{
    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmpleadoId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        [Display(Name="Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public Boolean Eliminado { get; set; }
        public string Style { get; set; }
    }
}
