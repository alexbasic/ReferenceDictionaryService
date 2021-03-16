using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("AttributeNameDescriptor")]
    public class AttributeNameDescriptorController : ControllerBase
    {
        private readonly ILogger<AttributeNameDescriptorController> _logger;
        private readonly IAttributeNameDescriptorService _attributeNameDescriptorService;

        public AttributeNameDescriptorController(ILogger<AttributeNameDescriptorController> logger,
            IAttributeNameDescriptorService attributeNameDescriptorService)
        {
            _logger = logger;
            _attributeNameDescriptorService = attributeNameDescriptorService;
        }

        /// <summary>
        /// Возвращает атрибуты(поля) таблицы
        /// </summary>
        /// <param name="startFrom"></param>
        /// <param name="objectTypeId"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<AttributeNameDescriptor> GetObjectTypes(DateTime? startFrom, long objectTypeId, int take = 1000, int skip = 0)
        {
            return _attributeNameDescriptorService.Get(startFrom ?? DateTime.Now, objectTypeId, take, skip);
        }

        [HttpGet]
        [Route("{id}")]
        public AttributeNameDescriptor GetById(long id)
        {
            return _attributeNameDescriptorService.GetById(id);
        }

        [HttpPost]
        public long Create(DateTime startFrom, DateTime endDate, AttributeNameDescriptor objectEntityType)
        {
            return _attributeNameDescriptorService.Add(startFrom, endDate, objectEntityType);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            _attributeNameDescriptorService.Delete(id);
        }
    }
}
