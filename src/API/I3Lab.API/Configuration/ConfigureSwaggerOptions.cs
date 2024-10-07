using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace I3Lab.API.Configuration
{
    public class ConfigureSwaggerGenOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = $"I3Lab.API v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString()
                };

                options.SwaggerDoc(description.GroupName, openApiInfo);
            }
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }
    }

    //public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    //{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
    //    public void Configure(SwaggerGenOptions options)
    //    {
    //        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //        {
    //            In = ParameterLocation.Header,
    //            Description = "Please enter 'Bearer [jwt]'",
    //            Name = "Authorization",
    //            Type = SecuritySchemeType.Http,
    //            BearerFormat = "JWT",
    //            Scheme = "Bearer"

    //        });
    //        options.AddSecurityRequirement(new OpenApiSecurityRequirement
    //        {
    //            {
    //                new OpenApiSecurityScheme
    //                {
    //                    Reference = new OpenApiReference
    //                    {
    //                        Type = ReferenceType.SecurityScheme,
    //                        Id = "Bearer"
    //                    }
    //                },
    //                Array.Empty<string>()
    //            }
    //        });
    //    }
    //}
}
