using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface ItemInterface
    {
        IEnumerable<Item> GetAllItems(BackEndContext backEndContext);
        Item GetItemById(BackEndContext backEndContext, long itemId);
        Item CreateNewItem(BackEndContext backEndContext,Item item);
        Item UpdateItem(BackEndContext backEndContext, Item item);
        bool DeleteItem(BackEndContext backEndContext, long itemId);
        IEnumerable<Item> GetItemByItemTypeId(BackEndContext backEndContext, long itemTypeId);
    }
}