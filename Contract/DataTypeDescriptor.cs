using Common;

namespace Contract
{
    public class DataTypeDescriptor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DataTypeKind Kind { get; set; }
        public string Description { get; set; }
    }
}