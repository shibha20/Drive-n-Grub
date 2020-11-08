using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Data.Services
{
    public class StatusTypeService : StatusTypeInterface
    {
        private readonly BackEndContext _db;
        public StatusTypeService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<StatusType> GetAllStatusTypes()
        {
            return _db.StatusTypes.ToList();
        }

        public StatusType GetStatusTypeById(long statusTypeId)
        {
            return _db.StatusTypes.FirstOrDefault(x => x.StatusTypeId == statusTypeId);
        }

        public StatusType CreateNewStatusType(StatusTypeReadDto statusType)
        {
            var newStatusType = new StatusType{
                UserEntered = "Create StatusType",
                DateEntered = DateTime.Now
            };
            _db.StatusTypes.Add(newStatusType);
            _db.SaveChanges();
            statusType.StatusTypeId = newStatusType.StatusTypeId;
            return GetStatusTypeById(statusType.StatusTypeId);
        }

        public StatusType UpdateStatusType(StatusTypeReadDto statusType)
        {
            if(statusType.StatusTypeId == 0)
            {
                CreateNewStatusType(statusType);
            }
            else{
                var updateStatusType = new StatusType{
                    UserModified = "Update StatusType",
                    DateModified = DateTime.Now
                };
                _db.StatusTypes.Add(updateStatusType);
                _db.SaveChanges();
            }
            return GetStatusTypeById(statusType.StatusTypeId);
        }

        public bool DeleteStatusType(long statusTypeId)
        {
            StatusType statusType = GetStatusTypeById(statusTypeId);
            _db.StatusTypes.Remove(statusType);
            _db.SaveChanges();
            return true;
        }
    }
}