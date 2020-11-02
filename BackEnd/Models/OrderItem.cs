using System;

namespace BackEnd.Models
{
    public class OrderItem
    {               
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public long ItemId { get; set; }        
        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }

    }

}