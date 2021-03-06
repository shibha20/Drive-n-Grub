using System;
using System.Collections.Generic;

namespace BackEnd.Models
{   
    public class StatusType
    {
        public StatusType()
        {
            this.Orders = new HashSet<Order>();
        }
        public long StatusTypeId { get; set; }
        public string StatusTypeName { get; set; }

        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}