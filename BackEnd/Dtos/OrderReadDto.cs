using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{
    public class OrderReadDto
    {    
        public OrderReadDto()
        {
            this.OrderItems = new HashSet<OrderItemReadDto>();
        }    
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Disount { get; set; }

        public virtual CustomerReadDto Customer { get; set; }
        public virtual ICollection<OrderItemReadDto> OrderItems { get; set; }
    }

}