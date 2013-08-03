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

namespace OpenDagAppBackEnd.Controllers.Api
{
    public class StudyInformationController : ApiController
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        // GET api/StudyInformation
        public IEnumerable<StudyInformation> GetStudyInformation()
        {
            var studyinformation = db.StudyInformation.Include(s => s.Study);
            return studyinformation.AsEnumerable();
        }

        // GET api/StudyInformation/5
        public StudyInformation GetStudyInformation(Int32 id)
        {
            StudyInformation studyinformation = db.StudyInformation.Find(id);
            if (studyinformation == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return studyinformation;
        }

        // PUT api/StudyInformation/5
        public HttpResponseMessage PutStudyInformation(Int32 id, StudyInformation studyinformation)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != studyinformation.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(studyinformation).State = EntityState.Modified;

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

        // POST api/StudyInformation
        public HttpResponseMessage PostStudyInformation(StudyInformation studyinformation)
        {
            if (ModelState.IsValid)
            {
                db.StudyInformation.Add(studyinformation);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, studyinformation);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = studyinformation.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/StudyInformation/5
        public HttpResponseMessage DeleteStudyInformation(Int32 id)
        {
            StudyInformation studyinformation = db.StudyInformation.Find(id);
            if (studyinformation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.StudyInformation.Remove(studyinformation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, studyinformation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}