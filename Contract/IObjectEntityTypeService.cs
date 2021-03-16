using Contract;
using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IObjectEntityTypeService
    {
        long Add(DateTime startFrom, DateTime? endDate, ObjectEntityTypeDescriptor objectEntityType);
        void Delete(long id);
        IEnumerable<ObjectEntityTypeDescriptor> Get(DateTime startFrom, int takeCount, int skipCount);
        ObjectEntityTypeDescriptor GetById(long id);
    }
}