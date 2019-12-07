using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Domain.RepositoryContract;
using Domain.ServiceContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
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
            services.AddMvc();

            services.Scan(scan => scan
            .FromAssemblyOf()
           .AddClasses(classes => classes.AssignableTo<IGoodService>(),publicOnly:false)
           .AsImplementedInterfaces()
           .WithScopedLifetime());

            services.Scan(scan => scan
           .FromAssemblyOf<IGoodRepository>()
           .AddClasses(classes => classes.AssignableTo<IGoodRepository>(), publicOnly: false)
           .AsImplementedInterfaces()
           .WithScopedLifetime());

            services.Scan(scan => scan
           .FromAssemblyOf<IDbContext>()
           .AddClasses(classes => classes.AssignableTo<IDbContext>(), publicOnly: false)
           .AsImplementedInterfaces()
           .WithScopedLifetime());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                                    name: "default",
                                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
