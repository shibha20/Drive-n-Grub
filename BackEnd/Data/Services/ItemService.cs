using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;

namespace BackEnd.Data.Services
{
    public class ItemService : ItemInterface
    {
        private readonly BackEndContext _db;
        public ItemService(BackEndContext db)
        {
            _db = db;
        }
        public IEnumerable<Item> GetAllItems(BackEndContext backEnd)
        {
            return _db.Items.ToList();
        }

        public Item GetItemById(BackEndContext backEnd, long itemId)
        {
            return _db.Items.FirstOrDefault(x => x.ItemId == itemId);
        }

        public Item CreateNewItem(BackEndContext backEnd,Item item)
        {
            backEnd.Items.Add(item);
            backEnd.SaveChanges();
            return GetItemById(backEnd, item.ItemId);
        }

        public Item UpdateItem(BackEndContext backEnd, Item item)
        {
            backEnd.Items.Add(item);
            backEnd.SaveChanges();
            return GetItemById(backEnd, item.ItemId);
        }

        public bool DeleteItem(BackEndContext backEnd, long itemId)
        {
            Item item = GetItemById(backEnd, itemId);
            backEnd.Items.Remove(item);
            backEnd.SaveChanges();
            return true;
        }

        IEnumerable<Item> ItemInterface.GetItemByItemTypeId(BackEndContext backEnd, long itemTypeId)
        {
            return _db.Items.Where(x => x.ItemTypeId == itemTypeId);
        }
    }
}