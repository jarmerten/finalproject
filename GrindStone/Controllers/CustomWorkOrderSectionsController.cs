using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrindStone.Models;

namespace GrindStone.Controllers
{
    public class CustomWorkOrderSectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomWorkOrderSections
        public ActionResult Index()
        {
            var customWorkOrderSections = db.CustomWorkOrderSections.Include(c => c.ApplicationUser);
            return View(customWorkOrderSections.ToList());
        }

        // GET: CustomWorkOrderSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomWorkOrderSections customWorkOrderSections = db.CustomWorkOrderSections.Find(id);
            if (customWorkOrderSections == null)
            {
                return HttpNotFound();
            }
            return View(customWorkOrderSections);
        }

        // GET: CustomWorkOrderSections/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName");
            return View();
        }

        // POST: CustomWorkOrderSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SectionId,Id,Title")] CustomWorkOrderSections customWorkOrderSections)
        {
            if (ModelState.IsValid)
            {
                db.CustomWorkOrderSections.Add(customWorkOrderSections);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName", customWorkOrderSections.Id);
            return View(customWorkOrderSections);
        }

        // GET: CustomWorkOrderSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomWorkOrderSections customWorkOrderSections = db.CustomWorkOrderSections.Find(id);
            if (customWorkOrderSections == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName", customWorkOrderSections.Id);
            return View(customWorkOrderSections);
        }

        // POST: CustomWorkOrderSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SectionId,Id,Title")] CustomWorkOrderSections customWorkOrderSections)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customWorkOrderSections).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName", customWorkOrderSections.Id);
            return View(customWorkOrderSections);
        }

        // GET: CustomWorkOrderSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomWorkOrderSections customWorkOrderSections = db.CustomWorkOrderSections.Find(id);
            if (customWorkOrderSections == null)
            {
                return HttpNotFound();
            }
            return View(customWorkOrderSections);
        }

        // POST: CustomWorkOrderSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomWorkOrderSections customWorkOrderSections = db.CustomWorkOrderSections.Find(id);
            db.CustomWorkOrderSections.Remove(customWorkOrderSections);
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
