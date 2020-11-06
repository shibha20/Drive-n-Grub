using System;
using System.Collections.Generic;

namespace BackEnd.Dtos
{
    public class BusinessReadDto
    {
             
        public long BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessPassword { get; set; }
        public string PhoneNumber { get; set; } 

    }
}