using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MoveMe.API.Data;
using MoveMe.API.Models;

namespace MoveMe.API.Controllers
{
    public class JobDetailsController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        // GET: api/JobDetails
        public IHttpActionResult GetJobDetails()
        {
            var resultSet = db.JobDetails.Select(jobDetail => new
            {
                jobDetail.JobDetailId,
                jobDetail.CustomerId,
                jobDetail.FromStreetAddress,
                jobDetail.FromCity,
                jobDetail.FromState,
                jobDetail.FromZip,
                jobDetail.ToStreetAddress,
                jobDetail.ToCity,
                jobDetail.ToState,
                jobDetail.ToZip,
                jobDetail.MovingDay,
                jobDetail.NumBedroom,
                jobDetail.NumPooper,
                jobDetail.SqFeet,
                jobDetail.Stairs,
                jobDetail.Elevator,
                jobDetail.NumMovers,
                jobDetail.NumHours,
                jobDetail.Distance
            });
            return Ok(resultSet);
        }

        // GET: api/JobDetails/5
        [ResponseType(typeof(JobDetail))]
        public IHttpActionResult GetJobDetail(int id)
        {
            JobDetail j = db.JobDetails.Find(id);
            if (j == null)
            {
                return NotFound();
            }

            var jobdetail = db.JobDetails.Find(id);

            var resultSet = 
                new
            {
                jobdetail.JobDetailId,
                jobdetail.CustomerId,
                jobdetail.FromStreetAddress,
                jobdetail.FromCity,
                jobdetail.FromState,
                jobdetail.FromZip,
                jobdetail.ToStreetAddress,
                jobdetail.ToCity,
                jobdetail.ToState,
                jobdetail.ToZip,
                jobdetail.MovingDay,
                jobdetail.NumBedroom,
                jobdetail.NumPooper,
                jobdetail.SqFeet,
                jobdetail.Stairs,
                jobdetail.Elevator,
                jobdetail.NumMovers,
                jobdetail.NumHours,
                jobdetail.Distance
            };
            return Ok(resultSet);
        }

        // PUT: api/JobDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobDetail(int id, JobDetail jobDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobDetail.JobDetailId)
            {
                return BadRequest();
            }

            var dbJobDetail = db.JobDetails.Find(id);
            dbJobDetail.JobDetailId = jobDetail.JobDetailId;
            dbJobDetail.CustomerId = jobDetail.CustomerId;
            dbJobDetail.FromStreetAddress = jobDetail.FromStreetAddress;
            dbJobDetail.FromCity = jobDetail.FromCity;
            dbJobDetail.FromState = jobDetail.FromState;
            dbJobDetail.FromZip = jobDetail.FromZip;
            dbJobDetail.ToStreetAddress = jobDetail.ToStreetAddress;
            dbJobDetail.ToCity = jobDetail.ToCity;
            dbJobDetail.ToState = jobDetail.ToState;
            dbJobDetail.ToZip = jobDetail.ToZip;
            dbJobDetail.MovingDay = jobDetail.MovingDay;
            dbJobDetail.NumBedroom = jobDetail.NumBedroom;
            dbJobDetail.NumPooper = jobDetail.NumPooper;
            dbJobDetail.SqFeet = jobDetail.SqFeet;
            dbJobDetail.Stairs = jobDetail.Stairs;
            dbJobDetail.Elevator = jobDetail.Elevator;
            dbJobDetail.NumMovers = jobDetail.NumMovers;
            dbJobDetail.NumHours = jobDetail.NumHours;
            dbJobDetail.Distance = jobDetail.Distance;

            db.Entry(dbJobDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/JobDetails
        [ResponseType(typeof(JobDetail))]
        public IHttpActionResult PostJobDetail(JobDetail jobDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var geocoder = new Geocoder.GeocodeService();

            var fromLocation = geocoder.GeocodeLocation($"{jobDetail.FromStreetAddress} {jobDetail.FromCity} {jobDetail.FromState} {jobDetail.FromZip}");
            var toLocation = geocoder.GeocodeLocation($"{jobDetail.ToStreetAddress} {jobDetail.ToCity} {jobDetail.ToState} {jobDetail.ToZip}");

            jobDetail.FromLocation = DbGeography.FromText($"POINT({fromLocation.Longitude} {fromLocation.Latitude})");
            jobDetail.ToLocation = DbGeography.FromText($"POINT({toLocation.Longitude} {toLocation.Latitude})");

            db.JobDetails.Add(jobDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobDetail.JobDetailId }, jobDetail);
        }

        // DELETE: api/JobDetails/5
        [ResponseType(typeof(JobDetail))]
        public IHttpActionResult DeleteJobDetail(int id)
        {
            JobDetail jobDetail = db.JobDetails.Find(id);
            if (jobDetail == null)
            {
                return NotFound();
            }

            db.JobDetails.Remove(jobDetail);
            db.SaveChanges();

            var resultSet = new
            {
                jobDetail.JobDetailId,
                jobDetail.CustomerId,
                jobDetail.FromStreetAddress,
                jobDetail.FromCity,
                jobDetail.FromState,
                jobDetail.FromZip,
                jobDetail.ToStreetAddress,
                jobDetail.ToCity,
                jobDetail.ToState,
                jobDetail.ToZip,
                jobDetail.MovingDay,
                jobDetail.NumBedroom,
                jobDetail.NumPooper,
                jobDetail.SqFeet,
                jobDetail.Stairs,
                jobDetail.Elevator,
                jobDetail.NumMovers,
                jobDetail.NumHours,
                jobDetail.Distance
            };
            return Ok(resultSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobDetailExists(int id)
        {
            return db.JobDetails.Count(e => e.JobDetailId == id) > 0;
        }
    }
}