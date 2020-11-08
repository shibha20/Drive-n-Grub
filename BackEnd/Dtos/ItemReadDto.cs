using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{
    public class ItemReadDto
    {    
        public ItemReadDto()
        {
            this.OrderItems = new HashSet<OrderItemReadDto>();
        }              
        public long ItemId { get; set; }
        public long? SizeId { get; set; }
        public long ItemTypeId { get; set; }
        public decimal Price { get; set; }
        public string ItemName { get; set; }

        public virtual SizeReadDto Size { get; set; }
        public virtual ICollection<OrderItemReadDto> OrderItems { get; set; }

    }
}