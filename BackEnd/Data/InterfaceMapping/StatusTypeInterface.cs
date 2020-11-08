using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface StatusTypeInterface
    {
        IEnumerable<StatusType> GetAllStatusTypes();
        StatusType GetStatusTypeById( long statusTypeId);
        StatusType CreateNewStatusType(StatusTypeReadDto statusType);
        StatusType UpdateStatusType( StatusTypeReadDto statusType);
        bool DeleteStatusType( long statusTypeId);
    }
}