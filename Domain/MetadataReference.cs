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

        public IEnumerable<ObjectEntity> GetObjects(DateTime startFrom /*todo: take, skip*/)
        {
            return _repoFactory.GetRepository<ObjectEntity>().Query.Where(x => !x.IsDeleted && x.StartDate <= startFrom);
        }

        public IEnumerable<AttributeName> GetAttributes(DateTime startFrom, long objectTypeId /*todo: take, skip*/)
        {
            return _repoFactory.GetRepository<AttributeName>().Query
                .Where(x => !x.IsDeleted && x.StartDate <= startFrom && x.ObjectTypeId == objectTypeId);
        }

        public IEnumerable<DataType> GetTypes(DateTime startFrom)
        {
            return _repoFactory.GetRepository<DataType>().Query;
        }
    }
}
