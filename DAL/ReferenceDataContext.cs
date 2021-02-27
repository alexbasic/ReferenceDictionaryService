using Microsoft.EntityFrameworkCore;
using Model.FilesStore;
using Model.Store;

namespace DAL
{
    public class ReferenceDataContext : DbContext
    {
        public const string SchemaName = "eav";
        public const string BigObjectSchemaName = "boo";
        public const string AuditSchemaName = "aud";

        public DbSet<AttributeName> Attributes { get; set; }
        public DbSet<ObjectValue> Objects { get; set; }
        public DbSet<ObjectEntity> ObjectEntites { get; set; }
        public DbSet<DataType> DataTypes { get; set; }

        public DbSet<BigObject> BigObjects { get; set; }

        public ReferenceDataContext(DbContextOptions<ReferenceDataContext> options)
        : base(options)
        {
        }
    }
}
