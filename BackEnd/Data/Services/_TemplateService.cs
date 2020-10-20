using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace PointOfSaleSystem.Data.Services
{
    /*
    public class ClassNameService : ClassNameInterface
    {
        private readonly PointOfSaleContext _db;
        public ClassNameService(PointOfSaleContext db)
        {
            _db = db;
        }
        public IEnumerable<ClassName> GetAllClassNames(PointOfSaleContext pointOfSaleContext)
        {
            return _db.ClassNames.ToList();
        }

        public ClassName GetClassNameById(PointOfSaleContext pointOfSaleContext, long classNameId)
        {
            return _db.ClassNames.FirstOrDefault(x => x.ClassNameId == classNameId);
        }

        public ClassName CreateNewClassName(PointOfSaleContext pointOfSaleContext,ClassName className)
        {
            pointOfSaleContext.ClassNames.Add(className);
            pointOfSaleContext.SaveChanges();
            return GetClassNameById(pointOfSaleContext, className.ClassNameId);
        }

        public ClassName UpdateClassName(PointOfSaleContext pointOfSaleContext, ClassName className)
        {
            pointOfSaleContext.ClassNames.Add(className);
            pointOfSaleContext.SaveChanges();
            return GetClassNameById(pointOfSaleContext, className.ClassNameId);
        }

        public bool DeleteClassName(PointOfSaleContext pointOfSaleContext, long classNameId)
        {
            ClassName className = GetClassNameById(pointOfSaleContext, classNameId);
            pointOfSaleContext.ClassNames.Remove(className);
            pointOfSaleContext.SaveChanges();
            return true;
        }
    }
    */
}