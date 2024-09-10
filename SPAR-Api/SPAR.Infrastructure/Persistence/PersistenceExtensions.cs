﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace SPAR.Infrastructure.Persistence;

public static class PersistenceExtensions
{
    public static void AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(builder => builder.ConfigureDbContext(connectionString));
    }
    private static void ConfigureDbContext(this DbContextOptionsBuilder builder, string connectionString) =>
         builder
             .UseNpgsql(connectionString, opt =>
             {
                 opt.MigrationsAssembly("SPAR.Infrastructure");
             })
             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
             .ConfigureWarnings(x => x.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
}