using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveMe.API.Data;

namespace MoveMe.API.Controllers
{
    public class CustomerDashboardController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();
        //for past moves
        [HttpGet, Route("api/customerdash/calendar/{id}")]
        public IHttpActionResult GetCharts(int id)
        {
            var resultSet = db.Orders.Where(order => order.CustomerId == id)
                                  .Select(order => new
                                  {
                                      title = order.Company.CompanyName,
                                      start = order.JobDetail.MovingDay,
                                      end = order.JobDetail.MovingDay,
                                      //url = "https://moveme.io/!#/orders/detail/" + order.OrderId
                                  });

            return Ok(resultSet);
        }
        //for upcoming current move
        [HttpGet, Route("api/customerdash/current/{id}")]
        public IHttpActionResult GetUpcoming(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.CustomerId == id && !o.Canceled && !o.Completed);

            var result = new
            {
                order.Company.CompanyName,
                order.JobDetail.FromStreetAddress,
                order.JobDetail.FromCity,
                order.JobDetail.ToStreetAddress,
                order.JobDetail.ToCity,
                order.JobDetail.MovingDay
            };

            return Ok(result);
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