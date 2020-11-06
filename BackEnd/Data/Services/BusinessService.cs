using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Data.Services
{
    public class BusinessService : BusinessInterface
    {
        private readonly BackEndContext _db;
        public BusinessService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Business> GetAllBusinesses()
        {
            return _db.Businesses.ToList();
        }

        public Business GetBusinessById(long businessId)
        {
            return _db.Businesses.FirstOrDefault(x => x.BusinessId == businessId);
        }

        public Business CreateNewBusiness(BusinessReadDto business)
        {
            var newBusiness = new Business{
                UserEntered = "Create Business",
                DateEntered = DateTime.Now
            };
            _db.Businesses.Add(newBusiness);
            _db.SaveChanges();
            business.BusinessId = newBusiness.BusinessId;
            return GetBusinessById(business.BusinessId);
        }

        public Business UpdateBusiness(BusinessReadDto business)
        {
            if(business.BusinessId == 0)
            {
                CreateNewBusiness(business);
            }
            else{
                var updateBusiness = new Business{
                    UserModified = "Update Business",
                    DateModified = DateTime.Now
                };
                _db.Businesses.Add(updateBusiness);
                _db.SaveChanges();
            }
            return GetBusinessById(business.BusinessId);
        }

        public bool DeleteBusiness(long businessId)
        {
            Business business = GetBusinessById(businessId);
            _db.Businesses.Remove(business);
            _db.SaveChanges();
            return true;
        }

        public Business GetByEmailAndPassword(string email, string password)
        {
            return _db.Businesses.FirstOrDefault(x => x.BusinessEmail == email && x.BusinessPassword == password);
        }
    }
}