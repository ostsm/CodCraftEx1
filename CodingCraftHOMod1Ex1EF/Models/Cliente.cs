using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public Guid ClienteId { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Setor { get; set; }

     }
}