using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("MovimentacoesFornecedores")]
    public class MovimentacaoFornecedor
    {
        [Key]
        public Guid MovimentacaoFornecedorId { get; set; }

        public char FormaPagamento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public int FornecedorId { get; set; }

        public int ProdutoId { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }

        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
    }
}