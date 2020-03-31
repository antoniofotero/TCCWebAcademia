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
    public class AgendaAulasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AgendaAulas
        public ActionResult Index()
        {
            return View(db.AgendaAulas.ToList());
        }

        // GET: AgendaAulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendaAulas agendaAulas = db.AgendaAulas.Find(id);
            if (agendaAulas == null)
            {
                return HttpNotFound();
            }
            return View(agendaAulas);
        }

        // GET: AgendaAulas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendaAulas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoAgendamento,HoraInicio,DuracaoMinutos")] AgendaAulas agendaAulas)
        {
            if (ModelState.IsValid)
            {
                db.AgendaAulas.Add(agendaAulas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agendaAulas);
        }

        // GET: AgendaAulas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendaAulas agendaAulas = db.AgendaAulas.Find(id);
            if (agendaAulas == null)
            {
                return HttpNotFound();
            }
            return View(agendaAulas);
        }

        // POST: AgendaAulas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoAgendamento,HoraInicio,DuracaoMinutos")] AgendaAulas agendaAulas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendaAulas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendaAulas);
        }

        // GET: AgendaAulas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendaAulas agendaAulas = db.AgendaAulas.Find(id);
            if (agendaAulas == null)
            {
                return HttpNotFound();
            }
            return View(agendaAulas);
        }

        // POST: AgendaAulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgendaAulas agendaAulas = db.AgendaAulas.Find(id);
            db.AgendaAulas.Remove(agendaAulas);
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
