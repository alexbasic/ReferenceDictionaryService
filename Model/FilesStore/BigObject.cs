using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FilesStore
{
    /// <summary>
    /// Хранилище больших объектов
    /// </summary>
    public class BigObject : ArchiveEntityWithAudit
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public Guid Guid { get; set; }
        public string Description { get; set; }
    }
}
