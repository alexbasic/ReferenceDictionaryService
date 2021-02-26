namespace Model.Store
{
    public class AttributeName
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long DataTypeId { get; set; }
        public DataType DataType { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int? MaxSize { get; set; }
        public string DefaultValue { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public bool Nullable { get; set; }
    }
}
