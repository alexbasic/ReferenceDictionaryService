using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IReferenceService
    {
        ComplexObject GetTable(DateTime startFrom, string name, int takeCount, int skipCount);
        IEnumerable<IDictionary<string, object>> GetJsonTable(DateTime startFrom, string name, int takeCount, int skipCount);
    }
}