using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModel
{
    public class MovimentacaoFornecedorsPesquisaModel
    {
        public DateTime? Data { get;  set; }
        [Display(Name ="Forma de Pagamento")]
        public char FormaPagamento { get;  set; }
        [Display(Name = "Fornecedor")]
        public string FornecedorNome { get;  set; }
        [Display(Name = "Produto")]
        public string ProdutoNome { get;  set; }
        public int Quantidade { get;  set; }
        public double? Valor { get;  set; }
    }
}