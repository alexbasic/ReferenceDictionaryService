using Model.Common;
using System;

namespace Model.Store
{
    /// <summary>
    /// Описание объекта
    /// </summary>
    public class ObjectEntity : ArchiveEntityWithAudit
    {
        public Guid Guid { get; set; }

        public long ObjectTypeId { get; set; }
        public virtual ObjectEntityType ObjectType { get; set; }
    }
}
