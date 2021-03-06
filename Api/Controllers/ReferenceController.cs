using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("Reference")]
    public class ReferenceController : ControllerBase
    {
        private readonly ILogger<ReferenceController> _logger;
        private readonly IReferenceService _referenceService;

        public ReferenceController(ILogger<ReferenceController> logger, IReferenceService referenceService)
        {
            _logger = logger;
             _referenceService = referenceService;
        }

        [HttpGet]
        public string GetTableWithMetadata(string name, DateTime? startFrom)
        {
            var resultData = _referenceService.GetTable(startFrom ?? DateTime.Now, name);
            return Newtonsoft.Json.JsonConvert.SerializeObject(resultData);
        }
    }
}
