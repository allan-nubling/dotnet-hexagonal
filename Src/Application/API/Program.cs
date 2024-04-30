
using System.Reflection;
using Application.API.v1.Controllers;
using Domain;

using Microsoft.OpenApi.Models;

namespace Application.API
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // builder.Services.AddKeyedSingleton<IService, ServiceA>(ServicesEnum.ServiceA);
            // builder.Services.AddKeyedSingleton<IService, ServiceB>(ServicesEnum.ServiceB);

            // builder.Services.AddScoped<IServiceMapper>(provider =>
            // {

            //     Dictionary<ServicesEnum, IService> services = new()
            //     {
            //         [ServicesEnum.ServiceA] = builder.Services.BuildServiceProvider().GetKeyedService<IService>(ServicesEnum.ServiceA),
            //         [ServicesEnum.ServiceB] = builder.Services.BuildServiceProvider().GetKeyedService<IService>(ServicesEnum.ServiceB)
            //     };
            //     return new ServiceMapper(services);
            // }); ;


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
            });

            // builder.Services.AddScoped<ICreateProcessUseCase, CreateProcessUseCase>();
            // builder.Services.AddScoped<IGetProcessUseCase, GetProcessUseCase>();

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