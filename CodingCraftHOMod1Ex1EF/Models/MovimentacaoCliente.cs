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

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataSaida { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public int ClienteId { get; set; }

        public int ProdutoId { get; set; }
        
        public virtual ICollection<Cliente> Cliente { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}