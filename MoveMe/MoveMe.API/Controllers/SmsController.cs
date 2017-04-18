using MoveMe.API.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.WebApi;

namespace MoveMe.API.Controllers
{
    public class SmsController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        private string Username = ConfigurationManager.AppSettings["Twilio:Username"];
        private string Password = ConfigurationManager.AppSettings["Twilio:Password"];

        [HttpPost, Route("api/sms/receive")]
        public IHttpActionResult ReceiveText(SmsRequest request)
        {
            TwilioClient.Init(Username, Password);

            try
            { 
                var orderId = int.Parse(request.Body.Split(' ')[1]);
                var order = db.Orders.Find(orderId);

                if (request.Body.Contains("CONFIRM"))
                {
                    order.Confirmed = true;

                    db.Entry(order).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    var message = MessageResource.Create(
                        to: new Twilio.Types.PhoneNumber(order.Company.Telephone),
                        from: new Twilio.Types.PhoneNumber("+16192028377"),
                        body: "Ok, cool! We've confirmed that you're taking this job."
                    );
                }
                else if (request.Body.Contains("CANCEL"))
                {
                    order.Canceled = true;
                }

                return Ok();
            }
            catch (Exception)
            {  
                var message = MessageResource.Create(
                    to: new Twilio.Types.PhoneNumber(request.From),
                    from: new Twilio.Types.PhoneNumber("+16192028377"),
                    body: "Sorry, I couldn't understand your message."
                );

                return Ok();
            }
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
