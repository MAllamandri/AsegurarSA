using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    public class Tarea
    {
        public int TareaId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public TipoTarea Tipo { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int EmpleadoId { get; set; }
        [Required]
        public string Domicilio { get; set; }
        public Boolean Resuelta { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
    }

    public enum TipoTarea
    {
        Tecnica
    }


}
