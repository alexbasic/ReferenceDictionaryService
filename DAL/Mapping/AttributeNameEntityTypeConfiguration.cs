using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mapping
{
    public class AttributeNameEntityTypeConfiguration : IEntityTypeConfiguration<AttributeName>
    {
        public void Configure(EntityTypeBuilder<AttributeName> builder)
        {
            builder.ToTable(nameof(AttributeName), ReferenceDataContext.SchemaName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();
            builder.HasOne(x => x.DataType)
                .WithMany()
                .HasForeignKey(x => x.DataTypeId);

            builder.Property(x => x.DefaultValue).HasMaxLength(256);
            builder.Property(x => x.Description).HasMaxLength(2048);
            builder.Property(x => x.MaxSize);
            builder.Property(x => x.MinValue).HasMaxLength(256);
            builder.Property(x => x.MaxValue).HasMaxLength(256);
            builder.Property(x => x.Nullable);

            builder.HasIndex(x => x.Name);
        }
    }
}
