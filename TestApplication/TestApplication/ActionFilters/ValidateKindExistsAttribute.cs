using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pact;
using System.Threading.Tasks;

namespace TestApplication.ActionFilters
{
    public class ValidateKindExistsAttribute : IAsyncActionFilter
    {
        private readonly IAllModelsActions _modelsActions;
        private readonly ILoggerManager _logger;
        public ValidateKindExistsAttribute(IAllModelsActions allmodelsactions,
       ILoggerManager logger)
        {
            _modelsActions = allmodelsactions;
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
       ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (int)context.ActionArguments["id"];
            var kind = await _modelsActions.Kind.GetKindAsync(id, trackChanges);
            if (kind == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("kind", kind);
                await next();
            }
        }
    }
}
