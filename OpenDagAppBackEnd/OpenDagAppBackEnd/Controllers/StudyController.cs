using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenDagAppBackEnd.Models;

namespace OpenDagAppBackEnd.Controllers
{
    public class StudyController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /Study/
        public ActionResult Index()
        {
            return View(db.Study.ToList());
        }

        //
        // GET: /Study/Details/5
        public ActionResult Details(Int32 id)
        {
            Study study = db.Study.Find(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // GET: /Study/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Study/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Study.Add(study);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(study);
        }

        //
        // GET: /Study/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Study study = db.Study.Find(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // POST: /Study/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Entry(study).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(study);
        }

        //
        // GET: /Study/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Study study = db.Study.Find(id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        //
        // POST: /Study/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Study study = db.Study.Find(id);
            db.Study.Remove(study);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
