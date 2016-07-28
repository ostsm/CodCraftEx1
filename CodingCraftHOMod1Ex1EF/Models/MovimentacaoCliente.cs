using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("MovimentacoesClientes")]
    public class MovimentacaoCliente
    {
        [Key]
        public Guid MovimentacaoClienteId { get; set; }

        public char FormaPagamento { get; set; }

        
        public float Valor { get; set; }

        public DateTime DataSaida { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [ForeignKey("Usuario")]
        public int ClienteId { get; set; }

        public Guid ProdutoId { get; set; }

        public virtual ApplicationUser Usuario { get; set; }

        public virtual Produto Produto { get; set; }
    }
}