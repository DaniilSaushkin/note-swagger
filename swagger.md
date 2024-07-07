Swagger is useful tool for documentation API. https://www.openapis.org/

Default request for swagger.json: http://localhost:5078/swagger/v1/swagger.json
Default request for swagger ui: http://localhost:5078/swagger/index.html

Tutorials:
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0#openapi-specification-openapijson
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio

Add documentation file and disable all warnings of CS1591 code:
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>

Other way of disable CS1591 code:
#pragma warning disable CS1591