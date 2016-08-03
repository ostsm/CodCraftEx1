using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scaffold.Models
{
    public class GrupoProduto
    {

        [Key]
        public int GrupoProdutoId { get; set; }

        [Required]
        [Display(Name ="Grupo Produto Nome")]
        public string GrupoProdutoNome {get;set;}


      //  public ICollection<GrupoProduto=>

    }
}