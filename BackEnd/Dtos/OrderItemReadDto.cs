using System;

namespace BackEnd.Dtos
{
    public class OrderItemReadDto
    {   public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public long ItemId { get; set; }


        public virtual ItemReadDto Item { get; set; }
        public virtual OrderReadDto Order { get; set; }
    }

}