using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class ValidateCreateTaskRequestFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("request") ||
                context.ActionArguments["request"] == null)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    error = "Тело запроса отсутствует"
                });
                return;
            }

            var request = context.ActionArguments["request"] as CreateTaskRequest;

            if (request.CreatedByUserId == Guid.Empty)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    error = "Идентификатор пользователя не задан"
                });
                return;
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                context.Result = new BadRequestObjectResult(new
                {
                    error = "Название задачи не задано"
                });
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}