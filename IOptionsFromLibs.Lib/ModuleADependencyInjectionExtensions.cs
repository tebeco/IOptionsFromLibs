using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace IOptionsFromLibs.Lib.Configuration
{
    public static class ModuleADependencyInjectionExtensions
    {
        public static IServiceCollection AddModuleA(this IServiceCollection services, ILogger logger)
        {
            logger.LogInformation("inside simple AddModuleA");

            return services;
        }
        public static IServiceCollection AddModuleA(this IServiceCollection services, ILogger logger, Action<ModuleAOptions> configure)
        {
            logger.LogInformation("inside simple AddModuleA with callback");

            return services.Configure(configure)
                           .PostConfigure<ModuleAOptions>(options =>
                           {
                               logger.LogInformation("inside callback of extension method AddModuleA");
                           });
        }
    }
}
