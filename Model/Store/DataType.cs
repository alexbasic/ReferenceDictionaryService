using Infrastructure;
using Model.Common;

namespace Model.Store
{
    /// <summary>
    /// Описание метаданных-типов
    /// </summary>
    public class DataType : Entity
    {
        public string Name { get; set; }
        public DataTypeKind Kind { get; set; }
        public string Description { get; set; }
    }
}
