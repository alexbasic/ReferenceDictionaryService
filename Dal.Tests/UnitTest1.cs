using DAL.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Model.Store;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            using (var context = new InTestReferenceDataContextFactory().CreateDbContext())
            {
                var objectEntityTypeRepo = new Repository<ObjectEntityType>(context);
                var attributeNameRepo = new Repository<AttributeName>(context);
                var objectValueRepo = new Repository<ObjectValue>(context);
            }
            Assert.Pass();
        }
    }

    public class TestRepositoryFactory : IRepositoryFactory
    {
        private readonly DbContext _context;

        public TestRepositoryFactory(DbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetReadOnlyRepository<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return new Repository<T>(_context);
        }
    }

    public class ReferenceServiceTest
    {
        private readonly IRepositoryFactory _repoFactory;

        public ReferenceServiceTest(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public ComplexObject GetTable(DateTime startFrom, string name)
        {
            var objectTypeId = _repoFactory.GetRepository<ObjectEntityType>().Query
                .FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()) && !x.IsDeleted && x.StartDate >= startFrom)?.Id ?? default(int);
            if (objectTypeId == default(int)) throw new Exception($"Объект {name} отсутствует");

            var attributes = _repoFactory.GetRepository<AttributeName>().Query
                .Where(x => !x.IsDeleted && x.ObjectTypeId == objectTypeId && x.StartDate >= startFrom)
                .Select(x => new ColumnMetadata
                {
                    Id = x.Id,
                    Name = x.Name,
                    DataType = ResolveType(x.DataType.Kind)
                })
                .OrderBy(x => x.Id)
                .ToArray();

            var rows = _repoFactory.GetRepository<ObjectValue>().Query
                .Where(x => !x.IsDeleted && x.StartDate >= startFrom &&
                    x.ObjectEntityId == objectTypeId /*&& x.AttributeNameId == attributeId*/)
                .Select(x => new
                {
                    ObjectId = x.ObjectEntityId,
                    AttributeNameId = x.AttributeNameId,
                    Type = x.Attribute.DataType.Kind,
                    AttributeName = x.Attribute.Name,
                    Value = x.Value
                })
                .GroupBy(x => x.ObjectId)
                .ToArray()
                .Select(x =>
                new DataRow
                {
                    Columns = x
                    .OrderBy(y => y.AttributeNameId)
                    .Select(y => Deserialize(y.Type, y.Value))
                    .ToArray()
                });

            return new ComplexObject
            {
                Name = name,
                ColumnsMetadata = attributes,
                Rows = null
            };
        }

        private Type ResolveType(DataTypeKind dataTypeKind)
        {
            switch (dataTypeKind)
            {
                default: return typeof(string);
            }
        }

        private object Deserialize(DataTypeKind dataTypeKind, string value)
        {
            switch (dataTypeKind)
            {
                default: return value;
            }
        }
    }

    public class ComplexObject
    {
        public string Name { get; set; }
        public ColumnMetadata[] ColumnsMetadata { get; set; }
        public IEnumerable<DataRow> Rows { get; set; }
    }

    public class DataRow
    {
        public object[] Columns { get; set; }
    }

    public class ColumnMetadata
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Type DataType { get; set; }
    }
}