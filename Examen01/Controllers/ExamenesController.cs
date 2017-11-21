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
    public class ExamenesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Examenes
        public async Task<ActionResult> Index()
        {
            var examenes = db.Examenes.Include(e => e.Profesores);
            return View(await examenes.ToListAsync());
        }

        // GET: Examenes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes examenes = await db.Examenes.FindAsync(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // GET: Examenes/Create
        public ActionResult Create()
        {
            ViewBag.IdProfesores = new SelectList(db.Profesores, "IdProfesores", "Nombres");
            return View();
        }

        // POST: Examenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdExamenes,CodExamenes,Curso,Description,Date,Hora,Duration,Intentos,IdProfesores,NumPreguntas,CalifMax,estado")] Examenes examenes)
        {
            if (ModelState.IsValid)
            {
                db.Examenes.Add(examenes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdProfesores = new SelectList(db.Profesores, "IdProfesores", "Nombres", examenes.IdProfesores);
            return View(examenes);
        }

        // GET: Examenes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes examenes = await db.Examenes.FindAsync(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProfesores = new SelectList(db.Profesores, "IdProfesores", "Nombres", examenes.IdProfesores);
            return View(examenes);
        }

        // POST: Examenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdExamenes,CodExamenes,Curso,Description,Date,Hora,Duration,Intentos,IdProfesores,NumPreguntas,CalifMax,estado")] Examenes examenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdProfesores = new SelectList(db.Profesores, "IdProfesores", "Nombres", examenes.IdProfesores);
            return View(examenes);
        }

        // GET: Examenes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes examenes = await db.Examenes.FindAsync(id);
            if (examenes == null)
            {
                return HttpNotFound();
            }
            return View(examenes);
        }

        // POST: Examenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Examenes examenes = await db.Examenes.FindAsync(id);
            db.Examenes.Remove(examenes);
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
