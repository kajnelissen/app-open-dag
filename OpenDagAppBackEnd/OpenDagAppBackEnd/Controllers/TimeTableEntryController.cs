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
    public class TimeTableEntryController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /TimeTableEntry/
        public ActionResult Index()
        {
            var timetableentry = db.TimeTableEntry.Include(t => t.TimeTable);
            ViewBag.timeTable = db.TimeTable;
            return View(timetableentry.ToList());
        }

        //
        // GET: /TimeTableEntry/Details/5
        public ActionResult Details(Int32 id)
        {
            TimeTableEntry timetableentry = db.TimeTableEntry.Find(id);

            ViewBag.TimeTable = db.TimeTable.Find(timetableentry.TimeTableId).Date;

            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            return View(timetableentry);
        }

        //
        // GET: /TimeTableEntry/Create
        public ActionResult Create()
        {
            ViewBag.TimeTableId = new SelectList(db.TimeTable, "Id", "Date");
            return View();
        }

        public ActionResult CreateTimeTableEntry()
        {
            List<TimeTable> timeTable = db.TimeTable.ToList();
            ViewBag.TimeTable = timeTable;
            return View();
        }

        //
        // POST: /TimeTableEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeTableEntry timetableentry)
        {

            if (ModelState.IsValid)
            {
                db.TimeTableEntry.Add(timetableentry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TimeTableId = new SelectList(db.TimeTable, "Id", "Id", timetableentry.TimeTableId);
            return View(timetableentry);
        }

        [HttpPost]
        public ActionResult AddActivities(List<TimeTableEntry> timeTableEntries)
        {
            foreach (TimeTableEntry tte in timeTableEntries)
            {
                TimeTable tt = db.TimeTable.Find(tte.TimeTableId);
                if (ModelState.IsValid)
                {
                    DateTime startDateTime = new DateTime(tt.Date.Year, tt.Date.Month, tt.Date.Day, tte.StartTime.TimeOfDay.Hours, tte.StartTime.TimeOfDay.Minutes, tte.StartTime.TimeOfDay.Seconds);
                    DateTime endDateTime = new DateTime(tt.Date.Year, tt.Date.Month, tt.Date.Day, tte.EndTime.TimeOfDay.Hours, tte.EndTime.TimeOfDay.Minutes, tte.EndTime.TimeOfDay.Seconds);
                    if (startDateTime < endDateTime)
                    {
                        tte.StartTime = startDateTime;
                        tte.EndTime = endDateTime;
                        db.TimeTableEntry.Add(tte);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /TimeTableEntry/Edit/5
        public ActionResult Edit(Int32 id)
        {
            TimeTableEntry timetableentry = db.TimeTableEntry.Find(id);

            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimeTableId = new SelectList(db.TimeTable, "Id", "Date", timetableentry.TimeTableId);
  
            return View(timetableentry);
        }

        //
        // POST: /TimeTableEntry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeTableEntry timetableentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetableentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TimeTableId = new SelectList(db.TimeTable, "Id", "Id", timetableentry.TimeTableId);
            return View(timetableentry);
        }

        //
        // GET: /TimeTableEntry/Delete/5
        public ActionResult Delete(Int32 id)
        {
            TimeTableEntry timetableentry = db.TimeTableEntry.Find(id);

            ViewBag.TimeTable = db.TimeTable.Find(timetableentry.TimeTableId).Date;

            if (timetableentry == null)
            {
                return HttpNotFound();
            }
            return View(timetableentry);
        }

        //
        // POST: /TimeTableEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            TimeTableEntry timetableentry = db.TimeTableEntry.Find(id);
            db.TimeTableEntry.Remove(timetableentry);
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
