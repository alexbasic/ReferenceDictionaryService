using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using Model.Store;

namespace DAL.Mapping
{
    public class ObjectEntityEntityTypeConfiguration : IEntityTypeConfiguration<ObjectEntity>
    {
        public void Configure(EntityTypeBuilder<ObjectEntity> builder)
        {
            builder.ToTable(nameof(ObjectEntity), ReferenceDataContext.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(2048);
            builder.Property(x => x.Guid);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Guid);
        }
    }
}
