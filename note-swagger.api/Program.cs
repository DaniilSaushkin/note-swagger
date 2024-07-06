using Microsoft.OpenApi.Models;
using System.Reflection;

#pragma warning disable CS1591
namespace note_swagger.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ��������� Swagger � ������.
            builder.Services.AddSwaggerGen(options =>
            {
                // ��������� ���������� ����������.
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "note-swagger. ToDo API",
                    Description = "My notes about Swagger. This is training project",
                    TermsOfService = new Uri(@"https://github.com/DaniilSaushkin/note-swagger"),
                    Contact = new OpenApiContact
                    {
                        Name = "Daniil Saushkin",
                        Url = new Uri("https://github.com/DaniilSaushkin"),
                        Email = "daniil.saushkin@outlook.com",
                    }
                });

                // ������� XML-����.
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // ����� ����������� Swagger � ������.
            app.UseSwagger();
            app.UseSwaggerUI(options => // ��������� UI Swagger � ������.
            {
                // �������������� ������� ��� swagger.json.
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

                // �������������� ������� ��� Swagger UI.
                // ������ ��: localhost:5078/
                options.RoutePrefix = string.Empty;
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
