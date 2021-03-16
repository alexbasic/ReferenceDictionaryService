using Contract;
using Infrastructure;
using Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class DataTypeDescriptorService : IDataTypeDescriptorService
    {
        private readonly IRepositoryFactory _repoFactory;

        public DataTypeDescriptorService(IRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public IEnumerable<DataTypeDescriptor> Get(int takeCount, int skipCount)
        {
            return _repoFactory.GetRepository<DataType>().Query
                .Select(x => new DataTypeDescriptor
                {
                    Id = x.Id,
                    Name = x.Name,
                    Kind = x.Kind,
                    Description = x.Description
                })
                .Skip(skipCount)
                .Take(takeCount);
        }
    }
}
