using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Customer
    {              
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public bool IsGuest { get; set; }
        public string PhoneNumber { get; set; }        
        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }

    }

}