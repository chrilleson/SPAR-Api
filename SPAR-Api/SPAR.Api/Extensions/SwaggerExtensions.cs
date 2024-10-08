﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace SPAR.Api.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwagger(this IServiceCollection services) =>
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "SPAR.Api", Version = "v1" });
            options.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
            });
        });
}