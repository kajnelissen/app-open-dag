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
    public class StudyController : ApiController
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        // GET api/Study
        public IEnumerable<Study> GetStudy()
        {
            return db.Study.AsEnumerable();
        }

        // GET api/Study/5
        public Study GetStudy(Int32 id)
        {
            Study study = db.Study.Find(id);
            if (study == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return study;
        }

        // PUT api/Study/5
        public HttpResponseMessage PutStudy(Int32 id, Study study)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != study.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(study).State = EntityState.Modified;

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

        // POST api/Study
        public HttpResponseMessage PostStudy(Study study)
        {
            if (ModelState.IsValid)
            {
                db.Study.Add(study);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, study);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = study.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Study/5
        public HttpResponseMessage DeleteStudy(Int32 id)
        {
            Study study = db.Study.Find(id);
            if (study == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Study.Remove(study);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, study);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}