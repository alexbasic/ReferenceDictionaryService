using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("MetadataReference")]
    public class MetadataReferenceController : ControllerBase
    {
        private readonly ILogger<MetadataReferenceController> _logger;
        private readonly IMetadataReference _metadataReferenceService;

        public MetadataReferenceController(ILogger<MetadataReferenceController> logger, 
            IMetadataReference metadataReferenceService)
        {
            _logger = logger;
            _metadataReferenceService = metadataReferenceService;
        }

        [HttpGet]
        [Route("GetTypes")]
        public IEnumerable<DataTypeDescriptor> GetTypes()
        {
            return _metadataReferenceService.GetTypes();
        }

        [HttpGet]
        [Route("GetAttributes")]
        public IEnumerable<AttributeNameDescriptor> GetAttributes(long objectTypeId, DateTime? startFrom)
        {
            return _metadataReferenceService.GetAttributes(startFrom ?? DateTime.Now, objectTypeId);
        }

        [HttpGet]
        [Route("GetObjects")]
        public IEnumerable<ObjectEntityTypeDescriptor> GetObjects(long objectTypeId, DateTime? startFrom)
        {
            return _metadataReferenceService.GetObjectTypes(startFrom ?? DateTime.Now);
        }
    }
}
