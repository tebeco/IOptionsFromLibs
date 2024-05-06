using IOptionsFromLibs.Library;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ModuleADependencyInjectionExtensions
    {
        public static IServiceCollection AddModuleA(this IServiceCollection services)
            => services.AddModuleA(ModuleAOptions.SectionName);

        public static IServiceCollection AddModuleA(this IServiceCollection services, Action<ModuleAOptions> configure)
            => services.AddModuleA(ModuleAOptions.SectionName).Configure(configure);

        public static IServiceCollection AddModuleA(this IServiceCollection services, string sectionName, Action<ModuleAOptions> configure)
            => services.AddModuleA(sectionName).Configure(configure);

        public static IServiceCollection AddModuleA(this IServiceCollection services, string sectionName)
        {
            services.AddOptions<ModuleAOptions>()
                    .BindConfiguration(sectionName)
                    .PostConfigure(options =>
                    {
                        if (options.Z < 0)
                        {
                            options.Z = 0;
                        }
                    })
                    .Validate(
                        options => options.Z <= 1000,
                        $"The value for {nameof(ModuleAOptions)}.{nameof(ModuleAOptions.Z)} cannot be greater than 1000. It is possible to change it using the configuration key {ModuleAOptions.SectionName}:{nameof(ModuleAOptions.Z)}"
                    );

            return services;
        }

    }
}
