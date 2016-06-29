using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CodingCraftHOMod1Ex1EF.Models;
using IdentitySample.Models;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class ProdutosFornecedoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdutosFornecedores
        public async Task<ActionResult> Index()
        {
            var produtoFornecedors = db.ProdutosFornecedores.Include(p => p.Fornecedor).Include(p => p.Produto);
            return View(await produtoFornecedors.ToListAsync());
        }

        // GET: ProdutosFornecedores/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoFornecedor produtoFornecedor = await db.ProdutosFornecedores.FindAsync(id);
            if (produtoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(produtoFornecedor);
        }

        // GET: ProdutosFornecedores/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: ProdutosFornecedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProdutoFornecedorId,ProdutoId,FornecedorId,PrecoCompra")] ProdutoFornecedor produtoFornecedor)
        {
            if (ModelState.IsValid)
            {
                produtoFornecedor.ProdutoFornecedorId = Guid.NewGuid();
                db.ProdutosFornecedores.Add(produtoFornecedor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", produtoFornecedor.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", produtoFornecedor.ProdutoId);
            return View(produtoFornecedor);
        }

        // GET: ProdutosFornecedores/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoFornecedor produtoFornecedor = await db.ProdutosFornecedores.FindAsync(id);
            if (produtoFornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", produtoFornecedor.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", produtoFornecedor.ProdutoId);
            return View(produtoFornecedor);
        }

        // POST: ProdutosFornecedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProdutoFornecedorId,ProdutoId,FornecedorId,PrecoCompra")] ProdutoFornecedor produtoFornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoFornecedor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "FornecedorId", "Nome", produtoFornecedor.FornecedorId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", produtoFornecedor.ProdutoId);
            return View(produtoFornecedor);
        }

        // GET: ProdutosFornecedores/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoFornecedor produtoFornecedor = await db.ProdutosFornecedores.FindAsync(id);
            if (produtoFornecedor == null)
            {
                return HttpNotFound();
            }
            return View(produtoFornecedor);
        }

        // POST: ProdutosFornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProdutoFornecedor produtoFornecedor = await db.ProdutosFornecedores.FindAsync(id);
            db.ProdutosFornecedores.Remove(produtoFornecedor);
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
