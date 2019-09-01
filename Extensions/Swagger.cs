using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Hosting;

namespace Products.Extensions
{

    internal static class Swagger    {
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseSwagger(o =>
                {
                    o.RouteTemplate = "product-api/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/product-api/swagger/v1/swagger.json", "product-api");
                    c.RoutePrefix = "product-api";
                });
            }

            return app;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "search-api", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);

                c.DescribeAllEnumsAsStrings();
            });

            return services;
        }
    }
}
