using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("DataTypeDescriptor")]
    public class DataTypeDescriptorController : ControllerBase
    {
        private readonly ILogger<DataTypeDescriptorController> _logger;
        private readonly IDataTypeDescriptorService _dataTypeDescriptorService;

        public DataTypeDescriptorController(ILogger<DataTypeDescriptorController> logger,
            IDataTypeDescriptorService objectEntityTypeService)
        {
            _logger = logger;
            _dataTypeDescriptorService = objectEntityTypeService;
        }

        /// <summary>
        /// Возвращает типы данных
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DataTypeDescriptor> Get(int take = 1000, int skip = 0)
        {
            return _dataTypeDescriptorService.Get(take, skip);
        }
    }
}
