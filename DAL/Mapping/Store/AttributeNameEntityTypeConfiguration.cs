using DAL.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using Model.Constants;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mapping
{
    public class AttributeNameEntityTypeConfiguration : ArchiveEntityWithAuditEntityTypeConfiguration<AttributeName>
    {
        protected override void Mapping(EntityTypeBuilder<AttributeName> builder)
        {
            builder.ToTable(nameof(AttributeName), ReferenceDataContext.SchemaName);

            builder.Property(x => x.Name)
                .HasMaxLength(Constants.AttributeNameSize)
                .IsRequired();

            builder.HasOne(x => x.DataType)
                .WithMany()
                .HasForeignKey(x => x.DataTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ObjectType)
                .WithMany()
                .HasForeignKey(x => x.ObjectTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.DefaultValue)
                .HasMaxLength(Constants.AttributeDefaultValueSize);

            builder.Property(x => x.Description)
                .HasMaxLength(Constants.DescriptionSize);

            builder.Property(x => x.MaxSize);

            builder.Property(x => x.MinValue)
                .HasMaxLength(Constants.AttributeMinValueSize);

            builder.Property(x => x.MaxValue)
                .HasMaxLength(Constants.AttributeMaxValueSize);

            builder.Property(x => x.Nullable).HasDefaultValue(false);


            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.ObjectTypeId);
        }
    }
}
