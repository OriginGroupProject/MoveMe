using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveMe.API.Data;

namespace MoveMe.API.Controllers
{
    public class ResultsController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        [HttpGet, Route("api/results/{id}")]
        public IHttpActionResult GetResults(int id)
        {
            var jobDeets = db.JobDetails
                    .Find(id);
            var DTO = 
                    new
                    {
                        jobDeets.MoveIn,
                        jobDeets.MoveOut,
                        jobDeets.FromLocation,
                        jobDeets.ToLocation,
                        Distance = Math.Round((jobDeets.ToLocation.Distance(jobDeets.FromLocation) ?? 0) / 1609.344, 2)
                    };


            var resultSet = db.Companys
                                .Where(c => c.Radius >= Math.Round((c.Location.Distance(DTO.FromLocation) ?? 0) / 1609.344, 2))
                                .Where(c => c.Radius >= Math.Round((c.Location.Distance(DTO.ToLocation) ?? 0) / 1609.344, 2))
                                .Select(c => new
                                {
                                    c.CompanyId,
                                    c.CompanyName,
                                    c.Telephone,
                                    c.StreetAddress,
                                    c.City,
                                    c.State,
                                    c.Zip,
                                    c.Employees,
                                    c.Radius,
                                    c.OpeningHour,
                                    c.ClosingHour,
                                    c.HourlyRate,
                                    ToDistance = Math.Round((c.Location.Distance(DTO.ToLocation) ?? 0) / 1609.344, 2),
                                    FromDistance = Math.Round((c.Location.Distance(DTO.FromLocation) ?? 0) / 1609.344, 2)
                                });

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
    }
}