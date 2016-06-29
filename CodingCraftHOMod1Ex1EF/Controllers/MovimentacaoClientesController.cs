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
    public class MovimentacaoClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MovimentacaoClientes
        public async Task<ActionResult> Index()
        {
            return View(await db.MovimentacaoClientes.ToListAsync());
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
            return View();
        }

        // POST: MovimentacaoClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MovimentacaoClienteId,Valor,DataSaida,Quantidade")] MovimentacaoCliente movimentacaoCliente)
        {
            if (ModelState.IsValid)
            {
                movimentacaoCliente.MovimentacaoClienteId = Guid.NewGuid();
                db.MovimentacaoClientes.Add(movimentacaoCliente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
            return View(movimentacaoCliente);
        }

        // POST: MovimentacaoClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MovimentacaoClienteId,Valor,DataSaida,Quantidade")] MovimentacaoCliente movimentacaoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimentacaoCliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
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
