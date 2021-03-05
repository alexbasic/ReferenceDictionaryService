using Contract;
using Infrastructure;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class MetadataReference : IMetadataReference
    {
        private readonly IRepositoryFactory _repoFactory;

        public MetadataReference(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public IEnumerable<ObjectEntityTypeDescriptor> GetObjectTypes(DateTime startFrom /*todo: take, skip*/)
        {
            return _repoFactory.GetRepository<ObjectEntityType>().Query.Where(x => !x.IsDeleted && x.StartDate <= startFrom)
                .Select(x => new ObjectEntityTypeDescriptor 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                });
        }

        public IEnumerable<AttributeNameDescriptor> GetAttributes(DateTime startFrom, long objectTypeId /*todo: take, skip*/)
        {
            return _repoFactory.GetRepository<AttributeName>().Query
                .Where(x => !x.IsDeleted && x.StartDate <= startFrom && x.ObjectTypeId == objectTypeId)
                .Select(x => new AttributeNameDescriptor
                {
                    Id = x.Id,
                    Name = x.Name,
                    DataTypeId = x.DataTypeId,
                    ObjectTypeId = x.ObjectTypeId,
                    Description = x.Description,
                    Nullable = x.Nullable,
                    DefaultValue = x.DefaultValue,
                    MaxSize = x.MaxSize,
                    MinValue = x.MinValue,
                    MaxValue = x.MaxValue
                });
        }

        public IEnumerable<DataTypeDescriptor> GetTypes()
        {
            return _repoFactory.GetRepository<DataType>().Query
                .Select(x => new DataTypeDescriptor
                {
                    Id = x.Id,
                    Name = x.Name,
                    Kind = x.Kind,
                    Description = x.Description
                });
        }
    }
}
