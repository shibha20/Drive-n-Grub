using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{   
    public class StatusTypeReadDto
    {
        public StatusTypeReadDto()
        {
            this.Orders = new HashSet<OrderReadDto>();
        }
        public long StatusTypeId { get; set; }
        public string StatusTypeName { get; set; }
        public virtual ICollection<OrderReadDto> Orders { get; set; }

    }
}