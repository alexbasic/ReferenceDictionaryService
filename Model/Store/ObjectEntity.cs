using Model.Common;
using System;

namespace Model.Store
{
    /// <summary>
    /// Описание метаданных-объектов
    /// </summary>
    public class ObjectEntity : ArchiveEntityWithAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }
    }
}
