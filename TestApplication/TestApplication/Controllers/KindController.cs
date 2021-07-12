using AutoMapper;
using Entities.Models;
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
        //[HttpGet(Name = "GetKinds"), Authorize]
        [HttpGet]
        public IActionResult GetKinds()
        {
            var kinds = _modelsActions.Kind.GetAllKinds(false);
            var kindsDto = _mapper.Map<IEnumerable<ReturnKindDto>>(kinds);
            return Ok(kindsDto);
        }
        [HttpGet("{id}", Name = "KindById")]
        public IActionResult GetProduct(int id)
        {
            var kind = _modelsActions.Kind.GetKind(id, false);
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
        [HttpPost]
        public IActionResult AddKind([FromBody] CreateKindDto kindDto)
        {

            if (kindDto == null)
            {
                _logger.LogError("KindDto object sent from client is null.");
                return BadRequest("KindDto object is null");
            }
            var kind = _mapper.Map<Kind>(kindDto);
            _modelsActions.Kind.CreateKind(kind);
            _modelsActions.Save();

            var returnKind = _mapper.Map<ReturnKindDto>(kind);
            return Ok(returnKind);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKind(int id)
        {
            var kind = _modelsActions.Kind.GetKind(id, false);
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _modelsActions.Kind.DeleteKind(kind);
            _modelsActions.Save();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateKind(int id, [FromBody] UpdateKindDto kindDto)
        {
            if (kindDto == null)
            {
                _logger.LogError("UpdateKindDto object sent from client is null.");
                return BadRequest("UpdateKindDto object is null");
            }
            var kind = _modelsActions.Kind.GetKind(id, true);
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            
            _mapper.Map(kindDto, kind);
            _modelsActions.Save();
            return NoContent();
        }

    }
}
