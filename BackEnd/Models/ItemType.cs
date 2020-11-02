using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class ItemType
    {    
        public ItemType()
        {
            this.Items = new HashSet<Item>();
        }
        public long ItemTypeId { get; set; }           
        public string ItemTypeName { get; set; }
        public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}