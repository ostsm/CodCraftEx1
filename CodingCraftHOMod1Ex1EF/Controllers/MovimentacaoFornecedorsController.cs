using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using IdentitySample.Models;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class MovimentacaoFornecedorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MovimentacaoFornecedors
        public async Task<ActionResult> Index()
        {
            var movimentacaoFornecedors = db.MovimentacaoFornecedors.Include(m => m.Fornecedor).Include(m => m.Produto);
            return View(await movimentacaoFornecedors.ToListAsync());
        }

        // GET: MovimentacaoFornecedors/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoFornecedor movimentacaoFornecedor = await db.MovimentacaoFornecedors.FindAsync(id);
            if (movimentacaoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoFornecedor);
        }

        // GET: MovimentacaoFornecedors/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: MovimentacaoFornecedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MovimentacaoFornecedorId,Valor,Data,Quantidade,FornecedorId,ProdutoId")] MovimentacaoFornecedor movimentacaoFornecedor)
        {
            if (ModelState.IsValid)
            {
                movimentacaoFornecedor.MovimentacaoFornecedorId = Guid.NewGuid();
                // Movimentaçao de entrada
                // Deve ser adicionada a quantidade do produto 
                var produto = db.Produtos.Where(a => a.ProdutoId == movimentacaoFornecedor.ProdutoId).FirstOrDefault();

                produto.ProdutoId = movimentacaoFornecedor.ProdutoId;
               

                /// R$0,75 acima produto é vendido por 1 real
                int i = 0;
                Double valUnit = Convert.ToDouble(movimentacaoFornecedor.Valor / movimentacaoFornecedor.Quantidade);
                produto.PrecoVenda = valUnit;
                if (valUnit > (0.75))
                    produto.PrecoVenda = 1;
                // margem de perda 0,15 centavos

                else for (; produto.PrecoVenda < 1.15; i++)
                    {
                        produto.PrecoVenda = produto.PrecoVenda + valUnit;
                    }

                if ( ((produto.PrecoVenda - 1) * -1) > (produto.PrecoVenda + valUnit) - 1) { 
                    produto.PrecoVenda = produto.PrecoVenda + valUnit;
                    i++;
                }
                if (i > 1)
                {
                    produto.Combo = string.Format(" {0} por 1 real", i.ToString());
                }
                produto.QntVenda = Convert.ToInt16(i);
                if (produto.Estoque == null)
                    produto.Estoque = 0;
                produto.Estoque = produto.Estoque + movimentacaoFornecedor.Quantidade;
                produto.PrecoVenda = 1;

                db.MovimentacaoFornecedors.Add(movimentacaoFornecedor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", movimentacaoFornecedor.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", movimentacaoFornecedor.ProdutoId);
            return View(movimentacaoFornecedor);
        }

        // GET: MovimentacaoFornecedors/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoFornecedor movimentacaoFornecedor = await db.MovimentacaoFornecedors.FindAsync(id);
            if (movimentacaoFornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", movimentacaoFornecedor.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", movimentacaoFornecedor.ProdutoId);
            return View(movimentacaoFornecedor);
        }

        // POST: MovimentacaoFornecedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MovimentacaoFornecedorId,Valor,Data,Quantidade,FornecedorId,ProdutoId")] MovimentacaoFornecedor movimentacaoFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoFornecedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", movimentacaoFornecedor.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", movimentacaoFornecedor.ProdutoId);
            return View(movimentacaoFornecedor);
        }

        // GET: MovimentacaoFornecedors/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoFornecedor movimentacaoFornecedor = await db.MovimentacaoFornecedors.FindAsync(id);
            if (movimentacaoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoFornecedor);
        }

        // POST: MovimentacaoFornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            MovimentacaoFornecedor movimentacaoFornecedor = await db.MovimentacaoFornecedors.FindAsync(id);
            db.MovimentacaoFornecedors.Remove(movimentacaoFornecedor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
