using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    [Route("api/s")]
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

    }
}
