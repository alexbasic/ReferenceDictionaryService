using System;

namespace Contract
{
    public interface IReferenceService
    {
        ComplexObject GetTable(DateTime startFrom, string name);
    }
}