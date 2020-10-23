using System;

namespace BackEnd.Dtos
{
    public class ItemReadDto
    {               
        public long ItemId { get; set; }
        public long? SizeId { get; set; }
        public long ItemTypeId { get; set; }
        public decimal Price { get; set; }
        public string ItemName { get; set; }
        public virtual SizeReadDto Size { get; set; }
        public virtual ItemTypeReadDto ItemType { get; set; }

    }
}