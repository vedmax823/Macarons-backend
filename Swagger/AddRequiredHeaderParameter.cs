using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace DonMacaron.Swagger;



public class AddRequiredHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Authorization", // Назва заголовка
            In = ParameterLocation.Header,
            Required = false, // Якщо заголовок не обов'язковий, ставимо false
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}