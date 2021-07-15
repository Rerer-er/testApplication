using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pact;
using Microsoft.Extensions.Caching.Memory;
using Entities.Сurrency;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private ILoggerManager _logger;
        private IMemoryCache _memoryCache;
        public WeatherForecastController(ILoggerManager logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            //if (!_memoryCache.TryGetValue("key_currency", out CurrencyConverter model))
            //{
            //    throw new Exception("Ошибка получения данных");
            //}
     
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is an error message from our values controller.");
            return new string[] { $"11" };// {model.EUR}", $"{model.USD}", $"{model.BYN}" };
        }
    }
}
