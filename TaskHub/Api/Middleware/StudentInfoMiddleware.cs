namespace Api.Middleware
{
    public class StudentInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public StudentInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers["X-Student-Name"] = "Safiullin Ruslan Ilfatovich";
            context.Response.Headers["X-Student-Group"] = "PA-01";

            await _next(context);
        }
    }
}
