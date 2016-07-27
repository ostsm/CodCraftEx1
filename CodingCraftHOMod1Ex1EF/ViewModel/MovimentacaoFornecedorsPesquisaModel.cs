using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModel
{
    public class MovimentacaoFornecedorsPesquisaModel
    {
        public DateTime Data { get;  set; }
        public char FormaPagamento { get;  set; }
        public string FornecedorNome { get;  set; }
        public string ProdutoNome { get;  set; }
        public int Quantidade { get;  set; }
        public double Valor { get;  set; }
    }
}