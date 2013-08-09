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
    public class QuestionController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /Question/
        public ActionResult Index()
        {
            var question = db.Question.Include(q => q.Survey);
            return View(question.ToList());
        }

        //
        // GET: /Question/Details/5
        public ActionResult Details(Int32 id)
        {
            Question question = db.Question.Find(id);
            ViewBag.SurveyName = db.Survey.Find(question.SurveyId).Name;
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // GET: /Question/Create
        public ActionResult Create()
        {
            ViewBag.SurveyId = new SelectList(db.Survey, "Id", "Name");
            return View();
        }

        //
        // POST: /Question/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Question.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyId = new SelectList(db.Survey, "Id", "Name", question.SurveyId);
            return View(question);
        }

        //
        // GET: /Question/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyId = new SelectList(db.Survey, "Id", "Name", question.SurveyId);
            return View(question);
        }

        //
        // POST: /Question/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyId = new SelectList(db.Survey, "Id", "Name", question.SurveyId);
            return View(question);
        }

        //
        // GET: /Question/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Question question = db.Question.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        //
        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Question question = db.Question.Find(id);
            db.Question.Remove(question);
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
