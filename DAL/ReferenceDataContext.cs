using Microsoft.EntityFrameworkCore;
using Model;
using Model.Store;
using System;

namespace DAL
{
    public class ReferenceDataContext : DbContext
    {
        public const string SchemaName = "eav";

        public DbSet<AttributeName> Attributes { get; set; }
        public DbSet<ObjectValue> Objects { get; set; }
        public DbSet<ObjectEntity> ObjectEntites { get; set; }
        public DbSet<DataType> DataTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\temp\test_db\reference_db.mdf;Integrated Security=True;Connect Timeout=30");
    }
}
