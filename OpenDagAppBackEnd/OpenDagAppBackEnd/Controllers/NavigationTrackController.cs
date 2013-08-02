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
    public class NavigationTrackController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /NavigationTrack/
        public ActionResult Index()
        {
            var navigationtrack = db.NavigationTrack.Include(n => n.Route);
            return View(navigationtrack.ToList());
        }

        //
        // GET: /NavigationTrack/Details/5
        public ActionResult Details(Int32 id)
        {
            NavigationTrack navigationtrack = db.NavigationTrack.Find(id);
            if (navigationtrack == null)
            {
                return HttpNotFound();
            }
            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = new SelectList(db.NavigationRoute, "Id", "Name");
            return View();
        }

        //
        // POST: /NavigationTrack/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NavigationTrack navigationtrack)
        {
            if (ModelState.IsValid)
            {
                db.NavigationTrack.Add(navigationtrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.NavigationRoute, "Id", "Name", navigationtrack.RouteId);
            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Edit/5
        public ActionResult Edit(Int32 id)
        {
            NavigationTrack navigationtrack = db.NavigationTrack.Find(id);
            if (navigationtrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.NavigationRoute, "Id", "Name", navigationtrack.RouteId);
            return View(navigationtrack);
        }

        //
        // POST: /NavigationTrack/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NavigationTrack navigationtrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navigationtrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.NavigationRoute, "Id", "Name", navigationtrack.RouteId);
            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Delete/5
        public ActionResult Delete(Int32 id)
        {
            NavigationTrack navigationtrack = db.NavigationTrack.Find(id);
            if (navigationtrack == null)
            {
                return HttpNotFound();
            }
            return View(navigationtrack);
        }

        //
        // POST: /NavigationTrack/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            NavigationTrack navigationtrack = db.NavigationTrack.Find(id);
            db.NavigationTrack.Remove(navigationtrack);
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
