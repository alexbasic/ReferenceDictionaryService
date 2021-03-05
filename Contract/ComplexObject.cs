using System.Collections.Generic;

namespace Contract
{
    public class ComplexObject
    {
        public string Name { get; set; }
        public ColumnMetadata[] ColumnsMetadata { get; set; }
        public IEnumerable<DataRow> Rows { get; set; }
    }
}