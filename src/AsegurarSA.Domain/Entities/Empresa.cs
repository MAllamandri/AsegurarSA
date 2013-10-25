using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;

namespace AsegurarSA.Domain.Entities
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EmpresaId { get; set; }
        public string Descripcion { get; set; }
    }
}
