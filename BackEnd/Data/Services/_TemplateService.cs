using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEndSystem.Data.Services
{
    /*
    public class ClassNameService : ClassNameInterface
    {
        private readonly BackEndContext _db;
        public ClassNameService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<ClassName> GetAllClassNames(BackEndContext backEndContext)
        {
            return _db.ClassNames.ToList();
        }

        public ClassName GetClassNameById(BackEndContext backEndContext, long classNameId)
        {
            return _db.ClassNames.FirstOrDefault(x => x.ClassNameId == classNameId);
        }

        public ClassName CreateNewClassName(BackEndContext backEndContext,ClassName className)
        {
            backEndContext.ClassNames.Add(className);
            backEndContext.SaveChanges();
            return GetClassNameById(backEndContext, className.ClassNameId);
        }

        public ClassName UpdateClassName(BackEndContext backEndContext, ClassName className)
        {
            backEndContext.ClassNames.Add(className);
            backEndContext.SaveChanges();
            return GetClassNameById(backEndContext, className.ClassNameId);
        }

        public bool DeleteClassName(BackEndContext backEndContext, long classNameId)
        {
            ClassName className = GetClassNameById(backEndContext, classNameId);
            backEndContext.ClassNames.Remove(className);
            backEndContext.SaveChanges();
            return true;
        }
    }
    */
}