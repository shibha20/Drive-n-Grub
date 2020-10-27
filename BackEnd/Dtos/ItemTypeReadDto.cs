using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{
    public class ItemTypeReadDto
    {    
        public ItemTypeReadDto()
        {
            this.Items = new HashSet<ItemReadDto>();
        }
        public long ItemTypeId { get; set; }           
        public string ItemTypeName { get; set; }
        public virtual ICollection<ItemReadDto> Items { get; set; }

    }
}