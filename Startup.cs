using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

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
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			var builder = new ContainerBuilder();

			builder.Populate(services);
			builder.RegisterModule(new InfrastructorModule());
			builder.RegisterModule(new CoreModule());
			
			//builder.Populate(services);
			var container = builder.Build();
			// Create the IServiceProvider based on the container.
			return new AutofacServiceProvider(container);

			//var service = Assembly.GetExecutingAssembly();

			//builder.RegisterAssemblyTypes(service)
			//			 .Where(t => t.Name.EndsWith("Business"))
			//			 .AsImplementedInterfaces();

			//var dataAccess = Assembly.GetExecutingAssembly();

			//builder.RegisterAssemblyTypes(dataAccess)
			//			 .Where(t => t.Name.EndsWith("dataAccess"))
			//			 .AsImplementedInterfaces();




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
