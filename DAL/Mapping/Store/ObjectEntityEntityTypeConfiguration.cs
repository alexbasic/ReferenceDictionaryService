using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using Model.Constants;
using Model.Store;

namespace DAL.Mapping
{
    public class ObjectEntityEntityTypeConfiguration : ArchiveEntityWithAuditEntityTypeConfiguration<ObjectEntity>
    {
        protected override void Mapping(EntityTypeBuilder<ObjectEntity> builder)
        {
            builder.ToTable(nameof(ObjectEntity), ReferenceDataContext.SchemaName);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.ObjectNameSize)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.DescriptionSize);

            builder.Property(x => x.Guid)
                .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Guid).IsUnique();
        }
    }
}
