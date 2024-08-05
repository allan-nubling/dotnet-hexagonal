
using System.Reflection;
using Application.API.Configurations.Filters;
using Domain.UseCases;
using Microsoft.OpenApi.Models;
namespace Application.API
{
    internal class Program
    {
        private static async Task Main()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en-US", "pt-BR" };
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });

            builder.Services.AddLocalization();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
            });

            builder.Services.AddScoped<ExampleUseCase>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            app.UseRequestLocalization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // app.UseSwaggerUI(options =>
                // {
                //     options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                //     options.RoutePrefix = string.Empty;
                // });
            }

            app.MapControllers();

            app.Run();
        }
    }
}