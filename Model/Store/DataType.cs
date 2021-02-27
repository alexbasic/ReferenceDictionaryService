using Model.Common;

namespace Model.Store
{
    /// <summary>
    /// Описание метаданных-типов
    /// </summary>
    public class DataType : ArchiveEntityWithAudit
    {
        public string Name { get; set; }
        public string Mapping { get; set; }
        public string Description { get; set; }
    }
}
