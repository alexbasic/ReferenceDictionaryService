using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public class EntityWithAudit
    {
        public Guid Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Updated { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
