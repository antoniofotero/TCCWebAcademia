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
    public class AlunosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var alunoes = db.Alunoes.Include(a => a.AlunoMensalidade);
            return View(alunoes.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        public ActionResult Create()
        {
            ViewBag.Matricula = new SelectList(db.Mensalidades, "CodigoMensalidade", "CodigoMensalidade");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matricula,CPF,Nome,DataNascimento,EnderecoAluno")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Matricula = new SelectList(db.Mensalidades, "CodigoMensalidade", "CodigoMensalidade", aluno.Matricula);
            return View(aluno);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.Matricula = new SelectList(db.Mensalidades, "CodigoMensalidade", "CodigoMensalidade", aluno.Matricula);
            return View(aluno);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matricula,CPF,Nome,DataNascimento,EnderecoAluno")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Matricula = new SelectList(db.Mensalidades, "CodigoMensalidade", "CodigoMensalidade", aluno.Matricula);
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunoes.Find(id);
            db.Alunoes.Remove(aluno);
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
