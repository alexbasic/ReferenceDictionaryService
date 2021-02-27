using Model.Common;

namespace Model.Store
{
    /// <summary>
    /// Хранилище значений атрибутов
    /// </summary>
    public class ObjectValue : ArchiveEntityWithAudit
    {
        public long ObjectEntityId { get; set; }
        public virtual ObjectEntity Object { get; set; }
        public long AttributeNameId { get; set; }
        public virtual AttributeName Attribute { get; set; }
        public string Value { get; set; }
    }
}
