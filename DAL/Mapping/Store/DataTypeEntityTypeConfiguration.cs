using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Constants;
using Model.Store;

namespace DAL.Mapping
{
    public class DataTypeEntityTypeConfiguration : ArchiveEntityWithAuditEntityTypeConfiguration<DataType>
    {
        protected override void Mapping(EntityTypeBuilder<DataType> builder)
        {
            builder.ToTable(nameof(DataType), ReferenceDataContext.SchemaName);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.DataTypeNameSize)
                .IsRequired();

            builder.Property(x => x.Mapping)
                .HasMaxLength(Constants.DataTypeMappingSize)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.DescriptionSize);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Mapping);
        }
    }
}
