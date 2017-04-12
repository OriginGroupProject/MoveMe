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

        [HttpGet, Route("api/customerdash/calendar")]
        public IHttpActionResult GetCharts(int id)
        {
            var resultSet = db.Orders.Where(order => order.CustomerId == id)
                                  .Select(order => new
                                  {
                                      title = order.Company.CompanyName,
                                      start = order.JobDetail.MoveOut,
                                      end = order.JobDetail.MoveIn,
                                      //url = "https://moveme.io/!#/orders/detail/" + order.OrderId
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