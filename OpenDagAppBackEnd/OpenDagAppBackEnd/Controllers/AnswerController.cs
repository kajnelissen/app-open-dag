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
    public class AnswerController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /Answer/
        public ActionResult Index()
        {
            var answer = db.Answer.Include(a => a.Study);
            return View(answer.ToList());
        }

        //
        // GET: /Answer/Details/5
        public ActionResult Details(Int32 id)
        {
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        //
        // GET: /Answer/Create
        public ActionResult Create()
        {
            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name");
            return View();
        }

        //
        // POST: /Answer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Answer.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name", answer.StudyId);
            return View(answer);
        }

        //
        // GET: /Answer/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name", answer.StudyId);
            return View(answer);
        }

        //
        // POST: /Answer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudyId = new SelectList(db.Study, "Id", "Name", answer.StudyId);
            return View(answer);
        }

        //
        // GET: /Answer/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Answer answer = db.Answer.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        //
        // POST: /Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Answer answer = db.Answer.Find(id);
            db.Answer.Remove(answer);
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
