using System.Collections.Generic;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface ItemInterface
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(long itemId);
        Item CreateNewItem(ItemReadDto item);
        Item UpdateItem(ItemReadDto item);
        bool DeleteItem(long itemId);
        IEnumerable<Item> GetItemByItemTypeId(long itemTypeId);
  
    }
}