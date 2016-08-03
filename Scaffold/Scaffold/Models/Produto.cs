using Scaffold.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public long ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }


        public ICollection<Venda> Venda { get; set; }
        //FKs

        [Display(Name = "Categoria ")]
        public int CategoriaProdutoId { get; set; }

        [Display(Name ="Tag")]
        public int TagId { get; set; }

        [ForeignKey("CategoriaProdutoId")]
        public virtual CategoriaProduto CategoriaProduto { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }

        


    }
}