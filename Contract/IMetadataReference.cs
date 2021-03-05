using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IMetadataReference
    {
        IEnumerable<AttributeNameDescriptor> GetAttributes(DateTime startFrom, long objectTypeId);
        IEnumerable<ObjectEntityTypeDescriptor> GetObjectTypes(DateTime startFrom);
        IEnumerable<DataTypeDescriptor> GetTypes();
    }
}