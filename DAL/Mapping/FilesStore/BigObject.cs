using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Common;
using Model.Constants;
using Model.FilesStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mapping.FilesStore
{
    public class BigObjectEntityTypeConfiguration : ArchiveEntityWithAuditEntityTypeConfiguration<BigObject>
    {
        protected override void Mapping(EntityTypeBuilder<BigObject> builder)
        {
            builder.ToTable(nameof(BigObject), ReferenceDataContext.BigObjectSchemaName);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.BigObjectDataNameSize)
                .IsRequired();

            builder.Property(x => x.Data)
                .HasColumnType($"[varbinary](max)")
                .IsRequired();

            builder.Property(x => x.Guid)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.DescriptionSize)
                .IsRequired();

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Guid);
        }
    }
}
