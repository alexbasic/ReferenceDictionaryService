using Contract;
using Infrastructure;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class AttributeNameDescriptorService : IAttributeNameDescriptorService
    {
        private readonly IRepositoryFactory _repoFactory;

        public AttributeNameDescriptorService(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public IEnumerable<AttributeNameDescriptor> Get(DateTime startFrom, long objectTypeId, int takeCount, int skipCount)
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
                })
                .Skip(skipCount)
                .Take(takeCount);
        }

        public long Add(DateTime startFrom, DateTime? endDate, AttributeNameDescriptor attributeName)
        {
            return _repoFactory.GetRepository<AttributeName>()
                .Create(new AttributeName
                {
                    Name = attributeName.Name,
                    StartDate = startFrom,
                    EndDate = endDate,
                    Description = attributeName.Description,
                    DataTypeId = attributeName.DataTypeId,
                    DefaultValue = attributeName.DefaultValue,
                    MaxSize = attributeName.MaxSize,
                    MaxValue = attributeName.MaxValue,
                    MinValue = attributeName.MinValue,
                    Nullable = attributeName.Nullable,
                    ObjectTypeId = attributeName.ObjectTypeId
                });
        }

        public void Delete(long id)
        {
            var repo = _repoFactory.GetRepository<AttributeName>();
            var entity = repo.Query.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (entity == null) throw new Exception($"{nameof(AttributeName)} не найдена.");
            entity.IsDeleted = true;
            repo.Update(entity);
        }
    }
}
