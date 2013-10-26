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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Domicilio { get; set; }
        public Boolean Eliminado { get; set; }
        [Required]
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
