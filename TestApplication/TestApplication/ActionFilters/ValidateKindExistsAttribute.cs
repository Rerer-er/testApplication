using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pact;
using System.Threading.Tasks;

namespace TestApplication.ActionFilters
{
    public class ValidateKindExistsAttribute : IActionFilter
    {
        private readonly IAllModelsActions _modelsActions;
        private readonly ILoggerManager _logger;
        private readonly ApplicationContext _context;
        public ValidateKindExistsAttribute(IAllModelsActions allmodelsactions,
       ILoggerManager logger, ApplicationContext context)
        {
            _modelsActions = allmodelsactions;
            _logger = logger;
            _context = context;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (int)context.ActionArguments["id"];
            var kind = _modelsActions.Kind.GetKindAsync(id, trackChanges);
            if (kind == null)
            {
                _logger.LogInfo($"Object with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
                //context.Result = new BadRequestObjectResult();
            }

        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
