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
    public class ExamenesAlumnosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ExamenesAlumnos
        public async Task<ActionResult> Index()
        {
            var examenes_Alumnos = db.Examenes_Alumnos.Include(e => e.Alumnos).Include(e => e.Examenes);
            return View(await examenes_Alumnos.ToListAsync());
        }

        // GET: ExamenesAlumnos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes_Alumnos examenes_Alumnos = await db.Examenes_Alumnos.FindAsync(id);
            if (examenes_Alumnos == null)
            {
                return HttpNotFound();
            }
            return View(examenes_Alumnos);
        }

        // GET: ExamenesAlumnos/Create
        public ActionResult Create()
        {
            ViewBag.IdAlumnos = new SelectList(db.Alumnos, "IdAlumnos", "Nombres");
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes");
            return View();
        }

        // POST: ExamenesAlumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdExamenes,IdAlumnos,Date,HoraInitial,HoraFinal,intento,Calificacion")] Examenes_Alumnos examenes_Alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Examenes_Alumnos.Add(examenes_Alumnos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlumnos = new SelectList(db.Alumnos, "IdAlumnos", "Nombres", examenes_Alumnos.IdAlumnos);
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes", examenes_Alumnos.IdExamenes);
            return View(examenes_Alumnos);
        }

        // GET: ExamenesAlumnos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes_Alumnos examenes_Alumnos = await db.Examenes_Alumnos.FindAsync(id);
            if (examenes_Alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlumnos = new SelectList(db.Alumnos, "IdAlumnos", "Nombres", examenes_Alumnos.IdAlumnos);
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes", examenes_Alumnos.IdExamenes);
            return View(examenes_Alumnos);
        }

        // POST: ExamenesAlumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdExamenes,IdAlumnos,Date,HoraInitial,HoraFinal,intento,Calificacion")] Examenes_Alumnos examenes_Alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenes_Alumnos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlumnos = new SelectList(db.Alumnos, "IdAlumnos", "Nombres", examenes_Alumnos.IdAlumnos);
            ViewBag.IdExamenes = new SelectList(db.Examenes, "IdExamenes", "CodExamenes", examenes_Alumnos.IdExamenes);
            return View(examenes_Alumnos);
        }

        // GET: ExamenesAlumnos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examenes_Alumnos examenes_Alumnos = await db.Examenes_Alumnos.FindAsync(id);
            if (examenes_Alumnos == null)
            {
                return HttpNotFound();
            }
            return View(examenes_Alumnos);
        }

        // POST: ExamenesAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Examenes_Alumnos examenes_Alumnos = await db.Examenes_Alumnos.FindAsync(id);
            db.Examenes_Alumnos.Remove(examenes_Alumnos);
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
