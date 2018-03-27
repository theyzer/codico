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
    public class Position_QualificationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Position_Qualifications
        public ActionResult Index()
        {
            var position_Qualifications = db.Position_Qualifications.Include(p => p.Qualifications);
            return View(position_Qualifications.ToList());
        }

        // GET: Position_Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_Qualifications position_Qualifications = db.Position_Qualifications.Find(id);
            if (position_Qualifications == null)
            {
                return HttpNotFound();
            }
            return View(position_Qualifications);
        }

        // GET: Position_Qualifications/Create
        public ActionResult Create()
        {
            ViewBag.qID = new SelectList(db.Qualifications, "ID", "Desc");
            return View();
        }

        // POST: Position_Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "qID")] Position_Qualifications position_Qualifications)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Position_Qualifications.Add(position_Qualifications);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
           

            ViewBag.qID = new SelectList(db.Qualifications, "ID", "Desc", position_Qualifications.qID);
            return View(position_Qualifications);
        }

        // GET: Position_Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_Qualifications position_Qualifications = db.Position_Qualifications.Find(id);
            if (position_Qualifications == null)
            {
                return HttpNotFound();
            }
            ViewBag.qID = new SelectList(db.Qualifications, "ID", "Desc", position_Qualifications.qID);
            return View(position_Qualifications);
        }

        // POST: Position_Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "qID")] Position_Qualifications position_Qualifications, Byte[] RowVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position_Qualifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.qID = new SelectList(db.Qualifications, "ID", "Desc", position_Qualifications.qID);
            return View(position_Qualifications);
        }

        // GET: Position_Qualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_Qualifications position_Qualifications = db.Position_Qualifications.Find(id);
            if (position_Qualifications == null)
            {
                return HttpNotFound();
            }
            return View(position_Qualifications);
        }

        // POST: Position_Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position_Qualifications position_Qualifications = db.Position_Qualifications.Find(id);
            db.Position_Qualifications.Remove(position_Qualifications);
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
