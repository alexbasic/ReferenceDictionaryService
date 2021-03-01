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
                var rf = new ReferenceServiceTest(new TestRepositoryFactory(context));
                var resultData = rf.GetTable(DateTime.Now, "Test");

                var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(resultData);
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
                .FirstOrDefault(x => x.Name.Equals(name) && !x.IsDeleted && x.StartDate <= startFrom)?.Id ?? default(int);
            if (objectTypeId == default(int)) throw new Exception($"Объект {name} отсутствует");

            var attributesTuple = _repoFactory.GetRepository<AttributeName>().Query
                .Where(x => !x.IsDeleted && x.ObjectTypeId == objectTypeId && x.StartDate <= startFrom)
                .OrderBy(x => x.Id)
                .Select(x => new { x.Id, x.Name, x.DataType.Kind })
                .ToArray();
            var attributes = Array.ConvertAll(attributesTuple, x => new ColumnMetadata
            {
                Id = x.Id,
                Name = x.Name,
                DataType = ResolveType(x.Kind)
            });

            var rows = _repoFactory.GetRepository<ObjectValue>().Query
                .Where(x => !x.IsDeleted && x.StartDate <= startFrom &&
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