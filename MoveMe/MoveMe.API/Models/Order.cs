﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveMe.API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public int PaymentDetailId { get; set; }
        public int? Rating { get; set; }
        public decimal Cost { get; set; }
        public bool Canceled { get; set; }
        public bool Confirmed { get; set; }
        public bool Completed { get; set; }
        
        public int JobDetailId { get; set; }
        
        // Navigation

        public virtual Company Company { get; set; }
        public virtual PaymentDetail PaymentDetail { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual JobDetail JobDetail { get; set; }



    }
}