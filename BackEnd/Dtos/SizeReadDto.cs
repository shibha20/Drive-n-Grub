using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{   
    public class SizeReadDto
    {
        public SizeReadDto()
        {
            this.Items = new HashSet<ItemReadDto>();
        }
        public long SizeId { get; set; }
        public string SizeName { get; set; }

        public virtual ICollection<ItemReadDto> Items { get; set; }

    }
}
