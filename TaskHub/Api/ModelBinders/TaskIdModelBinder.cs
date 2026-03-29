using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.ModelBinders
{
    public class TaskIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var valueProviderResult = bindingContext.ValueProvider.GetValue("id");
            var routeValue = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(routeValue))
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName,
                    "Идентификатор задачи не задан");
                return Task.CompletedTask;
            }

            if (!Guid.TryParse(routeValue, out var guidValue))
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName,
                    "Идентификатор задачи имеет некорректный формат");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(guidValue);
            return Task.CompletedTask;
        }
    }
}