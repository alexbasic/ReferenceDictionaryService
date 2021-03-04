using Infrastructure;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ReferenceService
    {
        private readonly IRepositoryFactory _repoFactory;

        public ReferenceService(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public ComplexObject GetTable(DateTime startFrom, string name /*todo: take, skip*/)
        {
            var objectTypeId = _repoFactory.GetRepository<ObjectEntityType>().Query
                .FirstOrDefault(x => x.Name.Equals(name) && !x.IsDeleted && x.StartDate <= startFrom)?.Id ?? default(int);
            if (objectTypeId == default(int)) throw new Exception($"Объект {name} отсутствует");

            var attributes = _repoFactory.GetRepository<AttributeName>().Query
                .Where(x => !x.IsDeleted && x.ObjectTypeId == objectTypeId && x.StartDate <= startFrom)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    DataTypeKind = x.DataType.Kind
                })
                .OrderBy(x => x.Id)
                .ToArray()
                .Select(x => new ColumnMetadata
                {
                    Id = x.Id,
                    Name = x.Name,
                    DataType = ResolveType(x.DataTypeKind)
                })
                .ToArray();

            var rows = _repoFactory.GetRepository<ObjectValue>().Query
                .Join(_repoFactory.GetRepository<ObjectEntity>().Query, 
                ok => ok.ObjectEntityId, 
                ik => ik.Id, 
                (o, i) => new { i.Guid, o.ObjectEntityId, o.AttributeNameId, o.Value,
                    ObjectEntityIsDeleted = i.IsDeleted,
                    ObjectValueIsDeleted = o.IsDeleted,
                    ObjectEntityStartDate = i.StartDate,
                    ObjectValueStartDate = o.StartDate,
                })
                .Where(x => !x.ObjectEntityIsDeleted && x.ObjectEntityStartDate <= startFrom && 
                    !x.ObjectValueIsDeleted && x.ObjectValueStartDate <= startFrom)
                .Select(x => new 
                {
                    x.Guid,
                    x.ObjectEntityId,
                    x.AttributeNameId,
                    x.Value,
                })
                .ToArray()
                .GroupBy(x => x.ObjectEntityId)
                .Select((group, index) =>
                new DataRow 
                {
                    Columns = group.Select(y => y.Value).ToArray()
                });

            return new ComplexObject
            {
                Name = name,
                ColumnsMetadata = attributes,
                Rows = rows
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
