using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MoveMe.API.Models
{
    public class User : IdentityUser
    {
        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
    }
}