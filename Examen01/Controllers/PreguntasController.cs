using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen01.Models;

namespace Examen01.Controllers
{
    public class PreguntasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Preguntas
        public async Task<ActionResult> Index()
        {
            var preguntas = db.Preguntas.Include(p => p.Examenes);
            return View(await preguntas.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas preguntas = await db.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return HttpNotFound();
            }
            return View(preguntas);
        }

        // GET: Preguntas/Create
        public ActionResult Create()
        {
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPreguntas,IdExamenes,Pregunta")] Preguntas preguntas)
        {
            if (ModelState.IsValid)
            {
                db.Preguntas.Add(preguntas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes", preguntas.IdExamenes);
            return View(preguntas);
        }

        // GET: Preguntas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas preguntas = await db.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes", preguntas.IdExamenes);
            return View(preguntas);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPreguntas,IdExamenes,Pregunta")] Preguntas preguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes", preguntas.IdExamenes);
            return View(preguntas);
        }

        // GET: Preguntas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preguntas preguntas = await db.Preguntas.FindAsync(id);
            if (preguntas == null)
            {
                return HttpNotFound();
            }
            return View(preguntas);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Preguntas preguntas = await db.Preguntas.FindAsync(id);
            db.Preguntas.Remove(preguntas);
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
