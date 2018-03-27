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
    public class JobPostsController : Controller
    {
        private Model1 db = new Model1();

        // GET: JobPosts
        public ActionResult Index(string sortOrder, string JobNameSearch, int? jobLocationID, string jobCode)
        {
            PopulateLocationCity();
            PopulateJobCode();
            PopulateSchoolName();
            ViewBag.SchoolSort = String.IsNullOrEmpty(sortOrder) ? "SchoolName Desc" : "";
            ViewBag.JobNameSort = String.IsNullOrEmpty(sortOrder) ? "JobName Desc" : "";
            ViewBag.LocationSort = String.IsNullOrEmpty(sortOrder) ? "LocationCity Desc" : "";
            ViewBag.JobCodeSort = String.IsNullOrEmpty(sortOrder) ? "JobCode Desc" : "";
            var jobPosts = db.JobPosts
                .Include(j => j.JobLocation);

            if (jobLocationID.HasValue)
                jobPosts = jobPosts.Where(p => p.jobLocationID == jobLocationID);
            //Search: Posting Name
            if (!String.IsNullOrEmpty(JobNameSearch))
            {
                jobPosts = jobPosts.Where(j => j.jobName.ToUpper().Contains(JobNameSearch.ToUpper()));
            }
            //Search: Posting Name
            if (!String.IsNullOrEmpty(jobCode))
            {
                jobPosts = jobPosts.Where(j => j.jobCode.ToUpper().Contains(jobCode.ToUpper()));
            }
            //Sorting For fields asc desc 
            switch (sortOrder)
            {
                case "SchoolName Desc":
                    jobPosts = jobPosts
                        .OrderByDescending(j => j.JobLocation.locationName);
                    break;

                case "JobName Desc":
                    jobPosts = jobPosts
                        .OrderByDescending(j => j.jobName);
                    break;

                case "LocationCity Desc":
                    jobPosts = jobPosts
                        .OrderByDescending(j => j.JobLocation.locationCity);
                    break;
                case "JobCode Desc":
                    jobPosts = jobPosts
                        .OrderByDescending(j => j.jobCode);
                    break;

            }

            return View(jobPosts.ToList());

        }
        public ActionResult doIt()
        {
            string message = "Welcome";
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        // GET: JobPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            PopulateLocationCity();
            PopulateSchoolName();
            PopulateJobCode();
            return View(jobPost);
        }

        // GET: JobPosts/Create
        public ActionResult Create()
        {
            PopulateSchoolName();
            ViewBag.termID = new SelectList(db.Terms, "ID", "termDesc");
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,jobName,createdBy,createdDate,postingStart,postingEnd,successfulStart,successfulEnd,jobDescription,jobActive,jobLocationID,termID,skillsID,userID,lastModify,modifyBy,successfulCandidate,jobCode,jobPositionID")] JobPost jobPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.JobPosts.Add(jobPost);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }

            PopulateSchoolName(jobPost);
            ViewBag.termID = new SelectList(db.Terms, "ID", "termDesc", jobPost.termID);
            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.termID = new SelectList(db.Terms, "ID", "termDesc", jobPost.termID);
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,jobName,createdBy,createdDate,postingStart,postingEnd,successfulStart,successfulEnd,jobDescription,jobActive,jobLocationID,termID,skillsID,userID,lastModify,modifyBy,successfulCandidate,jobCode,jobPositionID, RowVersion")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.termID = new SelectList(db.Terms, "ID", "termDesc", jobPost.termID);
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Filter will be by locationCity rather than locationID
        private void PopulateLocationCity(JobPost jobPosts = null)
        {
            var dQuery = (from j in db.JobLocations
                          orderby j.locationCity
                          select j.locationCity).Distinct();
            ViewBag.jobLocationID = new SelectList(dQuery.ToList(), "locationCity");
        }
        //
        private void PopulateJobCode(JobPost jobPosts = null)
        {
            var dQuery = (from j in db.JobPosts
                          orderby j.jobCode
                          select j.jobCode).Distinct();
            ViewBag.jobPostID = new SelectList(dQuery.ToList(), "jobCode");
        }
        //
        private void PopulateSchoolName(JobPost jobPosts = null)
        {
            var dQuery = (from j in db.JobLocations
                          orderby j.locationName, j.locationCity
                          select j);
            ViewBag.JobLocationID = new SelectList(dQuery.ToList(),"ID", "Summary");
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
