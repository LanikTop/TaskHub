using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Api.ModelBinders;

namespace Api.Attributes
{
    public class FromRouteTaskIdAttribute : ModelBinderAttribute
    {
        public FromRouteTaskIdAttribute()
        {
            BinderType = typeof(TaskIdModelBinder);
            BindingSource = BindingSource.Path;
        }
    }
}