using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveMe.API.Models
{
    public class User
    {
        public User()
        {

        }
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        // navigation
        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
    }
}