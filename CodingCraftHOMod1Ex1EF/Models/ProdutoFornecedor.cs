using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("ProdutosFornecedores")]
    public class ProdutoFornecedor
    {
        [Key]
        public Guid ProdutoFornecedorId { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid FornecedorId { get; set; }

        [Required]
        [Display(Name = "R$ Valor Compra")]
        public decimal PrecoCompra { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}