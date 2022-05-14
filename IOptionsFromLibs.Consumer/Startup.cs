using IOptionsFromLibs.Lib.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace IOptionsFromLibs.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddModuleA(options =>
            {
                options.Y = "Y value from consumer startup";
                options.Z = -1;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseRouting();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });

            // That or uncomment the block above to use the controller
            app.Run(async (context) =>
            {
                var moduleAOptions = context.RequestServices.GetService<IOptions<ModuleAOptions>>();

                var optionsAsStringJson = JsonSerializer.Serialize(moduleAOptions);
                var optionAsBytesJson = Encoding.UTF8.GetBytes(optionsAsStringJson);

                await context.Response.Body.WriteAsync(optionAsBytesJson);
                await context.Response.Body.FlushAsync();
            });
        }
    }
}
