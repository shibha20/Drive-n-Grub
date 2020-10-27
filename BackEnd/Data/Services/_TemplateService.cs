using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Data;

namespace BackEnd.Data.Services
{
    /*
    public class ClassNameService : ClassNameInterface
    {
        private readonly BackEndContext _db;
        public ClassNameService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<ClassName> GetAllClassNames()
        {
            return _db.ClassNames.ToList();
        }

        public ClassName GetClassNameById(long classNameId)
        {
            return _db.ClassNames.FirstOrDefault(x => x.ClassNameId == classNameId);
        }

        public ClassName CreateNewClassName(ClassNameReadDto className)
        {
            var newClassName = new ClassName{
                UserEntered = "Create ClassName",
                DateEntered = DateTime.Now
            };
            _db.ClassNames.Add(newClassName);
            _db.SaveChanges();
            className.ClassNameId = newClassName.ClassNameId;
            return GetClassNameById(className.ClassNameId);
        }

        public ClassName UpdateClassName(ClassNameReadDto className)
        {
            if(className.ClassNameId == 0)
            {
                CreateNewClassName(className);
            }
            else{
                var updateClassName = new ClassName{
                    UserModified = "Update ClassName",
                    DateModified = DateTime.Now
                };
                _db.ClassNames.Add(updateClassName);
                _db.SaveChanges();
            }
            return GetClassNameById(className.ClassNameId);
        }

        public bool DeleteClassName(long classNameId)
        {
            ClassName className = GetClassNameById(classNameId);
            _db.ClassNames.Remove(className);
            _db.SaveChanges();
            return true;
        }
    }
    */
}