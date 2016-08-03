using CodingCraftHOMod1Ex2Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scaffold.Models
{
    public class CategoriaProduto
    {
        [Key]
        public int CategoriaProdutoId { get; set; }

        [Required]
        [Display(Name ="Categoria Nome")]
        public string CategoriaNome { get; set; }

        public ICollection<Produto> Produto { get; set; }

   }
}