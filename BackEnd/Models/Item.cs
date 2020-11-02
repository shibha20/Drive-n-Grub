using System;

namespace BackEnd.Models
{
    public class Item
    {               
        public long ItemId { get; set; }
        public long? SizeId { get; set; }
        public long ItemTypeId { get; set; }
        public decimal Price { get; set; }
        public string ItemName { get; set; }
        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }

        public virtual Size Size { get; set; }
        public virtual ItemType ItemType { get; set; }

    }
}