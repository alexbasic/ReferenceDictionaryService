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
        public DataType DataType { get; set; }

        public long ObjectEntityId { get; set; }
        public ObjectEntity ObjectEntity { get; set; }

        public string Description { get; set; }

        public int? MaxSize { get; set; }
        public string DefaultValue { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public bool Nullable { get; set; }
    }
}
