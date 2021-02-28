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

            builder.HasOne(x => x.ObjectType)
                .WithMany()
                .HasForeignKey(x => x.ObjectTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Guid).HasDefaultValueSql("newid()");

            builder.HasIndex(x => x.Guid).IsUnique();
            builder.HasIndex(x => x.ObjectTypeId);
        }
    }
}
