using System.Collections.Generic;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface ItemTypeInterface
    {
        IEnumerable<ItemType> GetAllItemTypes();
        ItemType GetItemTypeById( long itemTypeId);
        ItemType CreateNewItemType(ItemTypeReadDto itemType);
        ItemType UpdateItemType(ItemTypeReadDto itemType);
        bool DeleteItemType( long itemTypeId);
    }
}