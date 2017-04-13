using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveMe.API.Data;

namespace MoveMe.API.Controllers
{
    public class MoversDashboardController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        [HttpGet, Route("api/moversdash/calendar/{id}")]
        public IHttpActionResult GetCharts(int id)
        {
            var resultSet = db.Orders.Where(order => order.CompanyId == id)
                                  .Select(order => new
                                  {
                                      title = order.Customer.FirstName + " " +order.Customer.LastName,
                                      start = order.JobDetail.MoveOut,
                                      end = order.JobDetail.MoveIn,
                                      //url = "https://moveme.io/!#/orders/detail/" + order.OrderId
                                  });

            return Ok(resultSet);
        }

        [HttpGet, Route("api/moversdash/jobdetails/{id}")]
        public IHttpActionResult GetJobs(int id)
        {
            var resultSet = db.Orders
                        .Where(o => o.CompanyId == id)
                        .Select(o => new
                        {
                            o.JobDetail.JobDetailId,
                            o.JobDetail.CustomerId,
                            o.JobDetail.FromStreetAddress,
                            o.JobDetail.FromCity,
                            o.JobDetail.FromState,
                            o.JobDetail.FromZip,
                            o.JobDetail.ToStreetAddress,
                            o.JobDetail.ToCity,
                            o.JobDetail.ToState,
                            o.JobDetail.ToZip,
                            o.JobDetail.MoveOut,
                            o.JobDetail.MoveIn,
                            o.JobDetail.NumBedroom,
                            o.JobDetail.NumPooper,
                            o.JobDetail.SqFeet,
                            o.JobDetail.Stairs,
                            o.JobDetail.Elevator,
                            o.JobDetail.NumMovers,
                            o.JobDetail.NumHours,
                            o.JobDetail.Distance
                        });

            return Ok(resultSet);
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
