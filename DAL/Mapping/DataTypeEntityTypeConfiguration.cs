using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.Mapping)
                .HasMaxLength(2048)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(512);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Mapping);
        }
    }
}
