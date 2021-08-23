using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.ActionFilters;

namespace TestApplication.Controllers
{

    // todo: Add ValidateShipper
    [Route("shipper")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private readonly IAllModelsActions _modelsActions;

        private readonly IMapper _mapper;

        public ShipperController(ILoggerManager logger, IAllModelsActions modelsActions, IMapper mapper)
        {
            _logger = logger;
            _modelsActions = modelsActions;
            _mapper = mapper;
        }

        // <summary>
        /// Gets the list of all shippers
        /// </summary>
        [HttpGet]  
        public async Task<IActionResult> GetShippers()
        {
            var shippers = await _modelsActions.Shipper.GetAllShippersAsync(false);
            var shipperDto = _mapper.Map<IEnumerable<ReturnShipperDto>>(shippers);
            return Ok(shipperDto);
        }

        /// <summary>
        /// Get a shipper by id
        /// </summary>
        [HttpGet("{id}", Name = "ShipperById")]
        [ServiceFilter(typeof(ValidateShipperExistsAttribute))] 
        public async Task<IActionResult> GetShippers(int id)
        {
            var shipper = await _modelsActions.Shipper.GetShipperAsync(id, false);
            
            var shipperDto = _mapper.Map<ReturnShipperDto>(shipper);
            return Ok(shipperDto);
        }

        /// <summary>
        /// Creating a shipper
        /// </summary>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateShipper([FromBody] CreateShipperDto shipperDto)
        {
            if (shipperDto == null)
            {
                _logger.LogError("ShipperDto object sent from client is null.");
                return BadRequest("ShipperDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ShipperDto object");
                return UnprocessableEntity(ModelState);
            }
            var shipper = _mapper.Map<Shipper>(shipperDto);
            _modelsActions.Shipper.CreateShipper(shipper);
            await _modelsActions.SaveAsync();

            var returnKind = _mapper.Map<ReturnShipperDto>(shipper);
            return Ok(returnKind);
        }

        /// <summary>
        /// Deleting a product
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            var shipper = await _modelsActions.Shipper.GetShipperAsync(id, false);
            if (shipper == null)
            {
                _logger.LogInfo($"Shipper with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _modelsActions.Shipper.DeleteShipper(shipper);
            await _modelsActions.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Updating a product
        /// </summary>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateShipper(int id, [FromBody] UpdateShipperDto shipperDto)
        {
            if (shipperDto == null)
            {
                _logger.LogError("UpdateKindDto object sent from client is null.");
                return BadRequest("UpdateKindDto object is null");
            }
            var shipper = await _modelsActions.Shipper.GetShipperAsync(id, true);
            if (shipper == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(shipperDto, shipper);
            await _modelsActions.SaveAsync();
            return NoContent();
        }
        
        [HttpPost("rating/{id}")]
        //[ServiceFilter(typeof(ValidateProductExistsAttribute))]
        //[Authorize(Roles = "Shipper Administrator")]
        public async Task<IActionResult> PatchShipper(int id,[FromBody] byte Stars)
        {
           
            var shipper = await _modelsActions.Shipper.GetShipperAsync(id, true);
            if (shipper == null)
            {
                _logger.LogInfo($"Kind with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            shipper.SumRating += Stars;
            shipper.CountRating += 1;
            shipper.FinalRating = shipper.SumRating / shipper.CountRating;

            await _modelsActions.SaveAsync();
            return NoContent();
        }


    }
}
