using System;
using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Models
{   
    public class Size
    {
   
        public long SizeId { get; set; }
        public string SizeName { get; set; }

         public DateTime DateEntered { get; set; }
        public string UserEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string UserDeleted { get; set; }
    
    }
}
