using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        public Guid FornecedorId { get; set; }

        [Required]
        public String Nome { get; set; }

        public virtual ICollection<ProdutoFornecedor> FornecedorProdutos { get; set; }

        public List<MovimentacaoFornecedor> MovimentacaoFornecedor { get; set; }


    }
}