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
    public class PositionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Positions
        public ActionResult Index()
        {
            var positions = db.Positions.Include(p => p.JobPost).Include(p => p.Position_Qualifications).Include(p => p.Position_Skills);
            return View(positions.ToList());
        }

        // GET: Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            ViewBag.jobID = new SelectList(db.JobPosts, "ID", "jobName");
            ViewBag.qualificationID = new SelectList(db.Position_Qualifications, "qID", "qID");
            ViewBag.skillID = new SelectList(db.Position_Skills, "skillID", "skillID");
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobID,skillID,qualificationID,numberOfPositions")] Position position)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Positions.Add(position);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
          

            ViewBag.jobID = new SelectList(db.JobPosts, "ID", "jobName", position.jobID);
            ViewBag.qualificationID = new SelectList(db.Position_Qualifications, "qID", "qID", position.qualificationID);
            ViewBag.skillID = new SelectList(db.Position_Skills, "skillID", "skillID", position.skillID);
            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobID = new SelectList(db.JobPosts, "ID", "jobName", position.jobID);
            ViewBag.qualificationID = new SelectList(db.Position_Qualifications, "qID", "qID", position.qualificationID);
            ViewBag.skillID = new SelectList(db.Position_Skills, "skillID", "skillID", position.skillID);
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobID,skillID,qualificationID,numberOfPositions")] Position position, Byte[] RowVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobID = new SelectList(db.JobPosts, "ID", "jobName", position.jobID);
            ViewBag.qualificationID = new SelectList(db.Position_Qualifications, "qID", "qID", position.qualificationID);
            ViewBag.skillID = new SelectList(db.Position_Skills, "skillID", "skillID", position.skillID);
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = db.Positions.Find(id);
            db.Positions.Remove(position);
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
