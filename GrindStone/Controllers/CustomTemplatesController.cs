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
    public class CustomTemplatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomTemplates
        public ActionResult Index()
        {
            var customTemplates = db.CustomTemplates.Include(c => c.ApplicationUser);
            return View(customTemplates.ToList());
        }

        // GET: CustomTemplates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomTemplates customTemplates = db.CustomTemplates.Find(id);
            if (customTemplates == null)
            {
                return HttpNotFound();
            }
            return View(customTemplates);
        }

        // GET: CustomTemplates/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName");
            return View();
        }

        // POST: CustomTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemplateId,Id,TemplateName,Location")] CustomTemplates customTemplates)
        {
            if (ModelState.IsValid)
            {
                db.CustomTemplates.Add(customTemplates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName", customTemplates.Id);
            return View(customTemplates);
        }

        // GET: CustomTemplates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomTemplates customTemplates = db.CustomTemplates.Find(id);
            if (customTemplates == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName", customTemplates.Id);
            return View(customTemplates);
        }

        // POST: CustomTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemplateId,Id,TemplateName,Location")] CustomTemplates customTemplates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customTemplates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "BusinessName", customTemplates.Id);
            return View(customTemplates);
        }

        // GET: CustomTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomTemplates customTemplates = db.CustomTemplates.Find(id);
            if (customTemplates == null)
            {
                return HttpNotFound();
            }
            return View(customTemplates);
        }

        // POST: CustomTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomTemplates customTemplates = db.CustomTemplates.Find(id);
            db.CustomTemplates.Remove(customTemplates);
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
