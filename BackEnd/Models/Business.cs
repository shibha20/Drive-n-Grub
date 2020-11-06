using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Business
    {
             
        public long BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessPassword { get; set; }
        public string PhoneNumber { get; set; } 
        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }

    }
}