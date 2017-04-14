using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveMe.API.Data;
using MoveMe.API.Models;

namespace MoveMe.API.Controllers
{
    public class ResultsController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        [HttpGet, Route("api/results")]
        public IHttpActionResult GetResults(JobDetail jobDetail)
        {
            var geocoder = new Geocoder.GeocodeService();
            var fromLocation = geocoder.GeocodeLocation($"{jobDetail.FromStreetAddress} {jobDetail.FromCity} {jobDetail.FromState} {jobDetail.FromZip}");
            var toLocation = geocoder.GeocodeLocation($"{jobDetail.ToStreetAddress} {jobDetail.ToCity} {jobDetail.ToState} {jobDetail.ToZip}");

            jobDetail.FromLocation = DbGeography.FromText($"POINT({fromLocation.Longitude} {fromLocation.Latitude})");
            jobDetail.ToLocation = DbGeography.FromText($"POINT({toLocation.Longitude} {toLocation.Latitude})");
            var DTO = 
                    new
                    {   
                        jobDetail.MovingDay,
                        jobDetail.FromLocation,
                        jobDetail.ToLocation,
                        jobDetail.NumMovers,
                        jobDetail.NumHours,
                        Distance = Math.Round((jobDetail.ToLocation.Distance(jobDetail.FromLocation) ?? 0) / 1609.344, 2)
                    };


            var resultSet = db.Companys
                                
                                // go through list of companies, if c.radius is > distance between company and movingFROM location
                
                                .Where(c => c.Radius >= Math.Round((c.Location.Distance(DTO.FromLocation) ?? 0) / 1609.344, 2))
                                
                                // if c.radius > distance between company and movingTO location
                                
                                .Where(c => c.Radius >= Math.Round((c.Location.Distance(DTO.ToLocation) ?? 0) / 1609.344, 2))
                                
                                // checks whether a company's movers are available on a given day

                                .Where(c => c.Employees - 
                                            c.Orders.Where(o => o.JobDetail.MovingDay >= DTO.MovingDay && o.JobDetail.MovingDay <= (DTO.MovingDay ?? new DateTime()).AddDays(1))
                                                    .Sum(o => o.JobDetail.NumMovers) >= DTO.NumMovers)
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
                                    c.HourlyRate,
                                    Price = DTO.NumMovers * DTO.NumHours * c.HourlyRate + (decimal)(DTO.Distance *  0.8), // andrij approved
                                    //ToDistance = Math.Round((c.Location.Distance(DTO.ToLocation) ?? 0) / 1609.344, 2),
                                    //FromDistance = Math.Round((c.Location.Distance(DTO.FromLocation) ?? 0) / 1609.344, 2)
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