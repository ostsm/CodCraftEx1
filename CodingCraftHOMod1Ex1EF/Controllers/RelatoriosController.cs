using CodingCraftHOMod1Ex1EF.ViewModel;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class RelatoriosController : Controller
    {
        // GET: Relatorios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entradas()
        {

            using (var db = new ApplicationDbContext())
            {
                var dados = from ft in db.MovimentacaoFornecedors
                            orderby ft.Data
                            select new MovimentacaoFornecedorsPesquisaModel()
                            {
                                Data = ft.Data,
                              //  FormaPagamento = ft.FormaPagamento,
                                FornecedorNome = ft.Fornecedor.Nome,
                                ProdutoNome = ft.Produto.Nome,
                                Quantidade = ft.Quantidade,
                                Valor = ft.Valor,



                            };
                return View((dados).ToList());
            }
           
        }

        public ActionResult Saidas()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            return View();
        }
    }
}