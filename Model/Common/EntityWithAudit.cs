using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public abstract class EntityWithAudit : Entity
    {
        public Guid Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
