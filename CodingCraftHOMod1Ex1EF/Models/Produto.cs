using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public Guid ProdutoId { get; set; }

        [Required]
        public String Nome { get; set; }
        [Required]
        public decimal PrecoVenda { get; set; }

        public int Estoque { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedores { get; set; }

        public List<MovimentacaoFornecedor> MovimentacaoFornecedor { get; set; }

        public List<MovimentacaoCliente> MovimentacaoCliente { get; set; }

    }
}