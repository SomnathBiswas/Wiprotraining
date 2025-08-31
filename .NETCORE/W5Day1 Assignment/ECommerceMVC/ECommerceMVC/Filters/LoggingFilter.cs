using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
namespace ECommerceMVC.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Executing {Action} with {Arguments}",
                context.ActionDescriptor.DisplayName, context.ActionArguments);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Executed {Action} with result {Result}",
                context.ActionDescriptor.DisplayName, context.Result);
        }
    }
}
