﻿using System.Reflection;
using SPAR.Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SPAR.Application;

public static class ApplicationExtensions
{
    private static Assembly TargetAssembly => typeof(ApplicationExtensions).Assembly;

    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(TargetAssembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssembly(TargetAssembly);
    }
}