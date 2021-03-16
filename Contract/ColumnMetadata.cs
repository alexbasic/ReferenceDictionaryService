using Common;
using System;

namespace Contract
{
    public class ColumnMetadata
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DataTypeKind DataTypeKind { get; set; }
    }
}