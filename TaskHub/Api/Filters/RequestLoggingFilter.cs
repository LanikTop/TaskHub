using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Filters
{
    public class RequestLoggingFilter : IActionFilter
    {
        private readonly ILogger<RequestLoggingFilter> _logger;
        private Stopwatch _stopwatch = new Stopwatch();

        public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpMethod = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;

            _stopwatch = Stopwatch.StartNew();

            _logger.LogInformation($"Начало выполнения экшена: {httpMethod} {path}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var statusCode = context.HttpContext.Response.StatusCode;
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Завершение экшена: Статус {statusCode}, Время {elapsedMilliseconds} мс");
        }
    }
}
