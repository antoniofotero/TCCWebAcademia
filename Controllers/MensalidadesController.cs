using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAcademia.Classes;
using WebAcademia.Models;

namespace WebAcademia.Controllers
{
    public class MensalidadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mensalidades
        public ActionResult Index()
        {
            var mensalidades = db.Mensalidades.Include(m => m.AlunoMensalidade);
            return View(mensalidades.ToList());
        }

        // GET: Mensalidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidade mensalidade = db.Mensalidades.Find(id);
            if (mensalidade == null)
            {
                return HttpNotFound();
            }
            return View(mensalidade);
        }

        // GET: Mensalidades/Create
        public ActionResult Create()
        {
            ViewBag.CodigoMensalidade = new SelectList(db.Alunoes, "Matricula", "Nome");
            return View();
        }

        // POST: Mensalidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoMensalidade,MesReferencia,DataVencimento,DataPagamento,PagamentoConcluido")] Mensalidade mensalidade)
        {
            if (ModelState.IsValid)
            {
                db.Mensalidades.Add(mensalidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoMensalidade = new SelectList(db.Alunoes, "Matricula", "Nome", mensalidade.CodigoMensalidade);
            return View(mensalidade);
        }

        // GET: Mensalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidade mensalidade = db.Mensalidades.Find(id);
            if (mensalidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoMensalidade = new SelectList(db.Alunoes, "Matricula", "Nome", mensalidade.CodigoMensalidade);
            return View(mensalidade);
        }

        // POST: Mensalidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoMensalidade,MesReferencia,DataVencimento,DataPagamento,PagamentoConcluido")] Mensalidade mensalidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mensalidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoMensalidade = new SelectList(db.Alunoes, "Matricula", "Nome", mensalidade.CodigoMensalidade);
            return View(mensalidade);
        }

        // GET: Mensalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mensalidade mensalidade = db.Mensalidades.Find(id);
            if (mensalidade == null)
            {
                return HttpNotFound();
            }
            return View(mensalidade);
        }

        // POST: Mensalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensalidade mensalidade = db.Mensalidades.Find(id);
            db.Mensalidades.Remove(mensalidade);
            db.SaveChanges();
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
