using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.ActionFilters
{
    public class ValidateProductExistsAttribute : IActionFilter
    {
        private readonly IAllModelsActions _modelsActions;
        private readonly ILoggerManager _logger;
        private readonly ApplicationContext _context;
        public ValidateProductExistsAttribute(IAllModelsActions allmodelsactions,
       ILoggerManager logger, ApplicationContext context)
        {
            _modelsActions = allmodelsactions;
            _logger = logger;
            _context = context;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var kindId = (int)context.ActionArguments["kindId"];
            var kind = _modelsActions.Kind.GetKind(kindId, trackChanges);
            if (kind == null)
            {
                _logger.LogInfo($"Kind with id: {kindId} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            var id = (int)context.ActionArguments["id"];
            var product = _modelsActions.Product.GetProduct(kindId, id, trackChanges);
            if (kind == null)
            {
                _logger.LogInfo($"Product with id: {kindId} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
