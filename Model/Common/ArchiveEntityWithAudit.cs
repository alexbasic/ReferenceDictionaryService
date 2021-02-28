using System;

namespace Model.Common
{
    public abstract class ArchiveEntityWithAudit : EntityWithAudit
    {
        public bool IsDeleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? PreviousEntityId { get; set; }
    }
}
