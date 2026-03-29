using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes
{
    public class StudentInfoHeadersAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.HttpContext.Response.HasStarted)
            {
                context.HttpContext.Response.OnStarting(() =>
                {
                    context.HttpContext.Response.Headers["X-Student-Name"] = "Safiullin Ruslan Ilfatovich";
                    context.HttpContext.Response.Headers["X-Student-Group"] = "PA-01";
                    return Task.CompletedTask;
                });
            }
            base.OnResultExecuting(context);
        }
    }
}
