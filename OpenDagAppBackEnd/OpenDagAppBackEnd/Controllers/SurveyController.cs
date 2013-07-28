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
    public class SurveyController : ApiController
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        // GET api/Survey
        public IEnumerable<Survey> GetSurvey()
        {
            return db.Survey.AsEnumerable();
        }

        // GET api/Survey/5
        public Survey GetSurvey(Int32 id)
        {
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return survey;
        }

        // PUT api/Survey/5
        public HttpResponseMessage PutSurvey(Int32 id, Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != survey.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(survey).State = EntityState.Modified;

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

        // POST api/Survey
        public HttpResponseMessage PostSurvey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Survey.Add(survey);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, survey);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = survey.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Survey/5
        public HttpResponseMessage DeleteSurvey(Int32 id)
        {
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Survey.Remove(survey);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, survey);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}