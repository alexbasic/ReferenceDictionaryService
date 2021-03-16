using Contract;
using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IAttributeNameDescriptorService
    {
        long Add(DateTime startFrom, DateTime? endDate, AttributeNameDescriptor attributeName);
        void Delete(long id);
        IEnumerable<AttributeNameDescriptor> Get(DateTime startFrom, long objectTypeId, int takeCount, int skipCount);
        AttributeNameDescriptor GetById(long id);
    }
}