using System.Collections.Generic;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface SizeInterface
    {
        IEnumerable<Size> GetAllSizes();
        Size GetSizeById(long sizeId);
        Size CreateNewSize(SizeReadDto size);
        Size UpdateSize(SizeReadDto size);
        bool DeleteSize(long sizeId);
    }
}