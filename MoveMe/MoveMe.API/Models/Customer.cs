using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MoveMe.API.Models
{
    public class Customer
    {
        public Customer()
        {
            JobDetails = new Collection<JobDetail>();
            Orders = new Collection<Order>();
            PaymentDetails = new Collection<PaymentDetail>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }

        // Navigation

        public virtual User User { get; set; }
        public virtual ICollection<JobDetail> JobDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }

    }
}