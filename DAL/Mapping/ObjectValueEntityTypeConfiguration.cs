using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using Model.Store;

namespace DAL.Mapping
{
    public class ObjectValueEntityTypeConfiguration : IEntityTypeConfiguration<ObjectValue>
    {
        public void Configure(EntityTypeBuilder<ObjectValue> builder)
        {
            builder.ToTable(nameof(ObjectValue), ReferenceDataContext.SchemaName);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Attribute)
                .WithMany()
                .HasForeignKey(x => x.AttributeNameId);

            builder.HasOne(x => x.Object)
                .WithMany()
                .HasForeignKey(x => x.ObjectEntityId);

            builder.Property(x => x.Value)
                .HasMaxLength(2048)
                .IsRequired();
        }
    }
}
