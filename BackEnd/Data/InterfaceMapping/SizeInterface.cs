using System.Collections.Generic;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface SizeInterface
    {
        IEnumerable<Size> GetAllSizes(BackEndContext backEndContext);
        Size GetSizeById(BackEndContext backEndContext, long sizeId);
        Size CreateNewSize(BackEndContext backEndContext,Size size);
        Size UpdateSize(BackEndContext backEndContext, Size size);
        bool DeleteSize(BackEndContext backEndContext, long sizeId);
    }
}