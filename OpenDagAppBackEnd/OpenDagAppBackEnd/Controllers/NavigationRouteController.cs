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
    public class NavigationRouteController : Controller
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        //
        // GET: /NavigationRoute/
        public ActionResult Index()
        {
            return View(db.NavigationRoute.ToList());
        }

        //
        // GET: /NavigationRoute/Details/5
        public ActionResult Details(Int32 id)
        {
            NavigationRoute navigationroute = db.NavigationRoute.Find(id);
            if (navigationroute == null)
            {
                return HttpNotFound();
            }
            return View(navigationroute);
        }

        //
        // GET: /NavigationRoute/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NavigationRoute/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NavigationRoute navigationroute)
        {
            if (navigationroute.Active)
            {
                List<NavigationRoute> s = db.NavigationRoute.Where(l => l.Active == true).ToList();
                if (s.Count == 1)
                {
                    NavigationRoute navigationrouteActive = s.First();
                    navigationrouteActive.Active = false;
                    db.Entry(navigationrouteActive).State = EntityState.Modified;
                }
            }

            if (ModelState.IsValid)
            {
                db.NavigationRoute.Add(navigationroute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(navigationroute);
        }

        //
        // GET: /NavigationRoute/Edit/5
        public ActionResult Edit(Int32 id)
        {
            NavigationRoute navigationroute = db.NavigationRoute.Find(id);
            if (navigationroute == null)
            {
                return HttpNotFound();
            }
            return View(navigationroute);
        }

        //
        // POST: /NavigationRoute/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NavigationRoute navigationroute)
        {
            if (navigationroute.Active)
            {
                List<NavigationRoute> s = db.NavigationRoute.Where(l => l.Active == true).ToList();
                if (s.Count == 1)
                {
                    NavigationRoute navigationrouteActive = s.First();
                    navigationrouteActive.Active = false;
                    db.Entry(navigationrouteActive).State = EntityState.Modified;
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(navigationroute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(navigationroute);
        }

        //
        // GET: /NavigationRoute/Delete/5
        public ActionResult Delete(Int32 id)
        {
            NavigationRoute navigationroute = db.NavigationRoute.Find(id);
            if (navigationroute == null)
            {
                return HttpNotFound();
            }
            return View(navigationroute);
        }

        //
        // POST: /NavigationRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Int32 id)
        {
            NavigationRoute navigationroute = db.NavigationRoute.Find(id);
            db.NavigationRoute.Remove(navigationroute);
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
