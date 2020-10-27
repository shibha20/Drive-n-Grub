using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Order
    {    
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }   
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Disount { get; set; }
        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

}