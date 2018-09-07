using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IOptionsFromLibs.Lib.Configuration
{
    public static class ModuleADependencyInjectionExtensions
    {
        public static IServiceCollection AddModuleA(this IServiceCollection services)
        {
            services.AddOptions<ModuleAOptions>()
                    .Configure<IConfiguration>((options, configuration) =>
                    {
                        configuration.Bind(ModuleAOptions.ModuleASectionName, options);
                    });

            return services;
        }
        public static IServiceCollection AddModuleA(this IServiceCollection services, Action<ModuleAOptions> configure)
        {
            return services.AddModuleA()
                           .Configure(configure)
                           .PostConfigure<ModuleAOptions>(options =>
                           {
                               if (options.Z < 0)
                               {
                                   options.Z = 0;
                               }
                           });
        }
    }
}
