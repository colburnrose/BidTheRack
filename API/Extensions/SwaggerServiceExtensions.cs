using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(v =>
            {
                v.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BidTheRack",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Colburn Sanders",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/colburnomareo")
                    }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "BidTheRack API v1"); });
            return app;
        }
    }
}
