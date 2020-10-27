using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Data.Services
{
    public class SizeService : SizeInterface
    {
        private readonly BackEndContext _db;
        public SizeService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Size> GetAllSizes()
        {
            return _db.Sizes.ToList();
        }

        public Size GetSizeById(long sizeId)
        {
            return _db.Sizes.FirstOrDefault(x => x.SizeId == sizeId);
        }

        public Size CreateNewSize(SizeReadDto size)
        {
            var newSize = new Size{
                UserEntered = "Create Size",
                DateEntered = DateTime.Now
            };
            _db.Sizes.Add(newSize);
            _db.SaveChanges();
            size.SizeId = newSize.SizeId;
            return GetSizeById(size.SizeId);
        }

        public Size UpdateSize(SizeReadDto size)
        {
            if(size.SizeId == 0)
            {
                CreateNewSize(size);
            }
            else{
                var updateSize = new Size{
                    UserModified = "Update Size",
                    DateModified = DateTime.Now
                };
                _db.Sizes.Add(updateSize);
                _db.SaveChanges();
            }
            return GetSizeById(size.SizeId);
        }

        public bool DeleteSize(long sizeId)
        {
            Size size = GetSizeById(sizeId);
            _db.Sizes.Remove(size);
            _db.SaveChanges();
            return true;
        }
    }
}