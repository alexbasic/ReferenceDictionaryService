using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("ObjectEntityType")]
    public class ObjectEntityTypeController : ControllerBase
    {
        private readonly ILogger<ObjectEntityTypeController> _logger;
        private readonly IObjectEntityTypeService _objectEntityTypeService;

        public ObjectEntityTypeController(ILogger<ObjectEntityTypeController> logger,
            IObjectEntityTypeService objectEntityTypeService)
        {
            _logger = logger;
            _objectEntityTypeService = objectEntityTypeService;
        }

        /// <summary>
        /// Возвращает типы справочных таблиц
        /// </summary>
        /// <param name="startFrom"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ObjectEntityTypeDescriptor> GetObjectTypes(DateTime? startFrom, int take = 1000, int skip = 0)
        {
            return _objectEntityTypeService.Get(startFrom ?? DateTime.Now, take, skip);
        }

        [HttpGet]
        [Route("{id}")]
        public ObjectEntityTypeDescriptor GetById(long id)
        {
            return _objectEntityTypeService.GetById(id);
        }

        [HttpPost]
        public long Create(DateTime startFrom, DateTime endDate, ObjectEntityTypeDescriptor objectEntityType)
        {
            return _objectEntityTypeService.Add(startFrom, endDate, objectEntityType);
        }

        [HttpDelete]
        public void Delete(long id)
        {
            _objectEntityTypeService.Delete(id);
        }
    }
}
