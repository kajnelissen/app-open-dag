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
    public class TimeTableController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /TimeTable/
        public ActionResult Index()
        {
            return View(db.TimeTable.ToList());
        }

        //
        // GET: /TimeTable/Details/5
        public ActionResult Details(Int32 id)
        {
            TimeTable timetable = db.TimeTable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        //
        // GET: /TimeTable/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /TimeTable/CreateTimeTable
        [HttpPost]
        public ActionResult CreateTimeTable(TimeTable timetable)
        {
            if (timetable.Active)
            {
                List<TimeTable> s = db.TimeTable.Where(l => l.Active == true).ToList();
                if (s.Count == 1)
                {
                    TimeTable timetableActive = s.First();
                    timetableActive.Active = false;
                    db.Entry(timetableActive).State = EntityState.Modified;
                }
            }

            if (ModelState.IsValid)
            {
                db.TimeTable.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timetable);
        }

        //
        // POST: /TimeTable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeTable timetable)
        {
            if (ModelState.IsValid)
            {
                List<TimeTable> s = db.TimeTable.Where(l => l.Active == true).ToList();
                if (s.Count == 1)
                {
                    TimeTable timetableActive = s.First();
                    timetableActive.Active = false;
                    db.Entry(timetableActive).State = EntityState.Modified;
                }

                db.TimeTable.Add(timetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timetable);
        }

        //
        // GET: /TimeTable/Edit/5
        public ActionResult Edit(Int32 id)
        {
            TimeTable timetable = db.TimeTable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        //
        // POST: /TimeTable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeTable timetable)
        {
            if (timetable.Active)
            {
                List<TimeTable> s = db.TimeTable.Where(l => l.Active == true).ToList();
                if (s.Count == 1)
                {
                    TimeTable timetableActive = s.First();
                    timetableActive.Active = false;
                    db.Entry(s).State = EntityState.Modified;
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timetable);
        }

        //
        // GET: /TimeTable/Delete/5
        public ActionResult Delete(Int32 id)
        {
            TimeTable timetable = db.TimeTable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        //
        // POST: /TimeTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            TimeTable timetable = db.TimeTable.Find(id);
            db.TimeTable.Remove(timetable);
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
