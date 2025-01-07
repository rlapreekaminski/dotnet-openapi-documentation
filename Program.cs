using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi("sessions", options =>
{
    options.AddDocumentTransformer(OpenApiTransformers.InformationsDocumentTransformer());

    options.AddOperationTransformer(OpenApiTransformers.InternalErrorOperationTransformer());

    options.CreateSchemaReferenceId = OpenApiTransformers.OverrideEnumSchemaReference();

    options.AddSchemaTransformer(OpenApiTransformers.EnumSchemaTransformer());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

LocalDB.Init();

app.MapGroup("/sessions").MapSessions()
  .WithTags("Sessions");

app.Run();

