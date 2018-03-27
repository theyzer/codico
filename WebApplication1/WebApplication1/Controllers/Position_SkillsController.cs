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
    public class Position_SkillsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Position_Skills
        public ActionResult Index()
        {
            var position_Skills = db.Position_Skills.Include(p => p.Skill);
            return View(position_Skills.ToList());
        }

        // GET: Position_Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_Skills position_Skills = db.Position_Skills.Find(id);
            if (position_Skills == null)
            {
                return HttpNotFound();
            }
            return View(position_Skills);
        }

        // GET: Position_Skills/Create
        public ActionResult Create()
        {
            ViewBag.skillID = new SelectList(db.Skills, "ID", "ID");
            return View();
        }

        // POST: Position_Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "skillID")] Position_Skills position_Skills)
        {
            try
            {
                {
                    db.Position_Skills.Add(position_Skills);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }
            if (ModelState.IsValid)
            

            ViewBag.skillID = new SelectList(db.Skills, "ID", "ID", position_Skills.skillID);
            return View(position_Skills);
        }

        // GET: Position_Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_Skills position_Skills = db.Position_Skills.Find(id);
            if (position_Skills == null)
            {
                return HttpNotFound();
            }
            ViewBag.skillID = new SelectList(db.Skills, "ID", "ID", position_Skills.skillID);
            return View(position_Skills);
        }

        // POST: Position_Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "skillID")] Position_Skills position_Skills, Byte[] RowVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position_Skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.skillID = new SelectList(db.Skills, "ID", "ID", position_Skills.skillID);
            return View(position_Skills);
        }

        // GET: Position_Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position_Skills position_Skills = db.Position_Skills.Find(id);
            if (position_Skills == null)
            {
                return HttpNotFound();
            }
            return View(position_Skills);
        }

        // POST: Position_Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position_Skills position_Skills = db.Position_Skills.Find(id);
            db.Position_Skills.Remove(position_Skills);
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
