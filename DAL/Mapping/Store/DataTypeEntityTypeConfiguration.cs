using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Constants;
using Model.Store;

namespace DAL.Mapping
{
    public class DataTypeEntityTypeConfiguration : IEntityTypeConfiguration<DataType>
    {
        public void Configure(EntityTypeBuilder<DataType> builder)
        {
            builder.ToTable(nameof(DataType), ReferenceDataContext.SchemaName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.DataTypeNameSize)
                .IsRequired();

            builder.Property(x => x.Kind);

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.DescriptionSize);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Kind);
        }
    }
}
