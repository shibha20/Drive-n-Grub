using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface BusinessInterface
    {
        IEnumerable<Business> GetAllBusinesses();
        Business GetBusinessById( long businessId);
        Business CreateNewBusiness(BusinessReadDto business);
        Business UpdateBusiness( BusinessReadDto business);
        bool DeleteBusiness( long businessId);
        Business GetByEmailAndPassword(string email, string password);
    }
}