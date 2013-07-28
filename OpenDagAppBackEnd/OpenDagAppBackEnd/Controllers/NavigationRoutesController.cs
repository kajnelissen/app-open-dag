using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using OpenDagAppBackEnd.Models;

namespace OpenDagAppBackEnd.Controllers
{
    public class NavigationRoutesController : ApiController
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        // GET api/NavigationRoutes
        public IEnumerable<NavigationRoute> GetNavigationRoute()
        {
            return db.NavigationRoute.AsEnumerable();
        }

        // GET api/NavigationRoutes/5
        public NavigationRoute GetNavigationRoute(Int32 id)
        {
            NavigationRoute navigationroute = db.NavigationRoute.Find(id);
            if (navigationroute == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return navigationroute;
        }

        // PUT api/NavigationRoutes/5
        public HttpResponseMessage PutNavigationRoute(Int32 id, NavigationRoute navigationroute)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != navigationroute.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(navigationroute).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/NavigationRoutes
        public HttpResponseMessage PostNavigationRoute(NavigationRoute navigationroute)
        {
            if (ModelState.IsValid)
            {
                db.NavigationRoute.Add(navigationroute);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, navigationroute);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = navigationroute.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/NavigationRoutes/5
        public HttpResponseMessage DeleteNavigationRoute(Int32 id)
        {
            NavigationRoute navigationroute = db.NavigationRoute.Find(id);
            if (navigationroute == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.NavigationRoute.Remove(navigationroute);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, navigationroute);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}