using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
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
        public IEnumerable<DataTypeDescriptor> GetTypes()
        {
            return _metadataReferenceService.GetTypes();
        }

        [HttpGet]
        public IEnumerable<AttributeNameDescriptor> GetAttributes(long objectTypeId, DateTime? startFrom)
        {
            return _metadataReferenceService.GetAttributes(startFrom ?? DateTime.Now, objectTypeId);
        }

        [HttpGet]
        public IEnumerable<ObjectEntityTypeDescriptor> GetObjects(long objectTypeId, DateTime? startFrom)
        {
            return _metadataReferenceService.GetObjectTypes(startFrom ?? DateTime.Now);
        }
    }
}
