using AutoMapper;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    [Route("api/kind")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class KindController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        public KindController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper)
        {
            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;

        }
        [HttpGet(Name = "GetKinds"), Authorize]
        public IActionResult GetKinds(int kindId)
        {
            var kinds = _modelsActions.Kind.GetAllKinds();
            var kindsDto = _mapper.Map<IEnumerable<ReturnKindDto>>(kinds);
            return Ok(kindsDto);
        }
        [HttpGet("{id}", Name = "KindById")]
        public IActionResult GetProduct(int id)
        {
            var kind = _modelsActions.Kind.GetKind(id);
            if (kind == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var kindDto = _mapper.Map<ReturnKindDto>(kind);
                return Ok(kindDto);
            }
        }
    }
}
