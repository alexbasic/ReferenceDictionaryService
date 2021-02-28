using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eav");

            migrationBuilder.EnsureSchema(
                name: "boo");

            migrationBuilder.CreateTable(
                name: "BigObject",
                schema: "boo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Data = table.Column<byte[]>(type: "[varbinary](max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataType",
                schema: "eav",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectEntityType",
                schema: "eav",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectEntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeName",
                schema: "eav",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DataTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ObjectTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    MaxSize = table.Column<int>(type: "int", nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MaxValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MinValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nullable = table.Column<bool>(type: "bit", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeName_DataType_DataTypeId",
                        column: x => x.DataTypeId,
                        principalSchema: "eav",
                        principalTable: "DataType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttributeName_ObjectEntityType_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalSchema: "eav",
                        principalTable: "ObjectEntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjectEntity",
                schema: "eav",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectEntity_ObjectEntityType_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalSchema: "eav",
                        principalTable: "ObjectEntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjectValue",
                schema: "eav",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectEntityId = table.Column<long>(type: "bigint", nullable: false),
                    AttributeNameId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreviousEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectValue_AttributeName_AttributeNameId",
                        column: x => x.AttributeNameId,
                        principalSchema: "eav",
                        principalTable: "AttributeName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObjectValue_ObjectEntity_ObjectEntityId",
                        column: x => x.ObjectEntityId,
                        principalSchema: "eav",
                        principalTable: "ObjectEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeName_DataTypeId",
                schema: "eav",
                table: "AttributeName",
                column: "DataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeName_EndDate",
                schema: "eav",
                table: "AttributeName",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeName_IsDeleted",
                schema: "eav",
                table: "AttributeName",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeName_Name",
                schema: "eav",
                table: "AttributeName",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeName_ObjectTypeId",
                schema: "eav",
                table: "AttributeName",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeName_StartDate",
                schema: "eav",
                table: "AttributeName",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_BigObject_EndDate",
                schema: "boo",
                table: "BigObject",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_BigObject_Guid",
                schema: "boo",
                table: "BigObject",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BigObject_IsDeleted",
                schema: "boo",
                table: "BigObject",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BigObject_Name",
                schema: "boo",
                table: "BigObject",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BigObject_StartDate",
                schema: "boo",
                table: "BigObject",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_DataType_Kind",
                schema: "eav",
                table: "DataType",
                column: "Kind");

            migrationBuilder.CreateIndex(
                name: "IX_DataType_Name",
                schema: "eav",
                table: "DataType",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntity_EndDate",
                schema: "eav",
                table: "ObjectEntity",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntity_Guid",
                schema: "eav",
                table: "ObjectEntity",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntity_IsDeleted",
                schema: "eav",
                table: "ObjectEntity",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntity_ObjectTypeId",
                schema: "eav",
                table: "ObjectEntity",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntity_StartDate",
                schema: "eav",
                table: "ObjectEntity",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntityType_EndDate",
                schema: "eav",
                table: "ObjectEntityType",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntityType_IsDeleted",
                schema: "eav",
                table: "ObjectEntityType",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntityType_Name",
                schema: "eav",
                table: "ObjectEntityType",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntityType_StartDate",
                schema: "eav",
                table: "ObjectEntityType",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectValue_AttributeNameId",
                schema: "eav",
                table: "ObjectValue",
                column: "AttributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectValue_EndDate",
                schema: "eav",
                table: "ObjectValue",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectValue_IsDeleted",
                schema: "eav",
                table: "ObjectValue",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectValue_ObjectEntityId",
                schema: "eav",
                table: "ObjectValue",
                column: "ObjectEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectValue_StartDate",
                schema: "eav",
                table: "ObjectValue",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectValue_Value",
                schema: "eav",
                table: "ObjectValue",
                column: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BigObject",
                schema: "boo");

            migrationBuilder.DropTable(
                name: "ObjectValue",
                schema: "eav");

            migrationBuilder.DropTable(
                name: "AttributeName",
                schema: "eav");

            migrationBuilder.DropTable(
                name: "ObjectEntity",
                schema: "eav");

            migrationBuilder.DropTable(
                name: "DataType",
                schema: "eav");

            migrationBuilder.DropTable(
                name: "ObjectEntityType",
                schema: "eav");
        }
    }
}
