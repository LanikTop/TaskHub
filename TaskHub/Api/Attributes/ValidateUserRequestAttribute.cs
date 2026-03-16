using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Api.Attributes
{
    public class ValidateUserRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("request", out var requestValue) || requestValue == null)
            {
                context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
                return;
            }

            var nameProperty = requestValue.GetType().GetProperty("name", BindingFlags.IgnoreCase);

            if (nameProperty == null)
            {
                context.Result = new BadRequestObjectResult("Имя пользователя не задано");
                return;
            }

            var nameValue = nameProperty.GetValue(requestValue) as string;

            if (string.IsNullOrWhiteSpace(nameValue))
            {
                context.Result = new BadRequestObjectResult("Имя пользователя не задано");
                return;
            }
        }
    }
}
