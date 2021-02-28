using Infrastructure;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class MetadataReference
    {
        private readonly IRepositoryFactory _repoFactory;

        public MetadataReference(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public IEnumerable<ObjectEntity> GetObjects(DateTime startFrom)
        {
            return _repoFactory.GetRepository<ObjectEntity>().Query.Where(x => !x.IsDeleted && x.StartDate >= startFrom);
        }

        public IEnumerable<AttributeName> GetAttributes(DateTime startFrom, long objectTypeId)
        {
            return _repoFactory.GetRepository<AttributeName>().Query
                .Where(x => !x.IsDeleted && x.StartDate >= startFrom && x.ObjectTypeId == objectTypeId);
        }

        public IEnumerable<ObjectValue> GetValues(DateTime startFrom, long objectId, long attributeId)
        {
            return _repoFactory.GetRepository<ObjectValue>().Query
                .Where(x => !x.IsDeleted && x.StartDate >= startFrom && x.ObjectEntityId == objectId && x.AttributeNameId == attributeId);
        }
    }

    public class ReferenceService
    {
        private readonly IRepositoryFactory _repoFactory;

        public ReferenceService(IRepositoryFactory repoFactory)
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
                .OrderBy(x=>x.Id)
                .ToArray();

            var rows = _repoFactory.GetRepository<ObjectValue>().Query
                .Where(x => !x.IsDeleted && x.StartDate >= startFrom &&
                    x.ObjectEntityId == objectTypeId /*&& x.AttributeNameId == attributeId*/)
                .Select(x=> new 
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
