using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                                      start = order.JobDetail.MovingDay,
                                      end = order.JobDetail.MovingDay,
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
                            o.JobDetail.MovingDay,
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

		[HttpGet, Route("api/moversdash/revenueChart/{id}")]
		public IHttpActionResult GetRevenueChart(int id)
		{
			var resultSet = db.Orders
							  .GroupBy(o => DbFunctions.TruncateTime(o.JobDetail.MovingDay))
							  .OrderByDescending(o => o.Key)
							  .Take(7)
							  .Select(o => new
							  {
								  X = o.Key,
								  Y = o.Sum(od => od.Cost)
							  });

			return Ok(resultSet);
		}

		[HttpGet, Route("api/moversdash/UtilizationChart/{id}")]
		public IHttpActionResult GetUtilization(int id)
		{
			var company = db.Companys.Find(id);

			var resultSet = db.Orders
							  .GroupBy(o => DbFunctions.TruncateTime(o.JobDetail.MovingDay))
							  .OrderByDescending(o => o.Key)
							  .Take(7)
							  .Select(o => new
							  {
								  X = o.Key,
								  Y = o.Sum(od => od.JobDetail.NumMovers) / company.Employees
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
