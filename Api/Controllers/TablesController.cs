using Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// Контроллер справочной информации. Возвращает справочную информацию.
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("Tables")]
    public class TablesController : ControllerBase
    {
        private readonly ILogger<TablesController> _logger;
        private readonly IReferenceService _referenceService;

        /// <summary>
        /// Контроллер справочной информации. Возвращает справочную информацию.
        /// </summary>
        public TablesController(ILogger<TablesController> logger, IReferenceService referenceService)
        {
            _logger = logger;
            _referenceService = referenceService;
        }

        /// <summary>
        /// Возвращает метаданные и содержимое справочной таблицы.
        /// </summary>
        /// <param name="name">Наименование таблицы</param>
        /// <param name="startFrom">Дата начала действия таблицы</param>
        /// <param name="take">Вернуть n строк</param>
        /// <param name="skip">Пропустить n строк</param>
        /// <returns>Массив данных таблицы</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ComplexObject), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetTableWithMetadata")]
        public IActionResult GetTableWithMetadata(string name, DateTime? startFrom, int take = 1000, int skip = 0)
        {
            var resultData = _referenceService.GetTable(startFrom ?? DateTime.Now, name, take, skip);
            if (!resultData.ColumnsMetadata.Any()) NotFound();

            return Ok(resultData);
        }

        /// <summary>
        /// Возвращает содержимое справочной таблицы.
        /// </summary>
        /// <param name="name">Наименование таблицы</param>
        /// <param name="startFrom">Дата начала действия таблицы</param>
        /// <param name="take">Вернуть n строк</param>
        /// <param name="skip">Пропустить n строк</param>
        /// <returns>Массив данных таблицы</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IDictionary<string, object>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{name}")]
        public IActionResult Get([FromRoute] string name, DateTime? startFrom, int take = 1000, int skip = 0)
        {
            var resultData = _referenceService.GetJsonTable(startFrom ?? DateTime.Now, name, take, skip);

            if (!resultData.Any()) NotFound();

            return Ok(resultData);
        }
    }
}
