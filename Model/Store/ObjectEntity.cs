using System;

namespace Model.Store
{
    public class ObjectEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }
    }
}
