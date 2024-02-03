using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestWebApplication
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseStaticFiles();

			app.UseEndpoints(endPoint =>
			{
				endPoint.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
			});
		}
	}
}
