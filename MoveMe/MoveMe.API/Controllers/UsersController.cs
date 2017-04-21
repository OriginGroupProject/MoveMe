using MoveMe.API.Data;
using MoveMe.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;

namespace MoveMe.API.Controllers
{
    public class UsersController : ApiController
    {
        private UserManager<User> _userManager;

        public UsersController()
        {
            var db = new MoveMeDataContext();
            var store = new UserStore<User>(db);

            _userManager = new UserManager<User>(store);
        }

        // POST: api/users/register
        [AllowAnonymous]
        [Route("api/users/registerCustomer")]
        public IHttpActionResult RegisterCustomer(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = registration.EmailAddress,
                Customer = new Customer
                {
                    FirstName = registration.FirstName,
                    LastName = registration.LastName
                }
            };

            var result = _userManager.Create(user, registration.Password);

            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, "Customer");
                return Ok();
            }
            else
            {
                return BadRequest("Invalid user registration");
            }
        }

        [AllowAnonymous]
        [Route("api/users/registerMover")]
        public IHttpActionResult RegisterMover(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = registration.EmailAddress,
                Company = new Company
                {
                    CompanyName = registration.CompanyName,
                    StreetAddress = registration.LastName,
                    City = registration.City,
                    State = registration.State,
                    Zip = registration.Zip
                }
            };

            var result = _userManager.Create(user, registration.Password);

            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, "Detailer");
                return Ok();
            }
            else
            {
                return BadRequest("Invalid user registration");
            }
        }
        protected override void Dispose(bool disposing)
        {
            _userManager.Dispose();
        }
    }
}