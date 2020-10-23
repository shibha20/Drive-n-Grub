using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{
    public class CustomerReadDto
    {
             
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public bool IsGuest { get; set; }
        public string PhoneNumber { get; set; }        

    }

}