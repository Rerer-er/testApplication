using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ActionFilters;

namespace TestApplication.Controllers
{
    [ApiVersion("2.0")]
    [Route("kinds")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class KindV2Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        public KindV2Controller(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper)
        {
            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;

        }

        /// <summary>
        /// Gets the list of all kinds
        /// </summary>
        //[HttpGet(Name = "GetKinds"), Authorize]
        [HttpGet]
        public async Task<IActionResult> GetKinds()
        {
            var kinds = await _modelsActions.Kind.GetAllKindsAsync(false);
            var kindsDto = _mapper.Map<IEnumerable<ReturnKindDto>>(kinds);
            return Ok(kindsDto);
        }
    }
}
