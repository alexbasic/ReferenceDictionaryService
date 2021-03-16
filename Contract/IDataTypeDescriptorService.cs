using Contract;
using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IDataTypeDescriptorService
    {
        IEnumerable<DataTypeDescriptor> Get(int takeCount, int skipCount);
    }
}