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
    public class TimeTableController : ApiController
    {
        private OpenDagAppBackEndContext db = new OpenDagAppBackEndContext();

        // GET api/TimeTable
        public IEnumerable<TimeTable> GetTimeTable()
        {
            return db.TimeTable.AsEnumerable();
        }

        // GET api/TimeTable/5
        public TimeTable GetTimeTable(Int32 id)
        {
            //TimeTable timetable = db.TimeTable.Find(id);
            TimeTable timetable = db.TimeTable.Where(d => d.Active == true).First();
            if (timetable == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            //List<TimeTableEntry> tb2 = timetable.TimeTableEntries.OrderBy(x => x.StartTime).ToList();
            timetable.TimeTableEntries.OrderBy(x => x.StartTime.TimeOfDay);

            //TimeTable tt = new TimeTable();
            //tt.Active = timetable.Active;
            //tt.Date = timetable.Date;
            //tt.Id = timetable.Id;
            //tt.TimeTableEntries = tb2;

            return timetable;
        }

        // PUT api/TimeTable/5
        public HttpResponseMessage PutTimeTable(Int32 id, TimeTable timetable)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != timetable.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(timetable).State = EntityState.Modified;

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

        // POST api/TimeTable
        public HttpResponseMessage PostTimeTable(TimeTable timetable)
        {
            if (ModelState.IsValid)
            {
                db.TimeTable.Add(timetable);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, timetable);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = timetable.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/TimeTable/5
        public HttpResponseMessage DeleteTimeTable(Int32 id)
        {
            TimeTable timetable = db.TimeTable.Find(id);
            if (timetable == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.TimeTable.Remove(timetable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, timetable);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}