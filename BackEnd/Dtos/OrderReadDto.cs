using System;

namespace BackEnd.Dtos
{
    public class OrderReadDto
    {       
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Disount { get; set; }

        public virtual CustomerReadDto Customer { get; set; }
    }

}