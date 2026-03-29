using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Filters
{
    public class DisableValidationFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Name == "id")
            {
                parameter.Schema.Pattern = null;
                parameter.Required = true;
            }
        }
    }
}
