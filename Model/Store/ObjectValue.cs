using System;

namespace Model.Store
{
    public class ObjectValue
    {
        public long Id { get; set; }
        public long ObjectEntityId { get; set; }
        public ObjectEntity Object { get; set; }
        public long AttributeNameId { get; set; }
        public AttributeName Attribute { get; set; }
        public string Value { get; set; }
    }
}
