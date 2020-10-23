using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ItemType> GetAllItemTypes(BackEndContext backEnd)
        {
            return _db.ItemTypes.ToList();
        }

        public ItemType GetItemTypeById(BackEndContext backEnd, long itemTypeId)
        {
            return _db.ItemTypes.FirstOrDefault(x => x.ItemTypeId == itemTypeId);
        }

        public ItemType CreateNewItemType(BackEndContext backEnd,ItemType itemType)
        {
            backEnd.ItemTypes.Add(itemType);
            backEnd.SaveChanges();
            return GetItemTypeById(backEnd, itemType.ItemTypeId);
        }

        public ItemType UpdateItemType(BackEndContext backEnd, ItemType itemType)
        {
            backEnd.ItemTypes.Add(itemType);
            backEnd.SaveChanges();
            return GetItemTypeById(backEnd, itemType.ItemTypeId);
        }

        public bool DeleteItemType(BackEndContext backEnd, long itemTypeId)
        {
            ItemType itemType = GetItemTypeById(backEnd, itemTypeId);
            backEnd.ItemTypes.Remove(itemType);
            backEnd.SaveChanges();
            return true;
        }
    }
}