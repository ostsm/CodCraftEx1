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
using CodingCraftHOMod1Ex1EF.Helpers;

namespace CodingCraftHOMod1Ex1EF.Controllers
{
    public class MovimentacaoClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MovimentacaoClientes
        public async Task<ActionResult> Index()
        {
            var movimentacaoClientes = db.MovimentacaoClientes.Include(m => m.Usuario.Id).Include(m => m.Produto);
            return View(await movimentacaoClientes.ToListAsync());
        }

        // GET: MovimentacaoClientes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoCliente movimentacaoCliente = await db.MovimentacaoClientes.FindAsync(id);
            if (movimentacaoCliente == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoCliente);
        }

        // GET: MovimentacaoClientes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: MovimentacaoClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MovimentacaoClienteId,Valor,DataSaida,Quantidade,ClienteId,ProdutoId")] MovimentacaoCliente movimentacaoCliente)
        {
            if (ModelState.IsValid)
            {
                var estoqueAtual = db.Produtos.Where(a => a.ProdutoId == movimentacaoCliente.ProdutoId).FirstOrDefault();
                if (estoqueAtual.Estoque <=0 || estoqueAtual.Estoque ==null || estoqueAtual.Estoque < movimentacaoCliente.Quantidade)
                {
                    this.FlashError("Produto zerado ou indisponivel para quantidade desejada.");
                }
                movimentacaoCliente.MovimentacaoClienteId = Guid.NewGuid();

                db.MovimentacaoClientes.Add(movimentacaoCliente);
                
                estoqueAtual.ProdutoId = movimentacaoCliente.ProdutoId;
                estoqueAtual.Estoque = estoqueAtual.Estoque - (movimentacaoCliente.Quantidade * estoqueAtual.QntVenda);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", movimentacaoCliente.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", movimentacaoCliente.ProdutoId);
            return View(movimentacaoCliente);
        }

        // GET: MovimentacaoClientes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoCliente movimentacaoCliente = await db.MovimentacaoClientes.FindAsync(id);
            if (movimentacaoCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", movimentacaoCliente.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", movimentacaoCliente.ProdutoId);
            return View(movimentacaoCliente);
        }

        // POST: MovimentacaoClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MovimentacaoClienteId,Valor,DataSaida,Quantidade,ClienteId,ProdutoId")] MovimentacaoCliente movimentacaoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoCliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", movimentacaoCliente.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", movimentacaoCliente.ProdutoId);
            return View(movimentacaoCliente);
        }

        // GET: MovimentacaoClientes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoCliente movimentacaoCliente = await db.MovimentacaoClientes.FindAsync(id);
            if (movimentacaoCliente == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoCliente);
        }

        // POST: MovimentacaoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            MovimentacaoCliente movimentacaoCliente = await db.MovimentacaoClientes.FindAsync(id);
            db.MovimentacaoClientes.Remove(movimentacaoCliente);
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
