using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Constants;
using Model.Store;

namespace DAL.Mapping
{
    public class ObjectEntityTypeEntityTypeConfiguration : ArchiveEntityWithAuditEntityTypeConfiguration<ObjectEntityType>
    {
        protected override void Mapping(EntityTypeBuilder<ObjectEntityType> builder)
        {
            builder.ToTable(nameof(ObjectEntityType), ReferenceDataContext.SchemaName);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.ObjectNameSize)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.DescriptionSize);

            builder.HasIndex(x => x.Name);
        }
    }
}
