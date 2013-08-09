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
