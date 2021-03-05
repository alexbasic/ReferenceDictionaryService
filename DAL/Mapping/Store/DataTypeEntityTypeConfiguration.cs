using Common;
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

            builder.HasData(
                new DataType[] 
                {
                    new DataType { Id = 1, Name = "Байт", Kind = DataTypeKind.Byte },
                    new DataType { Id = 2, Name = "Целое без знака 16 бит", Kind = DataTypeKind.UShort },
                    new DataType { Id = 3, Name = "Целое без знака 32 бита", Kind = DataTypeKind.UInt },
                    new DataType { Id = 4, Name = "Целое без знака 64 бита", Kind = DataTypeKind.ULong },
                    new DataType { Id = 5, Name = "Целое 8 бит", Kind = DataTypeKind.SByte },
                    new DataType { Id = 6, Name = "Целое 16 бит", Kind = DataTypeKind.Short },
                    new DataType { Id = 7, Name = "Целое 32 бита", Kind = DataTypeKind.Int },
                    new DataType { Id = 8, Name = "Целое 64 бита", Kind = DataTypeKind.Long },
                    new DataType { Id = 9, Name = "Десятичное (финансовое)", Kind = DataTypeKind.Decimal },
                    new DataType { Id = 10, Name = "С плавающей запятой", Kind = DataTypeKind.Float },
                    new DataType { Id = 11, Name = "С плавающей запятой двойной точности", Kind = DataTypeKind.Double },
                    new DataType { Id = 12, Name = "Глобальный уникальный идентификатор (GUID)", Kind = DataTypeKind.Guid },
                    new DataType { Id = 13, Name = "Строка", Kind = DataTypeKind.String },
                    new DataType { Id = 14, Name = "Символ", Kind = DataTypeKind.Char },
                    new DataType { Id = 15, Name = "Дата и время", Kind = DataTypeKind.DateTime },
                    new DataType { Id = 16, Name = "Дата, время и часовой пояс", Kind = DataTypeKind.DateTimeOffset }
                });
        }
    }
}
