using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Common;

namespace DAL.Mapping.Common
{
    public abstract class ArchiveEntityWithAuditEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : ArchiveEntityWithAudit
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Author);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.StartDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.EndDate);

            builder.Property(x => x.PreviousEntityId);

            builder.HasIndex(x => x.StartDate);
            builder.HasIndex(x => x.EndDate);
            builder.HasIndex(x => x.IsDeleted);

            Mapping(builder);
        }

        protected abstract void Mapping(EntityTypeBuilder<T> builder);
    }
}
