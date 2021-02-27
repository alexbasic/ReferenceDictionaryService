using DAL.Mapping;
using DAL.Mapping.FilesStore;
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
        public DbSet<ObjectValue> Values { get; set; }
        public DbSet<ObjectEntity> Objects { get; set; }
        public DbSet<ObjectEntityType> ObjectTypes { get; set; }
        public DbSet<DataType> DataTypes { get; set; }

        public DbSet<BigObject> BigObjects { get; set; }
        
        public ReferenceDataContext(DbContextOptions<ReferenceDataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Model.SetDefaultSchema(SchemaName);

            modelBuilder.ApplyConfiguration(new AttributeNameEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DataTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectEntityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectValueEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectEntityTypeEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new BigObjectEntityTypeConfiguration());
        }
    }
}
