using Model.Common;

namespace Model.Store
{
    /// <summary>
    /// Описание матаданных-атрибутов
    /// </summary>
    public class AttributeName : ArchiveEntityWithAudit
    {
        public string Name { get; set; }

        public long DataTypeId { get; set; }
        public virtual DataType DataType { get; set; }

        public long ObjectTypeId { get; set; }
        public virtual ObjectEntityType ObjectType { get; set; }

        public string Description { get; set; }

        public int? MaxSize { get; set; }
        public string DefaultValue { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public bool Nullable { get; set; }
    }
}
