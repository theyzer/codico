using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Qualification_TypeController : Controller
    {
        private Model1 db = new Model1();

        // GET: Qualification_Type
        public ActionResult Index()
        {
            return View(db.Qualification_Type.ToList());
        }

        // GET: Qualification_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification_Type qualification_Type = db.Qualification_Type.Find(id);
            if (qualification_Type == null)
            {
                return HttpNotFound();
            }
            return View(qualification_Type);
        }

        // GET: Qualification_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qualification_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Qualification_Type_ID,Qualification_Types")] Qualification_Type qualification_Type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Qualification_Type.Add(qualification_Type);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }

          
            return View(qualification_Type);
        }

        // GET: Qualification_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification_Type qualification_Type = db.Qualification_Type.Find(id);
            if (qualification_Type == null)
            {
                return HttpNotFound();
            }
            return View(qualification_Type);
        }

        // POST: Qualification_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Qualification_Type_ID,Qualification_Types")] Qualification_Type qualification_Type, Byte[] RowVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qualification_Type);
        }

        // GET: Qualification_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification_Type qualification_Type = db.Qualification_Type.Find(id);
            if (qualification_Type == null)
            {
                return HttpNotFound();
            }
            return View(qualification_Type);
        }

        // POST: Qualification_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification_Type qualification_Type = db.Qualification_Type.Find(id);
            db.Qualification_Type.Remove(qualification_Type);
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
