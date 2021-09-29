using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ActionFilters;

namespace TestApplication.Controllers
{
    [ApiVersion("1.0")]
    [Route("kinds")]
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

        /// <summary>
        /// Gets the list of all kinds
        /// </summary>
        //[HttpGet(Name = "GetKinds"), Authorize]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        public async Task<IActionResult> GetKinds([FromQuery] KindParameters productParameters)
        {
            var kinds = await _modelsActions.Kind.GetAllKindsAsync( productParameters ,false);
            var kindsDto = _mapper.Map<IEnumerable<ReturnKindDto>>(kinds);

            ReturnKindAndCountDto retKinds = new ReturnKindAndCountDto();

            retKinds.KindsDto = kindsDto;
            retKinds.CountPage = kinds.MetaData.TotalPages;
            retKinds.CurrentPage = kinds.MetaData.CurrentPage;


            return Ok(retKinds);
        }

        /// <summary>
        /// Get a kind by id
        /// </summary>
        [HttpGet("{id}")]
        //[ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidateKindExistsAttribute))]
        public async Task<IActionResult> GetKind(int id)
        {
            var kind = await _modelsActions.Kind.GetKindAsync(id, false);
            
            var kindDto = _mapper.Map<ReturnKindDto>(kind);

            return Ok(kindDto);
        }

        /// <summary>
        /// Creating a kind
        /// </summary>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateKind([FromBody] CreateKindDto kindDto)
        {
            var kind = _mapper.Map<Kind>(kindDto);
            _modelsActions.Kind.CreateKind(kind);
            await _modelsActions.SaveAsync();

            var returnKind = _mapper.Map<ReturnKindDto>(kind);
            return Ok(returnKind);
        }

        /// <summary>
        /// Deleting a kind
        /// </summary>
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidateKindExistsAttribute))]
        public async Task<IActionResult> DeleteKind(int id)
        {
            var kind = await _modelsActions.Kind.GetKindAsync(id, false);

            _modelsActions.Kind.DeleteKind(kind);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Updating a kind
        /// </summary>
        [ServiceFilter(typeof(ValidateKindExistsAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        //[ValidateAntiForgeryToken]
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateKind(int id, [FromBody] UpdateKindDto kindDto)
        {

            var kind = await _modelsActions.Kind.GetKindAsync(id, true);
            
            _mapper.Map(kindDto, kind);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
    }
}
