using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetKinds()
        {
            var kinds = await _modelsActions.Kind.GetAllKindsAsync(false);
            var kindsDto = _mapper.Map<IEnumerable<ReturnKindDto>>(kinds);
            return Ok(kindsDto);
        }
        [HttpGet("{id}", Name = "KindById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var kind = await _modelsActions.Kind.GetKindAsync(id, false);
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
        public async Task<IActionResult> CreateKind([FromBody] CreateKindDto kindDto)
        {
            if (kindDto == null)
            {
                _logger.LogError("KindDto object sent from client is null.");
                return BadRequest("KindDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var kind = _mapper.Map<Kind>(kindDto);
            _modelsActions.Kind.CreateKind(kind);
            await _modelsActions.SaveAsync();

            var returnKind = _mapper.Map<ReturnKindDto>(kind);
            return Ok(returnKind);
        }

        [HttpDelete("{id}")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKind(int id, [FromBody]UpdateKindDto kindDto)
        {
            if (kindDto == null)
            {
                _logger.LogError("UpdateKindDto object sent from client is null.");
                return BadRequest("UpdateKindDto object is null");
            }
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

        //[HttpPatch("{id}")]
        //public async Task<IActionResult> PartiallyUpdateKind(int id, [FromBody]JsonPatchDocument<UpdateKindDto> patchDoc)
        //{
        //    if (patchDoc == null)
        //    {
        //        _logger.LogError("patchDoc object sent from client is null.");
        //        return BadRequest("patchDoc object is null");
        //    }
        //    var kind = await _modelsActions.Kind.GetKindAsync(id, true);
        //    if (kind == null)
        //    {
        //        _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
        //        return NotFound();
        //    }
        //    var kindToPatch = _mapper.Map<UpdateKindDto>(kind);
        //    patchDoc.ApplyTo(kindToPatch);
        //    _mapper.Map(kindToPatch, kind);
        //    await _modelsActions.SaveAsync();
        //    return NoContent();
        //}
    }
}
