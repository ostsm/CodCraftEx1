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

        public String Combo { get; set; }

        [Display(Name = "R$ Venda")]
        public double? PrecoVenda { get; set; }

        public int? Estoque { get; set; }

        [Display(Name = "Quantidade que será retirada do estoque")]
        public int? QntVenda { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedores { get; set; }

        public List<MovimentacaoFornecedor> MovimentacaoFornecedor { get; set; }

        public List<MovimentacaoCliente> MovimentacaoCliente { get; set; }

    }
}