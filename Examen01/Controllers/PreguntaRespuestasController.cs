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
    public class PreguntaRespuestasController : Controller
    {
        private Modelo db = new Modelo();

        // GET: PreguntaRespuestas
        public async Task<ActionResult> Index()
        {
            return View(await db.PreguntaRespuesta.ToListAsync());
        }

        // GET: PreguntaRespuestas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntaRespuesta preguntaRespuesta = await db.PreguntaRespuesta.FindAsync(id);
            if (preguntaRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(preguntaRespuesta);
        }

        // GET: PreguntaRespuestas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreguntaRespuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRespuestas,IdExamenes,IdPreguntas,CodExamenes,Curso,Date,Duration,Intentos,NumPreguntas,Pregunta,Respuesta,Value")] PreguntaRespuesta preguntaRespuesta)
        {
            if (ModelState.IsValid)
            {
                db.PreguntaRespuesta.Add(preguntaRespuesta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(preguntaRespuesta);
        }

        // GET: PreguntaRespuestas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntaRespuesta preguntaRespuesta = await db.PreguntaRespuesta.FindAsync(id);
            if (preguntaRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(preguntaRespuesta);
        }

        // POST: PreguntaRespuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRespuestas,IdExamenes,IdPreguntas,CodExamenes,Curso,Date,Duration,Intentos,NumPreguntas,Pregunta,Respuesta,Value")] PreguntaRespuesta preguntaRespuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntaRespuesta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(preguntaRespuesta);
        }

        // GET: PreguntaRespuestas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntaRespuesta preguntaRespuesta = await db.PreguntaRespuesta.FindAsync(id);
            if (preguntaRespuesta == null)
            {
                return HttpNotFound();
            }
            return View(preguntaRespuesta);
        }

        // POST: PreguntaRespuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PreguntaRespuesta preguntaRespuesta = await db.PreguntaRespuesta.FindAsync(id);
            db.PreguntaRespuesta.Remove(preguntaRespuesta);
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
