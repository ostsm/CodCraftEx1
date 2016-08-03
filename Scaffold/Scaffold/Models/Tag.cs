using CodingCraftHOMod1Ex2Scaffolding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scaffold.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required(ErrorMessage =("Nome da Tag Obrigatória"))]
        [Display(Name =("Nome Tag"))]
        public int NomeTag { get; set; }
                
    }
}