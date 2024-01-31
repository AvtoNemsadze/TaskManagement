using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace TaskManagement.Common.OperationFilter
{
    public class AcceptLanguageOperationFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var acceptLanguageParameter = new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Language preference",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Enum = { new OpenApiString("ka-GE"), new OpenApiString("en-US") } // Add enum values for dropdown
                }
            };

            if (swaggerDoc.Paths != null)
            {
                foreach (var pathItem in swaggerDoc.Paths.Values)
                {
                    foreach (var operation in pathItem.Operations)
                    {
                        if (operation.Value.Parameters == null)
                        {
                            operation.Value.Parameters = new List<OpenApiParameter>();
                        }

                        // Insert the acceptLanguageParameter at the beginning of the parameters list
                        operation.Value.Parameters.Insert(0, acceptLanguageParameter);
                    }
                }
            }
        }
    }



    //public class AcceptLanguageOperationFilter : IOperationFilter
    //{
    //    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //    {
    //        if (operation.Parameters == null)
    //        {
    //            operation.Parameters = new List<OpenApiParameter>();
    //        }

    //        operation.Parameters.Add(new OpenApiParameter
    //        {
    //            Name = "Accept-Language",
    //            In = ParameterLocation.Header,
    //            Description = "Language preference",
    //            Required = false, // Set to true if language is mandatory
    //            Schema = new OpenApiSchema
    //            {
    //                Type = "String"
    //            }
    //        });
    //    }
    //}
}
