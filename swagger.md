Swagger - ������� ���������� ��� ������������ API. ����: https://www.openapis.org/

������ �� ��������� swagger.json: http://localhost:5078/swagger/v1/swagger.json
������ �� ��������� swagger ui: http://localhost:5078/swagger/index.html

��������� ���������:
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0#openapi-specification-openapijson
- https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=visual-studio

���������� ����� ������������ � ���������� ��������������:
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>

������ ������ ���������� �������������� CS1591:
#pragma warning disable CS1591