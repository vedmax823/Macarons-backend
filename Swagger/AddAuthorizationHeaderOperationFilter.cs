
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace DonMacaron.Swagger;

public class AddAuthorizationHeaderOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }

        // Додаємо заголовок Authorization для кожного запиту
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Description = "Bearer {ваш токен}",
            Required = true, // робимо заголовок обов'язковим
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}