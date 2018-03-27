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
    public class JobLocationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: JobLocations
        public ActionResult Index()
        {
            return View(db.JobLocations.ToList());
        }

        // GET: JobLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobLocation jobLocation = db.JobLocations.Find(id);
            if (jobLocation == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(jobLocation);
            return View(jobLocation);
        }

        // GET: JobLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,locationName,locationAddress,locationPostalCode,locationPhoneNumber,locationCity")] JobLocation jobLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.JobLocations.Add(jobLocation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
            PopulateDropDownLists(jobLocation);
            return View(jobLocation);
        }

        // GET: JobLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobLocation jobLocation = db.JobLocations.Find(id);
            if (jobLocation == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(jobLocation);
            return View(jobLocation);
        }

        // POST: JobLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,locationName,locationAddress,locationPostalCode,locationPhoneNumber,locationCity")] JobLocation jobLocation, Byte[] RowVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           PopulateDropDownLists(jobLocation);
            return View(jobLocation);
        }

        // GET: JobLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobLocation jobLocation = db.JobLocations.Find(id);
            if (jobLocation == null)
            {
                return HttpNotFound();
            }
            PopulateDropDownLists(jobLocation);
            return View(jobLocation);
        }

        // POST: JobLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobLocation jobLocation = db.JobLocations.Find(id);
            db.JobLocations.Remove(jobLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDropDownLists(JobLocation JobLocation = null)
        {
            ViewBag.JobPostsID = new SelectList(db.JobPosts.OrderBy(o => o.jobName), "ID", "Job name", JobLocation?.JobPosts);
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
