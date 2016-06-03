using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrindStone.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace GrindStone.Controllers
{
    public class CustomWorkOrderForJobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // GET: CustomWorkOrderForJobs
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var customWorkOrderForJob = db.CustomWorkOrderForJob.ToList().Where(c => c.Jobs.Id == currentUser);
            return View(customWorkOrderForJob);
        }

        // GET: CustomWorkOrderForJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomWorkOrderForJob customWorkOrderForJob = db.CustomWorkOrderForJob.Find(id);
            if (customWorkOrderForJob == null)
            {
                return HttpNotFound();
            }
            return View(customWorkOrderForJob);
        }

        // GET: CustomWorkOrderForJobs/Create
        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();
            ViewBag.JobId = new SelectList(db.Jobs.Where(c => c.Id == currentUserId), "JobId", "Name");
            return View();
        }

        // POST: CustomWorkOrderForJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobWorkOrderId,JobId,Title,SectionTitle,Description,SectionTitle1,Description1,SectionTitle2,Description2,SectionTitle3,Description3,SectionTitle4,Description4,SectionTitle5,Description5,SectionTitle6,Description6,SectionTitle7,Description7,SectionTitle8,Description8,SectionTitle9,Description9")] CustomWorkOrderForJob customWorkOrderForJob)
        {
            if (ModelState.IsValid)
            {
                customWorkOrderForJob.JobId = 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Id", customWorkOrderForJob.JobId);
            return View(customWorkOrderForJob);
        }

        // GET: CustomWorkOrderForJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomWorkOrderForJob customWorkOrderForJob = db.CustomWorkOrderForJob.Find(id);
            if (customWorkOrderForJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Id", customWorkOrderForJob.JobId);
            return View(customWorkOrderForJob);
        }

        // POST: CustomWorkOrderForJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobWorkOrderId,JobId,Title,SectionTitle,Description,SectionTitle1,Description1,SectionTitle2,Description2,SectionTitle3,Description3,SectionTitle4,Description4,SectionTitle5,Description5,SectionTitle6,Description6,SectionTitle7,Description7,SectionTitle8,Description8,SectionTitle9,Description9")] CustomWorkOrderForJob customWorkOrderForJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customWorkOrderForJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Id", customWorkOrderForJob.JobId);
            return View(customWorkOrderForJob);
        }

        // GET: CustomWorkOrderForJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomWorkOrderForJob customWorkOrderForJob = db.CustomWorkOrderForJob.Find(id);
            if (customWorkOrderForJob == null)
            {
                return HttpNotFound();
            }
            return View(customWorkOrderForJob);
        }

        // POST: CustomWorkOrderForJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomWorkOrderForJob customWorkOrderForJob = db.CustomWorkOrderForJob.Find(id);
            db.CustomWorkOrderForJob.Remove(customWorkOrderForJob);
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
