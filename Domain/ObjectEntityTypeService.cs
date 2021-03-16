using Contract;
using Infrastructure;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ObjectEntityTypeService : IObjectEntityTypeService
    {
        private readonly IRepositoryFactory _repoFactory;

        public ObjectEntityTypeService(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public IEnumerable<ObjectEntityTypeDescriptor> Get(DateTime startFrom, int takeCount, int skipCount)
        {
            return _repoFactory.GetRepository<ObjectEntityType>().Query.Where(x => !x.IsDeleted && x.StartDate <= startFrom)
                .Select(x => new ObjectEntityTypeDescriptor
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .Skip(skipCount)
                .Take(takeCount);
        }

        public long Add(DateTime startFrom, DateTime? endDate, ObjectEntityTypeDescriptor objectEntityType)
        {
            return _repoFactory.GetRepository<ObjectEntityType>()
                .Create(new ObjectEntityType
                {
                    Name = objectEntityType.Name,
                    StartDate = startFrom,
                    EndDate = endDate,
                    Description = objectEntityType.Description
                });
        }

        public void Delete(long id)
        {
            var repo = _repoFactory.GetRepository<ObjectEntityType>();
            var entity = repo.Query.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (entity == null) throw new Exception($"{nameof(ObjectEntityType)} не найдена.");
            entity.IsDeleted = true;
            repo.Update(entity);
        }
    }
}
