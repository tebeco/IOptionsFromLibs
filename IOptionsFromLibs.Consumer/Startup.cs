using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOptionsFromLibs.Lib.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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
            services.AddModuleA(options => {
                options.Y = "Y value from consumer startup";
                options.Z = "Z value from consumer startup";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.Run(async (context)=>
            {
                var moduleAOptions= context.RequestServices.GetService<IOptions<ModuleAOptions>>();

                var optionsAsStringJson = JsonConvert.SerializeObject(moduleAOptions);
                var optionAsBytesJson = Encoding.UTF8.GetBytes(optionsAsStringJson);

                await context.Response.Body.WriteAsync(optionAsBytesJson).ConfigureAwait(false);
                await context.Response.Body.FlushAsync().ConfigureAwait(false);
            });
        }
    }
}
