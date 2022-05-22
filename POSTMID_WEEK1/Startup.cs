using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTMID_WEEK1
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
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(
                async (context, next) =>
                {
                    await context.Response.WriteAsync("gg\n");
                    await next();
                    await context.Response.WriteAsync("After next m1\n");
                });
            app.Use(
                async (context, next) =>
                {
                    await context.Response.WriteAsync("gg1\n");
                    await next();
                    await context.Response.WriteAsync("After next m2\n");
                });
            app.Run(
                async (context) =>
                {
                    await context.Response.WriteAsync("wao");
                });
        }
    }
}
