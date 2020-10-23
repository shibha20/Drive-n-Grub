using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface ItemTypeInterface
    {
        IEnumerable<ItemType> GetAllItemTypes(BackEndContext backEndContext);
        ItemType GetItemTypeById(BackEndContext backEndContext, long itemTypeId);
        ItemType CreateNewItemType(BackEndContext backEndContext,ItemType itemType);
        ItemType UpdateItemType(BackEndContext backEndContext, ItemType itemType);
        bool DeleteItemType(BackEndContext backEndContext, long itemTypeId);
    }
}