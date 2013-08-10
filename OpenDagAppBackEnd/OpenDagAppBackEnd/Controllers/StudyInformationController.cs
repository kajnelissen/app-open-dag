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
    public class StudyInformationController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /StudyInformation/
        public ActionResult Index()
        {
            var studyinformation = db.StudyInformation.Include(s => s.Study);
            return View(studyinformation.ToList());
        }

        //
        // GET: /StudyInformation/Details/5
        public ActionResult Details(Int32 id)
        {
            StudyInformation studyinformation = db.StudyInformation.Find(id);
            ViewBag.Study = db.Study.Find(studyinformation.StudyId).Name;
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation/Create
        public ActionResult Create()
        {
            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name");
            return View();
        }

        //
        // POST: /StudyInformation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.StudyInformation.Add(studyinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation/Edit/5
        public ActionResult Edit(Int32 id)
        {
            StudyInformation studyinformation = db.StudyInformation.Find(id);
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // POST: /StudyInformation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name", studyinformation.StudyId);
            return View(studyinformation);
        }

        //
        // GET: /StudyInformation/Delete/5
        public ActionResult Delete(Int32 id)
        {
            StudyInformation studyinformation = db.StudyInformation.Find(id);
            ViewBag.Study = db.Study.Find(studyinformation.StudyId).Name;
            if (studyinformation == null)
            {
                return HttpNotFound();
            }
            return View(studyinformation);
        }

        //
        // POST: /StudyInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            StudyInformation studyinformation = db.StudyInformation.Find(id);
            db.StudyInformation.Remove(studyinformation);
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
