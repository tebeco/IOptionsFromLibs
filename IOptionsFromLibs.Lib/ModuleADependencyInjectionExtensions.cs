using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
                               options.Z = "z value from post configure from AddModuleA in the libs";
                           });
        }

    }
}
