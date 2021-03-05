namespace Contract
{
    public class AttributeNameDescriptor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long DataTypeId { get; set; }
        public long ObjectTypeId { get; set; }
        public string Description { get; set; }

        public int? MaxSize { get; set; }
        public string DefaultValue { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public bool Nullable { get; set; }
    }
}