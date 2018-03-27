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
    public class QualificationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Qualifications
        public ActionResult Index()
        {
            var qualifications = db.Qualifications.Include(q => q.Position_Qualifications).Include(q => q.Qualification_Type);
            return View(qualifications.ToList());
        }

        // GET: Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // GET: Qualifications/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Position_Qualifications, "qID", "qID");
            ViewBag.Qualification_Type_ID = new SelectList(db.Qualification_Type, "Qualification_Type_ID", "Qualification_Types");
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Desc,Qualification_Type_ID")] Qualification qualification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Qualifications.Add(qualification);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
           

            ViewBag.ID = new SelectList(db.Position_Qualifications, "qID", "qID", qualification.qualificationID);
            ViewBag.Qualification_Type_ID = new SelectList(db.Qualification_Type, "Qualification_Type_ID", "Qualification_Types", qualification.Qualification_Type_ID);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Position_Qualifications, "qID", "qID", qualification.qualificationID);
            ViewBag.Qualification_Type_ID = new SelectList(db.Qualification_Type, "Qualification_Type_ID", "Qualification_Types", qualification.Qualification_Type_ID);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Desc,Qualification_Type_ID")] Qualification qualification, Byte[] RowVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Position_Qualifications, "qID", "qID", qualification.qualificationID);
            ViewBag.Qualification_Type_ID = new SelectList(db.Qualification_Type, "Qualification_Type_ID", "Qualification_Types", qualification.Qualification_Type_ID);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualification);
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
