using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OpenDagAppBackEnd.Models;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

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

            string image = navigationtrack.Image;
            ViewBag.Image = image;

            return View(navigationtrack);
        }

        //
        // GET: /NavigationTrack/Create
        public ActionResult Create()
        {
            ViewBag.RouteId = db.NavigationRoute.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, string routeselect)
        {
            FileUpload f = new FileUpload();

            int fileLength = file.ContentLength;
            byte[] myData = new Byte[fileLength];
            file.InputStream.Read(myData, 0, fileLength);

            

            DateTime r = DateTime.Now;
            string fileName = r.Year.ToString() + r.Month.ToString() + r.Day.ToString() + r.Hour.ToString() + r.Minute.ToString() + r.Second.ToString() + "img-" + file.FileName;
            string url = "\\images\\" + fileName;

            System.IO.FileStream newFile
                = new System.IO.FileStream(Server.MapPath(url),
                                           System.IO.FileMode.Create);
            newFile.Write(myData, 0, myData.Length);
            newFile.Close();

            f.SaveAs(url);
            
            if (file != null)
            {
                byte[] bytes = new byte[file.ContentLength];
                file.InputStream.Read(bytes, 0, Convert.ToInt32(file.ContentLength));
                NavigationTrack navigationtrack = new NavigationTrack();
                int routeId = Convert.ToInt32(routeselect);
                navigationtrack.Route = db.NavigationRoute.Where(x => x.Id == routeId).ToList().First();
                /*string baseString = Convert.ToBase64String(bytes);*/
                navigationtrack.Image = url;
                navigationtrack.FileName = fileName;

                db.NavigationTrack.Add(navigationtrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "NavigationTrack");
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

            //byte[] imageData = Convert.FromBase64String(navigationtrack.Image);
            //System.Drawing.Image image;
            //using (MemoryStream ms = new MemoryStream(imageData))
            //{
            //    image = System.Drawing.Bitmap.FromStream(ms);
            //}
            string image = navigationtrack.Image;
            ViewBag.Image = image;

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
