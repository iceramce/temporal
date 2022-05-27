using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebClientes;

namespace WebClientes.Controllers
{
    public class CLIENTE_CONTACTOSController : Controller
    {
        private CRUD_EJEMPLOEntities db = new CRUD_EJEMPLOEntities();

        // GET: CLIENTE_CONTACTOS
        public ActionResult Index()
        {
            var cLIENTE_CONTACTOS = db.CLIENTE_CONTACTOS.Include(c => c.CLIENTE);
            return View(cLIENTE_CONTACTOS.ToList());
        }

        // GET: CLIENTE_CONTACTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE_CONTACTOS cLIENTE_CONTACTOS = db.CLIENTE_CONTACTOS.Find(id);
            if (cLIENTE_CONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE_CONTACTOS);
        }

        // GET: CLIENTE_CONTACTOS/Create
        public ActionResult Create()
        {
            ViewBag.CLIENTE_ID = new SelectList(db.CLIENTE, "CLIENTE_ID", "NOMBRE_CLIENTE");
            return View();
        }

        // POST: CLIENTE_CONTACTOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CONTACTO_ID,CLIENTE_ID,NUMERO_CONTACTO")] CLIENTE_CONTACTOS cLIENTE_CONTACTOS)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE_CONTACTOS.Add(cLIENTE_CONTACTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLIENTE_ID = new SelectList(db.CLIENTE, "CLIENTE_ID", "NOMBRE_CLIENTE", cLIENTE_CONTACTOS.CLIENTE_ID);
            return View(cLIENTE_CONTACTOS);
        }

        // GET: CLIENTE_CONTACTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE_CONTACTOS cLIENTE_CONTACTOS = db.CLIENTE_CONTACTOS.Find(id);
            if (cLIENTE_CONTACTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLIENTE_ID = new SelectList(db.CLIENTE, "CLIENTE_ID", "NOMBRE_CLIENTE", cLIENTE_CONTACTOS.CLIENTE_ID);
            return View(cLIENTE_CONTACTOS);
        }

        // POST: CLIENTE_CONTACTOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CONTACTO_ID,CLIENTE_ID,NUMERO_CONTACTO")] CLIENTE_CONTACTOS cLIENTE_CONTACTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE_CONTACTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENTE_ID = new SelectList(db.CLIENTE, "CLIENTE_ID", "NOMBRE_CLIENTE", cLIENTE_CONTACTOS.CLIENTE_ID);
            return View(cLIENTE_CONTACTOS);
        }

        // GET: CLIENTE_CONTACTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE_CONTACTOS cLIENTE_CONTACTOS = db.CLIENTE_CONTACTOS.Find(id);
            if (cLIENTE_CONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE_CONTACTOS);
        }

        // POST: CLIENTE_CONTACTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE_CONTACTOS cLIENTE_CONTACTOS = db.CLIENTE_CONTACTOS.Find(id);
            db.CLIENTE_CONTACTOS.Remove(cLIENTE_CONTACTOS);
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
