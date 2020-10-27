using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
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
        public IEnumerable<Item> GetAllItems()
        {
            return _db.Items.ToList();
        }

        public Item GetItemById(long itemId)
        {
            return _db.Items.FirstOrDefault(x => x.ItemId == itemId);
        }

        public Item CreateNewItem(ItemReadDto item)
        {
            var newItem = new Item{
                UserEntered = "Create Item",
                DateEntered = DateTime.Now
            };
            _db.Items.Add(newItem);
            _db.SaveChanges();
            item.ItemId = newItem.ItemId;
            return GetItemById(item.ItemId);
        }

        public Item UpdateItem(ItemReadDto item)
        {
            if(item.ItemId == 0)
            {
                CreateNewItem(item);
            }
            else{
                var updateItem = new Item{
                    UserModified = "Update Item",
                    DateModified = DateTime.Now
                };
                _db.Items.Add(updateItem);
                _db.SaveChanges();
            }
            return GetItemById(item.ItemId);
        }

        public bool DeleteItem(long itemId)
        {
            Item item = GetItemById(itemId);
            _db.Items.Remove(item);
            _db.SaveChanges();
            return true;
        }

        IEnumerable<Item> ItemInterface.GetItemByItemTypeId(long itemTypeId)
        {
            return _db.Items.Where(x => x.ItemTypeId == itemTypeId);
        }
    }
}