using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Data;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data.Services
{
    public class ItemTypeService : ItemTypeInterface
    {
        private readonly BackEndContext _db;
        public ItemTypeService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<ItemType> GetAllItemTypes()
        {
            return _db.ItemTypes.ToList();
        }

        public ItemType GetItemTypeById(long itemTypeId)
        {
            return _db.ItemTypes.FirstOrDefault(x => x.ItemTypeId == itemTypeId);
        }

        public ItemType CreateNewItemType(ItemTypeReadDto itemType)
        {
            var newItemType = new ItemType{
                UserEntered = "Create ItemType",
                DateEntered = DateTime.Now
            };
            _db.ItemTypes.Add(newItemType);
            _db.SaveChanges();
            itemType.ItemTypeId = newItemType.ItemTypeId;
            return GetItemTypeById(itemType.ItemTypeId);
        }

        public ItemType UpdateItemType(ItemTypeReadDto itemType)
        {
            if(itemType.ItemTypeId == 0)
            {
                CreateNewItemType(itemType);
            }
            else{
                var updateItemType = new ItemType{
                    UserModified = "Update ItemType",
                    DateModified = DateTime.Now
                };
                _db.ItemTypes.Add(updateItemType);
                _db.SaveChanges();
            }
            return GetItemTypeById(itemType.ItemTypeId);
        }

        public bool DeleteItemType(long itemTypeId)
        {
            ItemType itemType = GetItemTypeById(itemTypeId);
            _db.ItemTypes.Remove(itemType);
            _db.SaveChanges();
            return true;
        }
    }
}