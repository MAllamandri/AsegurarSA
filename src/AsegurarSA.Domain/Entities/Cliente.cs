using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AsegurarSA.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Telefono principal")]
        public string Telefono1 { get; set; }
        [Required]
        [Display(Name = "Telefono auxiliar")]
        public string Telefono2 { get; set; }
        [Required]
        public string Domicilio { get; set; }
        public Boolean Eliminado { get; set; }
        [Required]
        public int EmpresaId { get; set; }
    }
}
