using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Data.Services
{
    public class SizeService : SizeInterface
    {
        private readonly BackEndContext _db;
        public SizeService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Size> GetAllSizes(BackEndContext backEnd)
        {
            return _db.Sizes.ToList();
        }

        public Size GetSizeById(BackEndContext backEnd, long sizeId)
        {
            return _db.Sizes.FirstOrDefault(x => x.SizeId == sizeId);
        }

        public Size CreateNewSize(BackEndContext backEnd,Size size)
        {
            backEnd.Sizes.Add(size);
            backEnd.SaveChanges();
            return GetSizeById(backEnd, size.SizeId);
        }

        public Size UpdateSize(BackEndContext backEnd, Size size)
        {
            backEnd.Sizes.Add(size);
            backEnd.SaveChanges();
            return GetSizeById(backEnd, size.SizeId);
        }

        public bool DeleteSize(BackEndContext backEnd, long sizeId)
        {
            Size size = GetSizeById(backEnd, sizeId);
            backEnd.Sizes.Remove(size);
            backEnd.SaveChanges();
            return true;
        }
    }
}