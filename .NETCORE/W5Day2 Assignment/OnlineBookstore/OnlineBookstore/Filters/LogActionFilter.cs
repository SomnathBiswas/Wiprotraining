using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace OnlineBookstore.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action starting...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action finished.");
        }
    }
}
