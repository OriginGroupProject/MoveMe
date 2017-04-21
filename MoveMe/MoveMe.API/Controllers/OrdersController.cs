using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MoveMe.API.Data;
using MoveMe.API.Models;

namespace MoveMe.API.Controllers
{
    public class OrdersController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        // GET: api/Orders
        public IHttpActionResult GetOrders()
        {
            var resultSet = db.Orders.Select(order => new
            {
                order.OrderId,
                order.CustomerId,
                order.CompanyId,
                order.PaymentDetailId,
                order.Rating,
                order.Cost,
                order.Canceled,
                JobDetail = new
                {
                    order.Customer.FirstName
                }
            });
            return Ok(resultSet);
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            var resultSet =  new
            {
                order.OrderId,
                order.CustomerId,
                order.CompanyId,
                order.PaymentDetailId,
                order.Rating,
                order.Cost,
                order.Canceled,
                order.JobDetail
            };
            return Ok(resultSet);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }
            var dbOrder = db.Orders.Find(id);
            dbOrder.OrderId = order.OrderId;
            dbOrder.CustomerId = order.CustomerId;
            dbOrder.CompanyId = order.CompanyId;
            dbOrder.PaymentDetailId = order.PaymentDetailId;
            dbOrder.Rating = order.Rating;
            dbOrder.Cost = order.Cost;
            dbOrder.Canceled = order.Canceled;
            dbOrder.JobDetail = order.JobDetail;

            db.Entry(dbOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder( Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobDetail = db.JobDetails.Find(order.JobDetailId);
            order.JobDetail = jobDetail;

            db.Orders.Add(order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = order.OrderId }, new
            {
                order.OrderId,
                order.CustomerId,
                order.CompanyId,
                order.PaymentDetailId,
                order.Rating,
                order.Cost,
                order.Canceled,
                order.JobDetailId
            });
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            var resultSet = new
            {
                order.OrderId,
                order.CustomerId,
                order.CompanyId,
                order.PaymentDetailId,
                order.Rating,
                order.Cost,
                order.Canceled,
                order.JobDetail
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

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.OrderId == id) > 0;
        }
    }
}