using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class StudentInfoHeadersFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Append("X-Student-Name", "Safiullin Ruslan Ilfatovich");
            context.HttpContext.Response.Headers.Append("X-Student-Group", "PA-01");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}