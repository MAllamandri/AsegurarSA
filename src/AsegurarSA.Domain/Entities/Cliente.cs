using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AsegurarSA.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Telefono principal")]
        public string Telefono1 { get; set; }
        [Required]
        [RegularExpression("(([0-9]{12}))|(([0-9]{13}))")]
        [Display(Name = "Telefono Celular")]
        public string Telefono2 { get; set; }
        [Required]
        public string Domicilio { get; set; }
        public Boolean Eliminado { get; set; }
        [Required]
        public int EmpresaId { get; set; }
        [Required]
        [Display(Name = "Tipo de Servicio")]
        public int TipoServicioId { get; set; }  
    }
}
