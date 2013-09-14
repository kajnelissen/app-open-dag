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
    public class SurveyController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /Survey/
        public ActionResult Index()
        {
            return View(db.Survey.ToList());
        }

        //
        // GET: /Survey/Details/5
        public ActionResult Details(Int32 id)
        {
            Survey survey = db.Survey.Find(id);

            if (survey.Questions.Count > 0)
            {
                ViewBag.Questions = db.Question.ToList().Where(a => a.SurveyId == survey.Id);
            }

            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        //
        // GET: /Survey/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Survey/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Survey.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survey);
        }

        //
        // GET: /Survey/Edit/5
        public ActionResult Edit(Int32 id)
        {
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        //
        // POST: /Survey/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        //
        // GET: /Survey/Delete/5
        public ActionResult Delete(Int32 id)
        {
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        //
        // POST: /Survey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            Survey survey = db.Survey.Find(id);
            db.Survey.Remove(survey);
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
