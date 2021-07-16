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
    [Route("api/kinds")]
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
        public async Task<IActionResult> GetKinds()
        {
            var kinds = await _modelsActions.Kind.GetAllKindsAsync(false);
            var kindsDto = _mapper.Map<IEnumerable<ReturnKindDto>>(kinds);
            return Ok(kindsDto);
        }

        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetKinds(int id)
        {
            var kind = await _modelsActions.Kind.GetKindAsync(id, false);
            if (kind == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound("Product not found");
            }
            else
            {
                var kindDto = _mapper.Map<ReturnKindDto>(kind);
                return Ok(kindDto);
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateKind([FromBody] CreateKindDto kindDto)
        {
            var kind = _mapper.Map<Kind>(kindDto);
            _modelsActions.Kind.CreateKind(kind);
            await _modelsActions.SaveAsync();

            var returnKind = _mapper.Map<ReturnKindDto>(kind);
            return Ok(returnKind);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteKind(int id)
        {
            var kind = await _modelsActions.Kind.GetKindAsync(id, false);
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _modelsActions.Kind.DeleteKind(kind);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateKind(int id, [FromBody] UpdateKindDto kindDto)
        {

            var kind = await _modelsActions.Kind.GetKindAsync(id, true);
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(kindDto, kind);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
    }
}
