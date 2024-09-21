using System.Reflection;
using SPAR.Application.Pipelines;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SPAR.Application;

public static class ApplicationExtensions
{
    private static Assembly TargetAssembly => Assembly.GetExecutingAssembly();

    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg
                .RegisterServicesFromAssembly(TargetAssembly)
                .AddOpenBehavior(typeof(FluentValidationPipelineBehavior<,>))
        );
        services.AddValidatorsFromAssembly(TargetAssembly);
    }
}