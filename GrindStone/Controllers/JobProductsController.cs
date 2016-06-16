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
    public class JobProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobProducts
        public ActionResult Index()
        {
            var jobProducts = db.JobProducts.Include(j => j.Jobs).Include(j => j.Products);
            return View(jobProducts.ToList());
        }

        // GET: JobProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProducts jobProducts = db.JobProducts.Find(id);
            if (jobProducts == null)
            {
                return HttpNotFound();
            }
            return View(jobProducts);
        }

        // GET: JobProducts/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: JobProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobProductID,JobId,ProductId,Quanity,Comments")] JobProducts jobProducts)
        {
            if (ModelState.IsValid)
            {
                db.JobProducts.Add(jobProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Id", jobProducts.JobId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Id", jobProducts.ProductId);
            return View(jobProducts);
        }

        // GET: JobProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProducts jobProducts = db.JobProducts.Find(id);
            if (jobProducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Id", jobProducts.JobId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Id", jobProducts.ProductId);
            return View(jobProducts);
        }

        // POST: JobProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobProductID,JobId,ProductId,Quanity,Comments")] JobProducts jobProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Id", jobProducts.JobId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductID", "Id", jobProducts.ProductId);
            return View(jobProducts);
        }

        // GET: JobProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobProducts jobProducts = db.JobProducts.Find(id);
            if (jobProducts == null)
            {
                return HttpNotFound();
            }
            return View(jobProducts);
        }

        // POST: JobProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobProducts jobProducts = db.JobProducts.Find(id);
            db.JobProducts.Remove(jobProducts);
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
