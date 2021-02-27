using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using Model.Constants;
using Model.FilesStore;
using Model.Store;

namespace DAL.Mapping
{
    public class ObjectValueEntityTypeConfiguration : ArchiveEntityWithAuditEntityTypeConfiguration<ObjectValue>
    {
        protected override void Mapping(EntityTypeBuilder<ObjectValue> builder)
        {
            builder.ToTable(nameof(ObjectValue), ReferenceDataContext.SchemaName);

            builder.HasOne(x => x.Attribute)
                .WithMany()
                .HasForeignKey(x => x.AttributeNameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Object)
                .WithMany()
                .HasForeignKey(x => x.ObjectEntityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Value)
                .HasMaxLength(Constants.AttributeValueSize)
                .IsRequired();

            builder.HasIndex(x => x.Value);
        }
    }
}
