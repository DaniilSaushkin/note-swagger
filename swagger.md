Swagger - удобный инструмент для документации API. Сайт: https://www.openapis.org/

Запрос по умолчанию swagger.json: http://localhost:5078/swagger/v1/swagger.json
Запрос по умолчанию swagger ui: http://localhost:5078/swagger/index.html

Обучающие материалы:
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0#openapi-specification-openapijson
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio

Добавление файла документации и отключение предупреждений:
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>

Другой способ отключения предупреждений CS1591:
#pragma warning disable CS1591