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
                    })
                    .PostConfigure(options =>
                    {
                        if (options.Z < 0)
                        {
                            options.Z = 0;
                        }
                    })
                    .Validate(
                        options => options.Z <= 1000,
                        $"The value for {nameof(ModuleAOptions)}.{nameof(ModuleAOptions.Z)} cannot be greater than 1000. It is possible to change it using the configuration key {ModuleAOptions.ModuleASectionName}:{nameof(ModuleAOptions.Z)}"
                    )
                    ;

            return services;
        }
        public static IServiceCollection AddModuleA(this IServiceCollection services, Action<ModuleAOptions> configure)
        {
            return services.AddModuleA()
                           .Configure(configure);
        }
    }
}
