# Getting started

## Swagger
Swagger is useful tool for documentation API. Website: https://www.openapis.org/

## First step
We need to install the `Swashbuckle` libs through `NuGet`:

- `Swashbuckle.AspNetCore`;
- `Swashbuckle.AspNetCore.Swagger`;
- `Swashbuckle.AspNetCore.SwaggerUI`;
- `Swashbuckle.AspNetCore.SwaggerGen`.

## Second step
In the `project_name.csproj` file we need to write properties for **create documentation file** and **disable all warnings** with `CS1591` code:

```XML
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>
```

Other way of disable the CS1591 code:

```CSHARP
#pragma warning disable CS1591
```

## Third step
In `Program.cs` file we need add Swagger to the project:

```CSHARP
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
```

For more details see the file `Program.cs`.

## Last step
For last step we need to add a `summary` for our methods in the controller.
For more details see the file `NameController.cs`.

## Other
Default request for `swagger.json`: http://localhost:5078/swagger/v1/swagger.json
Default request for `Swagger UI`: http://localhost:5078/swagger/index.html

## Tutorials
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0#openapi-specification-openapijson
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio