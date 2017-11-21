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
    public class ProfesoresController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Profesores
        public async Task<ActionResult> Index()
        {
            return View(await db.Profesores.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesores profesores = await db.Profesores.FindAsync(id);
            if (profesores == null)
            {
                return HttpNotFound();
            }
            return View(profesores);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdProfesores,Nombres,Apellidos,Correo")] Profesores profesores)
        {
            if (ModelState.IsValid)
            {
                db.Profesores.Add(profesores);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(profesores);
        }

        // GET: Profesores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesores profesores = await db.Profesores.FindAsync(id);
            if (profesores == null)
            {
                return HttpNotFound();
            }
            return View(profesores);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdProfesores,Nombres,Apellidos,Correo")] Profesores profesores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesores).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profesores);
        }

        // GET: Profesores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesores profesores = await db.Profesores.FindAsync(id);
            if (profesores == null)
            {
                return HttpNotFound();
            }
            return View(profesores);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Profesores profesores = await db.Profesores.FindAsync(id);
            db.Profesores.Remove(profesores);
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
