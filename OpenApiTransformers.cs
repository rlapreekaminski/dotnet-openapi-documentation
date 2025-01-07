using System.Text.Json.Serialization.Metadata;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

public static class OpenApiTransformers
{
    public static Func<OpenApiDocument, OpenApiDocumentTransformerContext, CancellationToken, Task> InformationsDocumentTransformer()
    {
        return (document, context, cancellationToken) =>
        {
            document.Info = new()
            {
                Title = "Session API",
                Version = "v1",
                Description = "API for processing sessions."
            };
            return Task.CompletedTask;
        };
    }

    public static Func<OpenApiOperation, OpenApiOperationTransformerContext, CancellationToken, Task> InternalErrorOperationTransformer()
    {
        return (operation, context, cancellationToken) =>
        {
            operation.Responses.Add("500", new OpenApiResponse { Description = "Internal server error" });
            return Task.CompletedTask;
        };
    }

    public static Func<JsonTypeInfo, string?> OverrideEnumSchemaReference()
    {
        return (type) => type.Type.IsEnum ? null : OpenApiOptions.CreateDefaultSchemaReferenceId(type);
    }


    public static Func<OpenApiSchema, OpenApiSchemaTransformerContext, CancellationToken, Task> EnumSchemaTransformer()
    {
        return (schema, context, cancellationToken) =>
        {
            if (context.JsonTypeInfo.Type.IsEnum)
            {
                schema.Type = "string";
            }
            return Task.CompletedTask;
        };
    }
}